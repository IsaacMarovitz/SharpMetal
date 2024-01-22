using SharpMetal.Generator.Instances.Property;

namespace SharpMetal.Generator.Instances.Struct
{
    public class StructInstance : IInstance
    {
        public PropertyInstance[] Properties;
        public string InstanceName { get; set; }
        public Compatability Compatability { get; set; }

        public StructInstance(string structName, bool isProtocol, PropertyInstance[] properties)
        {
            InstanceName = structName;
            Properties = properties;
        }

        public void Generate(CodeGenContext context)
        {
            throw new NotImplementedException();
        }
    }
}
