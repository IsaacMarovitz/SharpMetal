using SharpMetal.Generator.CSharpCodeGen;
using SharpMetal.Generator.Instances;
using SharpMetal.Generator.Utilities;

namespace SharpMetal.Generator.Transformers
{
    public static class ClassTransformer
    {
        public static CSharpStructType TransformClass(ParsedModel parsedModel, HashSet<ObjectiveCInstance> objectiveCInstances, ClassInstance classInstance)
        {
            // Make copies since we will modify these by adding the hiearchy
            // This is not ideal, but is the simplest way to make it independent on the processing order
            var propertyInstances = new List<PropertyInstance>(classInstance.PropertyInstances);
            var methodInstances = new List<MethodInstance>(classInstance.MethodInstances);
            var selectorInstances = new List<SelectorInstance>(classInstance.SelectorInstances);

            ResolveClassHierarchy(parsedModel, classInstance, propertyInstances, methodInstances, selectorInstances);

            propertyInstances.Sort((a, b) => string.Compare(a.Name, b.Name, StringComparison.InvariantCultureIgnoreCase));
            methodInstances.Sort((a, b) => string.Compare(a.Name, b.Name, StringComparison.InvariantCultureIgnoreCase));

            var csClass = new CSharpStructType(classInstance.Name);
            csClass.IsPartial = GeneratorUtils.IsPartialType(classInstance.Name);
            csClass.BaseTypes.Add("IDisposable");
            csClass.AddMember(new CSharpField("IntPtr", "NativePtr"));

            var implicitToIntPtr = new CSharpMethod("IntPtr", "implicit operator", (classInstance.Name, "obj", ""));
            implicitToIntPtr.IsStatic = true;
            implicitToIntPtr.PreferExpressionBody = true;
            implicitToIntPtr.AddBodyLine("obj.NativePtr");
            csClass.AddMember(implicitToIntPtr);

            if (classInstance.Parent != string.Empty)
            {
                var implicitToParent = new CSharpMethod(classInstance.Parent, "implicit operator", (classInstance.Name, "obj", ""));
                implicitToParent.IsStatic = true;
                implicitToParent.PreferExpressionBody = true;
                implicitToParent.AddBodyLine("new(obj.NativePtr)");
                csClass.AddMember(implicitToParent);
            }

            var ctor = new CSharpMethod(classInstance.Name, "", ("IntPtr", "ptr", ""));
            ctor.PreferExpressionBody = true;
            ctor.AddBodyLine("NativePtr = ptr");
            csClass.AddMember(ctor);

            if (classInstance.HasAlloc)
            {
                var parameterlessCtor = new CSharpMethod(classInstance.Name, "");
                parameterlessCtor.AddBodyLine($"var cls = new ObjectiveCClass(\"{classInstance.Name}\")");
                parameterlessCtor.AddBodyLine(classInstance.HasInit ? "NativePtr = cls.AllocInit()" : "NativePtr = cls.Alloc()");
                csClass.AddMember(parameterlessCtor);
            }

            var dispose = new CSharpMethod("Dispose", "void");
            dispose.AddBodyLine("ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release)");
            csClass.AddMember(dispose);

            // These have to be sorted after making the copy, otherwise it might resolve to wrong selector due to the Find-based mechanism when generating the calls
            selectorInstances.Sort((a, b) => string.Compare(a.Name, b.Name, StringComparison.InvariantCultureIgnoreCase));

            foreach (var property in propertyInstances)
            {
                LinkClassProperty(parsedModel, objectiveCInstances, selectorInstances, property, csClass);
            }

            foreach (var method in methodInstances)
            {
                LinkClassMethod(parsedModel, objectiveCInstances, selectorInstances, method, csClass);
            }

            foreach (var selector in selectorInstances)
            {
                var selectorField = new CSharpField("Selector", selector.Name);
                selectorField.IsStatic = true;
                selectorField.IsReadonly = true;
                selectorField.VisibilityModifier = "private";
                selectorField.DefaultValue = $"\"{selector.Selector}\"";
                csClass.AddMember(selectorField);
            }

            var selectorReleaseField = new CSharpField("Selector", "sel_release");
            selectorReleaseField.IsStatic = true;
            selectorReleaseField.IsReadonly = true;
            selectorReleaseField.VisibilityModifier = "private";
            selectorReleaseField.DefaultValue = "\"release\"";
            csClass.AddMember(selectorReleaseField);

            return csClass;
        }

