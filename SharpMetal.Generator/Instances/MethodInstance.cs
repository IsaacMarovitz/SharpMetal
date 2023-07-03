using System.Text.RegularExpressions;
using SharpMetal.Generator.Utilities;

namespace SharpMetal.Generator.Instances
{
    public class MethodInstance
    {
        public string ReturnType;
        public string Name;
        public List<PropertyInstance> InputInstances;

        public MethodInstance(string returnType, string name, List<PropertyInstance> inputInstances)
        {
            ReturnType = returnType;
            Name = name;
            InputInstances = inputInstances;
        }

        public void Generate(CodeGenContext context)
        {
            context.WriteLine();
            context.Write(context.Indentation + $"public {ReturnType} {Name}(");

            for (var i = 0; i < InputInstances.Count; i++)
            {
                var input = InputInstances[i];

                context.Write($"{input.Type} {input.Name}");

                if (i != InputInstances.Count - 1)
                {
                    context.Write(", ");
                }
            }

            context.Write(")\n");
            context.EnterScope();
            context.WriteLine("throw new NotImplementedException();");
            context.LeaveScope();
        }
    }
}