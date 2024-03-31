using CppAst;
using SharpMetal.Generator.Utilities;

namespace SharpMetal.Generator.Instances
{
    public class FieldInstance
    {
        private CppField _cppField;

        public FieldInstance(CppField cppField)
        {
            _cppField = cppField;
        }

        public void Generate(CodeGenContext context)
        {
            var type = StringUtils.TypeToString(_cppField.Type);
            var name = StringUtils.CamelToPascale(_cppField.Name);

            foreach (var attribute in type.Attributes)
            {
                context.WriteLine(attribute);
            }

            context.WriteLine($"{StringUtils.VisibilityToString(_cppField.Visibility)} {type.Type} {name};");
        }
    }
}
