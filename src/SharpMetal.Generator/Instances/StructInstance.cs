using CppAst;
using SharpMetal.Generator.Utilities;

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
                var type = StringUtils.TypeToString(field.Type);

                foreach (var attribute in type.Attributes)
                {
                    context.WriteLine(attribute);
                }

                context.WriteLine($"{StringUtils.VisibilityToString(field.Visibility)} {type.Type} {field.Name};");
            }

            context.LeaveScope();
        }
    }
}
