namespace SharpMetal.Generator.Instances
{
    public class MethodInstance
    {
        public string ReturnType;
        public string Name;
        public string RawName;
        public bool IsStatic;
        public bool Unscoped;
        public List<PropertyInstance> InputInstances;

        public MethodInstance(string returnType, string name, string rawName, bool isStatic, bool unscoped, List<PropertyInstance> inputInstances)
        {
            ReturnType = returnType;
            Name = name;
            RawName = rawName;
            IsStatic = isStatic;
            Unscoped = unscoped;
            InputInstances = inputInstances;
        }
    }
}
