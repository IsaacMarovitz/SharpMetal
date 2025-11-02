using SharpMetal.Generator.CSharpCodeGen;
using SharpMetal.Generator.Instances;

namespace SharpMetal.Generator.Transformers
{
    public class ModelTransformer
    {
        private static string[] VarNames { get; } =
        [
            "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"
        ];

        public List<CSharpFile> Link(ParsedModel parsedModel)
        {
            var objectiveCInstances = new HashSet<ObjectiveCInstance>();

            var rv = new List<CSharpFile>();

            foreach (var header in parsedModel.Headers)
            {
                var outputFile = new CSharpFile(header.FileName, header.FullNamespace);
                var ns = outputFile.GetOrCreateNamespace($"SharpMetal.{header.FullNamespace}");

                header.EnumInstances.Sort((a, b) => string.Compare(a.Name, b.Name, StringComparison.InvariantCultureIgnoreCase));
                header.StructInstances.Sort((a, b) => string.Compare(a.Name, b.Name, StringComparison.InvariantCultureIgnoreCase));
                header.ClassInstances.Sort((a, b) => string.Compare(a.Name, b.Name, StringComparison.InvariantCultureIgnoreCase));

                foreach (var enumInstance in header.EnumInstances)
                {
                    ns.AddType(EnumTransformer.TransformEnum(enumInstance));
                }

                foreach (var structInstance in header.StructInstances)
                {
                    ns.AddType(StructTransformer.TransformStruct(structInstance));
                }

                foreach (var classInstance in header.ClassInstances)
                {
                    ns.AddType(ClassTransformer.TransformClass(parsedModel, objectiveCInstances, classInstance));
                }

                AddUsings(outputFile, header);

                rv.Add(outputFile);
            }

            rv.Add(GenerateObjectiveC(objectiveCInstances));

            return rv;
        }

        public static CSharpFile GenerateObjectiveC(HashSet<ObjectiveCInstance> objectiveCInstances)
        {
            var outputFile = new CSharpFile("ObjectiveCRuntime");

            objectiveCInstances.RemoveWhere(x => x.Type == string.Empty);

            outputFile.AddUsing("System.Runtime.InteropServices");
            outputFile.AddUsing("System.Runtime.Versioning");
            outputFile.AddUsing("SharpMetal.ObjectiveCCore");
            outputFile.AddUsing("SharpMetal.Foundation");
            outputFile.AddUsing("SharpMetal.Metal");

            var ns = outputFile.GetOrCreateNamespace("SharpMetal");

            var csClass = new CSharpClassType("ObjectiveCRuntime");
            csClass.IsPartial = true;
            csClass.IsStatic = true;
            csClass.VisibilityModifier = "internal";
            ns.AddType(csClass);

            var list = objectiveCInstances.ToList();
            list.Sort(ObjectiveCEmitOrderComparer);

            foreach (var item in list)
            {
                string name = item.Type != "void" ? $"{item.Type}_objc_msgSend" : "objc_msgSend";
                var parameters = new List<(string, string, string)>();
                parameters.Add(("IntPtr", "receiver", ""));
                parameters.Add(("IntPtr", "selector", ""));
                for (var i = 0; i < item.Inputs.Length; i++)
                {
                    var attr = "";
                    if (item.Inputs[i] == "bool")
                    {
                        attr = "[MarshalAs(UnmanagedType.Bool)]";
                    }
                    parameters.Add((item.Inputs[i], VarNames[i], attr));
                }
                var method = new CSharpMethod(name, item.Type, parameters);
                method.IsStatic = true;
                method.IsPartial = true;
                method.VisibilityModifier = "internal";
                method.AddAttribute("[LibraryImport(ObjectiveC.ObjCRuntime, EntryPoint = \"objc_msgSend\")]");
                if (item.Type == "bool")
                {
                    method.AddAttribute("[return: MarshalAs(UnmanagedType.Bool)]");
                }

                csClass.AddMember(method);

            }

            return outputFile;

            static int ObjectiveCEmitOrderComparer(ObjectiveCInstance x, ObjectiveCInstance y)
            {
                var typeComparison = string.Compare(x.Type, y.Type, StringComparison.InvariantCultureIgnoreCase);
                if (typeComparison != 0)
                {
                    return typeComparison;
                }

                var lengthComparison = x.Inputs.Length.CompareTo(y.Inputs.Length);
                if (lengthComparison != 0)
                {
                    return lengthComparison;
                }

                var xInputs = string.Join(" ", x.Inputs);
                var yInputs = string.Join(" ", y.Inputs);
                return string.Compare(xInputs, yInputs, StringComparison.InvariantCultureIgnoreCase);
            }
        }

        private static void AddUsings(CSharpFile outputFile, HeaderInfo headerInfo)
        {
            // This is probably quite slow, but it works.
            // These need Marshal.UnsafeAddrOfPinnedArrayElement
            if (headerInfo.ClassInstances
                .SelectMany(c => c.MethodInstances)
                .SelectMany(m => m.InputInstances)
                .Any(i => i.Array))
            {
                outputFile.AddUsing("System.Runtime.InteropServices");
            }

            if (headerInfo.StructInstances.Count != 0)
            {
                outputFile.AddUsing("System.Runtime.InteropServices");
            }

            if (headerInfo.StructInstances.Count != 0 || headerInfo.ClassInstances.Count != 0 || headerInfo.EnumInstances.Count != 0)
            {
                outputFile.AddUsing("System.Runtime.Versioning");
            }

            // If have any class in the file, we need selectors due to ctors/disposes
            if (headerInfo.ClassInstances.Count != 0)
            {
                outputFile.AddUsing("SharpMetal.ObjectiveCCore");
            }

            if (headerInfo.Flags != IncludeFlags.None)
            {
                if ((headerInfo.Flags & IncludeFlags.Foundation) == IncludeFlags.Foundation)
                {
                    if (outputFile.Directory != "Foundation")
                    {
                        outputFile.AddUsing("SharpMetal.Foundation");
                    }
                }

                if ((headerInfo.Flags & IncludeFlags.Metal) == IncludeFlags.Metal)
                {
                    if (outputFile.Directory != "Metal")
                    {
                        outputFile.AddUsing("SharpMetal.Metal");
                    }
                }

                if ((headerInfo.Flags & IncludeFlags.QuartzCore) == IncludeFlags.QuartzCore)
                {
                    if (outputFile.Directory != "QuartzCore")
                    {
                        outputFile.AddUsing("SharpMetal.QuartzCore");
                    }
                }
            }
        }
    }
}
