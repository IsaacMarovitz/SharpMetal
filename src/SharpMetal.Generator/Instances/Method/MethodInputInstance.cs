namespace SharpMetal.Generator.Instances.Method
{
    public class MethodInputInstance : IInstance
    {
        public string Type;
        public bool IsPointer;
        public string InstanceName { get; set; }
        public Compatability Compatability { get; set; }

        public MethodInputInstance(string inputName, string type, bool isPointer)
        {
            InstanceName = inputName;
            Type = type;
            IsPointer = isPointer;
        }

        public void Generate(CodeGenContext context)
        {
            throw new NotImplementedException();
        }
    }
}
