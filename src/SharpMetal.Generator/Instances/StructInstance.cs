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
            context.WriteLine("[SupportedOSPlatform(\"macos\")]");
            context.WriteLine("[StructLayout(LayoutKind.Sequential)]");

            context.WriteLine($"public struct {_cppClass.Name}");
            context.EnterScope();

            foreach (var field in _cppClass.Fields)
            {
                context.WriteLine($"{VisibilityStringise.VisibilityAsString(field.Visibility)} {field.Type} {field.Name};");
            }

            context.LeaveScope();
        }
    }
}
