namespace SharpMetal.Generator.Instances.Method
{
    public class MethodInstance : IInstance
    {
        public string ReturnType;
        public string Selector;
        public MethodInputInstance[] Inputs;
        public string InstanceName { get; set; }
        public Compatability Compatability { get; set; }

        public MethodInstance(string methodName, string returnType, string selector, MethodInputInstance[] inputs)
        {
            InstanceName = methodName;
            ReturnType = returnType;
            Selector = selector;
            Inputs = inputs;
        }

        public void Generate(CodeGenContext context)
        {
            throw new NotImplementedException();
        }
    }
}
