using CppAst;

namespace SharpMetal.Generator.Instances
{
    public class ClassInstance
    {
        private CppClass _cppClass;

        public ClassInstance(CppClass cppClass)
        {
            _cppClass = cppClass;
        }

        public List<ObjectiveCInstance> Generate(CodeGenContext context)
        {
            // if (_parent != string.Empty)
            // {
            //     // To properly fit within expected C# patterns, we
            //     // should generate an interface to hold the associated
            //     // properties and methods to allow for proper casting
            //     // between types. Right now, due to the limitations of
            //     // struct inheritance, we will just duplicate all
            //     // properties and methods from the parent to the child.
            //     // This limitation is not present with the old method
            //     // using classes, however that comes with performance
            //     // and memory drawbacks, that structs are able to avoid.
            //
            //     var parent = classCache.FirstOrDefault(x => x.Name == _parent);
            //     _propertyInstances.AddRange(parent.PropertyInstances);
            //     _methodInstances.AddRange(parent.MethodInstances);
            //     _selectorInstances.AddRange(parent.SelectorInstances);
            // }

            var objectiveCInstances = new List<ObjectiveCInstance>();
            var name = _cppClass.Name;

            context.WriteLine("[SupportedOSPlatform(\"macos\")]");

            // TODO: Handle LibraryImport usage on MTLDevice (requires partial)
            var classDecl = $"public struct {name}";

            context.WriteLine(classDecl);

            context.EnterScope();

            context.WriteLine("public IntPtr NativePtr;");
            context.WriteLine($"public static implicit operator IntPtr({name} obj) => obj.NativePtr;");
            // if (_parent != string.Empty)
            // {
            //     context.WriteLine($"public static implicit operator {_parent}({name} obj) => new(obj.NativePtr);");
            // }
            context.WriteLine($"public {name}(IntPtr ptr) => NativePtr = ptr;");

            //_cppClass.Functions.Where(x => x.Attributes.Contains(CppAttribute))
            // if (HasAlloc)
            // {
            //     context.WriteLine();
            //     context.WriteLine($"public {name}()");
            //     context.EnterScope();
            //
            //     context.WriteLine($"var cls = new ObjectiveCClass(\"{name}\");");
            //
            //     if (HasInit)
            //     {
            //         context.WriteLine("NativePtr = cls.AllocInit();");
            //     }
            //     else
            //     {
            //         context.WriteLine("NativePtr = cls.Alloc();");
            //     }
            //
            //     context.LeaveScope();
            // }

            // if (_propertyInstances.Any())
            // {
            //     context.WriteLine();
            // }
            //
            // var selectorInstances = new List<SelectorInstance>(_selectorInstances);
            //
            // for (var j = 0; j < _propertyInstances.Count; j++)
            // {
            //     //objectiveCInstances.Add(_propertyInstances[j].Generate(selectorInstances, enumCache, structCache, context));
            //
            //     if (j != _propertyInstances.Count - 1)
            //     {
            //         context.WriteLine();
            //     }
            // }
            //
            // foreach (var method in _methodInstances)
            // {
            //     //objectiveCInstances.Add(method.Generate(selectorInstances, enumCache, structCache, context, NamespacePrefix));
            // }
            //
            // if (_selectorInstances.Any())
            // {
            //     context.WriteLine();
            // }
            //
            // foreach (var selector in _selectorInstances)
            // {
            //     context.WriteLine($"private static readonly Selector {selector.Name} = \"{selector.Selector}\";");
            // }

            context.LeaveScope();
            return objectiveCInstances;
        }
    }
}
