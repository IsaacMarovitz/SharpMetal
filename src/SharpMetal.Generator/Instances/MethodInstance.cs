namespace SharpMetal.Generator.Instances
{
    public class MethodInstance
    {
        public readonly string Name;
        public readonly List<FunctionParameterInstance> InputInstances;

        public string ReturnType { get; }
        public bool IsStatic { get; }
        public string RawName { get; }
        public bool IsDeprecated { get; }

        public MethodInstance(string returnType, string name, string rawName, bool isStatic, bool isDeprecated, List<FunctionParameterInstance> inputInstances)
        {
            Name = name;
            InputInstances = inputInstances;

            ReturnType = returnType;
            IsStatic = isStatic;
            IsDeprecated = isDeprecated;

            var rawNameComponents = rawName.Split(" ", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

            foreach (var component in rawNameComponents)
            {
                if (component.Contains('('))
                {
                    var splitIndex = rawName.IndexOf(component, StringComparison.Ordinal);
                    if (splitIndex >= 0)
                    {
                        rawName = rawName.Substring(splitIndex, rawName.Length - splitIndex);
                    }
                }
            }

            RawName = rawName.TrimEnd(';');
        }
    }
}
