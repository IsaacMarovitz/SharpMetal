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
            signature += $"{name}()";

            context.WriteLine(signature);
            context.EnterScope();
            context.LeaveScope();
        }
    }
}