        private static void LinkClassMethod(ParsedModel parsedModel, HashSet<ObjectiveCInstance> objectiveCInstances, List<SelectorInstance> selectorInstances, MethodInstance method, CSharpStructType csClass)
        {
            var matches = selectorInstances.FindAll(x => !x.UsedInProperty && string.Equals(SanitizeSelectorLookups(x.MethodSignatureString), SanitizeSelectorLookups(method.RawName), StringComparison.InvariantCultureIgnoreCase));
            if (matches.Count > 1)
            {
                Console.WriteLine($"Ambiguous matches for {method.RawName}");
                foreach (var match in matches)
                {
                    Console.WriteLine($"- {match.MethodSignatureString}");
                }
            }

            // Disallow the selectors used in properties to prevent doubling of properties and methods that do the same
            var selector = matches.FirstOrDefault();
            if (selector != null)
            {
                var parameters = new List<(string, string, string)>();

                // TODO: Handle array inputs
                var hasArrayInput = false;

                for (var i = 0; i < method.InputInstances.Count; i++)
                {
                    var input = method.InputInstances[i];

                    if (input.Type.Contains("[]"))
                    {
                        hasArrayInput = true;
                    }

                    parameters.Add(($"{(input.Reference ? "ref " : "")}{input.Type}", input.Name, ""));
                }

                var csMethod = new CSharpMethod(method.Name, method.ReturnType, parameters);
                csMethod.IsStatic = method.IsStatic;
                csClass.AddMember(csMethod);

                if (method.ReturnType == "void" && !hasArrayInput)
                {
                    if (method.IsStatic)
                    {
                        csMethod.AddBodyLine("throw new NotSupportedException()");
                    }
                    else
                    {
                        var call = $"ObjectiveCRuntime.objc_msgSend(NativePtr, {selector.Name}";

                        for (var index = 0; index < method.InputInstances.Count; index++)
                        {
                            var cast = "";
                            var enumInstance = parsedModel.FindEnum(method.InputInstances[index].Type);

                            if (enumInstance != null)
                            {
                                cast = $"({enumInstance.BackingType})";
                            }

                            call += $", {cast}{method.InputInstances[index].Name}";
                        }

                        call += ")";
                        csMethod.AddBodyLine(call);
                    }
                }
                else if (!hasArrayInput)
                {
                    var line = "return ";
                    var returnEnum = parsedModel.FindEnum(method.ReturnType);
                    var returnStruct = parsedModel.FindStruct(method.ReturnType);
                    var needsOuterBracket = false;

                    if (returnEnum != null)
                    {
                        line += $"({method.ReturnType})ObjectiveCRuntime.{returnEnum.BackingType}_";
                    }
                    else
                    {
                        if (Types.CSharpNativeTypes.Contains(method.ReturnType) || returnStruct != null)
                        {
                            line += $"ObjectiveCRuntime.{method.ReturnType}_";
                        }
                        else
                        {
                            line += $"new(ObjectiveCRuntime.IntPtr_";
                            needsOuterBracket = true;
                        }
                    }

                    line += "objc_msgSend(";

                    if (method.IsStatic)
                    {
                        line += $"new ObjectiveCClass(\"{method.ReturnType}\")";
                    }
                    else
                    {
                        line += "NativePtr";
                    }

                    line += $", {selector.Name}";

                    for (var index = 0; index < method.InputInstances.Count; index++)
                    {
                        var enumInstance = parsedModel.FindEnum(method.InputInstances[index].Type);
                        var input = method.InputInstances[index];

                        if (enumInstance != null)
                        {
                            line += $", ({enumInstance.BackingType}){input.Name}";
                        }
                        else if (input.Reference)
                        {
                            line += $", ref {input.Name}.NativePtr";
                        }
                        else
                        {
                            line += $", {input.Name}";
                        }
                    }

                    if (needsOuterBracket)
                    {
                        line += ")";
                    }

                    line += ")";

                    csMethod.AddBodyLine(line);
                }
                else
                {
                    csMethod.AddBodyLine("throw new NotImplementedException()");
                }
            }

            string type;
            List<string> inputs = [];

            for (var i = 0; i < method.InputInstances.Count; i++)
            {
                if (Types.CSharpNativeTypes.Contains(method.InputInstances[i].Type))
                {
                    inputs.Add(method.InputInstances[i].Type);
                }
                else
                {
                    var enumInstance = parsedModel.FindEnum(method.InputInstances[i].Type);
                    var structInstance = parsedModel.FindStruct(method.InputInstances[i].Type);

                    if (enumInstance != null)
                    {
                        inputs.Add(enumInstance.BackingType);
                    }
                    else if (structInstance != null)
                    {
                        inputs.Add(structInstance.Name);
                    }
                    else if (method.InputInstances[i].Type == "NSError")
                    {
                        inputs.Add("ref IntPtr");
                    }
                    else
                    {
                        inputs.Add("IntPtr");
                    }
                }
            }

            if (method.ReturnType == "void")
            {
                type = method.ReturnType;
            }
            else
            {
                var returnStruct = parsedModel.FindStruct(method.ReturnType);
                if (Types.CSharpNativeTypes.Contains(method.ReturnType) || returnStruct != null)
                {
                    type = method.ReturnType;
                }
                else
                {
                    var returnEnum = parsedModel.FindEnum(method.ReturnType);
                    if (returnEnum != null)
                    {
                        type = returnEnum.BackingType;
                    }
                    else
                    {
                        type = "IntPtr";
                    }
                }
            }

            objectiveCInstances.Add(new ObjectiveCInstance(type, inputs));
        }

