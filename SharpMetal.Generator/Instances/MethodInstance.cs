using System.Text.RegularExpressions;

namespace SharpMetal.Generator.Instances
{
    public class MethodInstance
    {
        public string ReturnType;
        public string Name;
        public List<PropertyInstance> InputInstances;

        private MethodInstance(string returnType, string name, List<PropertyInstance> inputInstances)
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

        public static MethodInstance BuildMethod(List<string> parts, string namespacePrefix)
        {
            string methodName = parts[1].Substring(0, parts[1].IndexOf("("));
            string inputsString = parts[1].Replace(methodName, "").Replace("(", "").Replace(")", "");

            var inputs = inputsString.Split(",", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

            var inputsList = new List<PropertyInstance>();

            foreach (var input in inputs)
            {
                var inputInfo = input.Split(" ", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

                if (inputInfo.Length != 2)
                {
                    Console.WriteLine($"Couldn't find an object type and name from \"{input}\"");
                    continue;
                }

                var name = inputInfo[1];
                var type = Types.ConvertType(inputInfo[0], namespacePrefix);

                if (name.Contains("[]"))
                {
                    name = name.Replace("[]", "");
                    type += "[]";
                }

                // String is a keyword in C#
                if (name == "string")
                {
                    name = "nsString";
                }

                // Event is a keyword in C#
                if (name == "event")
                {
                    name = "mltEvent";
                }

                inputsList.Add(new PropertyInstance(type, name));
            }

            methodName = Regex.Replace(methodName, @"\b\p{Ll}", match => match.Value.ToUpper());
            string returnType = Types.ConvertType(parts[0], namespacePrefix);

            return new MethodInstance(returnType, methodName, inputsList);
        }
    }
}