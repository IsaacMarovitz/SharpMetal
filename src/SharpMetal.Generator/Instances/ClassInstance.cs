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

        public void Generate(CodeGenContext context)
        {
            // We don't want to generate code for templates
            if (_cppClass.TemplateKind != CppTemplateKind.NormalClass)
            {
                return;
            }

            var name = _cppClass.Name;

            context.WriteLine("[SupportedOSPlatform(\"macos\")]");

            var classDecl = $"public struct {name}";

            context.WriteLine(classDecl);

            context.EnterScope();

            context.WriteLine("public IntPtr NativePtr;");
            context.WriteLine($"public static implicit operator IntPtr({name} obj) => obj.NativePtr;");
            context.WriteLine($"public {name}(IntPtr ptr) => NativePtr = ptr;");

            foreach (var field in _cppClass.Fields)
            {
                var fieldInstance = new FieldInstance(field);
                fieldInstance.Generate(context);
            }

            foreach (var function in _cppClass.Functions)
            {
                var functionInstance = new FunctionInstance(function);
                functionInstance.Generate(context);
            }

            context.LeaveScope();
        }
    }
}