        private static void LinkClassProperty(ParsedModel parsedModel, HashSet<ObjectiveCInstance> objectiveCInstances, List<SelectorInstance> selectorInstances, PropertyInstance property, CSharpStructType csClass)
        {
            var selector = selectorInstances.Find(x => string.Equals(x.Selector, property.Name, StringComparison.InvariantCultureIgnoreCase));
            var type = "";

            if (selector == null)
            {
                // This can sometimes select the wrong selector, so we only want to use it as a backup
                selector = selectorInstances.Find(x => x.Selector.Contains(property.Name, StringComparison.InvariantCultureIgnoreCase));
            }

            if (selector != null)
            {
                var csProperty = new CSharpProperty(property.Name, property.Type);
                csClass.AddMember(csProperty);

                selector.UsedInProperty = true;
                // We assume a type of IntPtr, which encapsulates any possible type
                var runtimeFuncReturn = "IntPtr";
                // Check for existing get/set pair
                var setterSelector = ResolveSetterSelector(selectorInstances, selector);
                if (setterSelector != null)
                {
                    setterSelector.UsedInProperty = true;
                }

                // If the property is a type that exists in C# then we can safely set the
                // return type to be that type, otherwise further conversion will be needed later
                if (Types.CSharpNativeTypes.Contains(property.Type))
                {
                    runtimeFuncReturn = property.Type;
                }

                var enumOrStructInstance = parsedModel.FindType(property.Type);

                var target = property.IsStatic ? $"new ObjectiveCClass(\"{property.ContainingClass.Name}\")" : "NativePtr";
                csProperty.IsStatic = property.IsStatic;

                if (property.IsDeprecated)
                {
                    csProperty.AddAttribute("[System.Obsolete]");
                }

                if (enumOrStructInstance is EnumInstance enumInstance)
                {
                    type = enumInstance.BackingType;

                    csProperty.Getter = $"({enumInstance.Name})ObjectiveCRuntime.{enumInstance.BackingType}_objc_msgSend({target}, {selector.Name})";
                    if (setterSelector != null)
                    {
                        csProperty.Setter = $"ObjectiveCRuntime.objc_msgSend({target}, {setterSelector.Name}, ({enumInstance.BackingType})value)";
                    }
                }
                else if (enumOrStructInstance is StructInstance structInstance)
                {
                    type = structInstance.Name;

                    csProperty.Getter = $"ObjectiveCRuntime.{structInstance.Name}_objc_msgSend({target}, {selector.Name})";
                    if (setterSelector != null)
                    {
                        csProperty.Setter = $"ObjectiveCRuntime.objc_msgSend({target}, {setterSelector.Name}, value)";
                    }
                }
                else
                {
                    type = runtimeFuncReturn;

                    if (runtimeFuncReturn == "IntPtr")
                    {
                        csProperty.Getter = $"new(ObjectiveCRuntime.{runtimeFuncReturn}_objc_msgSend({target}, {selector.Name}))";
                    }
                    else
                    {
                        csProperty.Getter = $"ObjectiveCRuntime.{runtimeFuncReturn}_objc_msgSend({target}, {selector.Name})";
                    }

                    if (setterSelector != null)
                    {
                        csProperty.Setter = $"ObjectiveCRuntime.objc_msgSend({target}, {setterSelector.Name}, value)";
                    }
                }
            }

            objectiveCInstances.Add(new ObjectiveCInstance(type, []));
        }

