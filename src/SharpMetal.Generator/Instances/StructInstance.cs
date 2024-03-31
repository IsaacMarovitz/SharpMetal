using CppAst;

namespace SharpMetal.Generator.Instances
{
    public class StructInstance
    {
        private CppClass _cppClass;

        public StructInstance(CppClass cppClass)
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

            context.WriteLine("[SupportedOSPlatform(\"macos\")]");
            context.WriteLine("[StructLayout(LayoutKind.Sequential)]");

            context.WriteLine($"public struct {_cppClass.Name}");
            context.EnterScope();

            foreach (var field in _cppClass.Fields)
            {
                var fieldInstance = new FieldInstance(field);
                fieldInstance.Generate(context);
            }

            context.LeaveScope();
        }
    }
}
