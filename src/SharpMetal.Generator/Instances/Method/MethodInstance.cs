namespace SharpMetal.Generator.Instances.Method
{
    public class MethodInstance : Instance
    {
        public string ReturnType;
        public string Selector;
        public MethodInputInstance[] Inputs;

        public MethodInstance(string methodName, string returnType, string selector, MethodInputInstance[] inputs)
        {
            InstanceName = methodName;
            ReturnType = returnType;
            Selector = selector;
            Inputs = inputs;
        }
    }
}
