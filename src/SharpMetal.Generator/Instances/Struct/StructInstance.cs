namespace SharpMetal.Generator.Instances.Struct
{
    public class StructInstance : Instance
    {
        public PropertyInstance[] Properties;

        public StructInstance(string structName, bool isProtocol, PropertyInstance[] properties)
        {
            InstanceName = structName;
            Properties = properties;
        }
    }
}
