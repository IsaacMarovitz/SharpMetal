using CppAst;
using SharpMetal.Generator.Utilities;

namespace SharpMetal.Generator.Instances
{
    public class FunctionInstance
    {
        private CppFunction _cppFunction;

        public FunctionInstance(CppFunction cppFunction)
        {
            _cppFunction = cppFunction;
        }

        public void Generate(CodeGenContext context)
        {
            var returnType = StringUtils.TypeToString(_cppFunction.ReturnType).Type;
            var visibility = StringUtils.VisibilityToString(_cppFunction.Visibility);
            var name = StringUtils.CamelToPascale(_cppFunction.Name);

            var signature = $"{visibility} ";
            signature += _cppFunction.IsStatic ? "static " : "";
            signature += $"{returnType} ";
            signature += $"{name}(";

            for (var i = 0; i < _cppFunction.Parameters.Count; i++)
            {
                var parameter = _cppFunction.Parameters[i];
                var parameterType = StringUtils.TypeToString(parameter.Type).Type;
                var parameterName = parameter.Name;
                signature += $"{parameterType} {parameterName}";

                if (i != _cppFunction.Parameters.Count - 1)
                {
                    signature += ", ";
                }
            }

            signature += ")";

            context.WriteLine(signature);
            context.EnterScope();
            context.LeaveScope();
        }
    }
}