        private static void ResolveClassHierarchy(ParsedModel parsedModel, ClassInstance classInstance, List<PropertyInstance> propertyInstances, List<MethodInstance> methodInstances, List<SelectorInstance> selectorInstances)
        {
            var parentName = classInstance.Parent;
            while (parentName != string.Empty)
            {
                // To properly fit within expected C# patterns, we
                // should generate an interface to hold the associated
                // properties and methods to allow for proper casting
                // between types. Right now, due to the limitations of
                // struct inheritance, we will just duplicate all
                // properties and methods from the parent to the child.
                // This limitation is not present with the old method
                // using classes, however that comes with performance
                // and memory drawbacks, that structs are able to avoid.

                var parent = parsedModel.FindClass(parentName);
                parentName = parent?.Parent ?? string.Empty;
                if (parent != null)
                {
                    // Just add unique instances, since the MTLAllocation inheritance would cause doubled-up properties
                    foreach (var property in parent.PropertyInstances)
                    {
                        if (!propertyInstances.Any(x => x.Name == property.Name && x.Type == property.Type))
                        {
                            propertyInstances.Add(property);
                        }
                    }

                    methodInstances.AddRange(parent.MethodInstances);
                    foreach (var selector in parent.SelectorInstances)
                    {
                        if (selectorInstances.All(x => x.Name != selector.Name))
                        {
                            selectorInstances.Add(selector);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Sanitize the lookups by removing the namespace prefixes. They are unfortunately inconsistently used in the cpp bindings, so this is the most reasonable way to approach the issue.
        /// </summary>
        /// <param name="input">The signature parsed from metal-cpp</param>
        /// <returns>Sanitized signature without namespace prefixes</returns>
        private static string SanitizeSelectorLookups(string input)
        {
            return input.Replace(" class ", " ")
                .Replace("(class ", "(")
                .Replace("NS::", "")
                .Replace("MTL4FX::", "")
                .Replace("MTLFX::", "");
        }

        private static SelectorInstance? ResolveSetterSelector(List<SelectorInstance> selectorInstances, SelectorInstance selector)
        {
            // Try to match the "isFoo" + "setFoo" as a get/set property
            var setterSelectorNameCandidate = selector.Selector;
            if (setterSelectorNameCandidate.StartsWith("is"))
            {
                setterSelectorNameCandidate = setterSelectorNameCandidate.Substring(2);
            }

            setterSelectorNameCandidate = "set" + setterSelectorNameCandidate;
            var setterSelector = selectorInstances.Find(x => x.Selector.Contains(setterSelectorNameCandidate, StringComparison.InvariantCultureIgnoreCase));

            if (setterSelector == null)
            {
                // Fallback to setIsFoo, which apparently has some occurrences in the metal-cpp bindings
                setterSelectorNameCandidate = "set" + selector.Selector;
                setterSelector = selectorInstances.Find(x => x.Selector.Contains(setterSelectorNameCandidate, StringComparison.InvariantCultureIgnoreCase));
            }

            return setterSelector;
        }
    }
}
