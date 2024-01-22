namespace SharpMetal.Generator.Instances.Method
{
    public class MethodInputInstance : Instance
    {
        public string Type;
        public bool IsPointer;

        public MethodInputInstance(string inputName, string type, bool isPointer)
        {
            InstanceName = inputName;
            Type = type;
            IsPointer = isPointer;
        }
    }
}
