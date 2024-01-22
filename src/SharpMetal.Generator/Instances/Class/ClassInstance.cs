using SharpMetal.Generator.Instances.Property;

namespace SharpMetal.Generator.Instances.Class
{
    /// <summary>
    /// Defines an instance of an Objective-C Protocol or Class.
    /// </summary>
    public class ClassInstance : IInstance
    {
        /// <summary>
        /// This defines whether this class is based on an Objective-C Protocol or a Class.
        /// Classes are final, Protocols are inheritable.
        /// </summary>
        public bool IsProtocol;
        public PropertyInstance[] Properties;
        public string InstanceName { get; set; }
        public Compatability Compatability { get; set; }

        public ClassInstance(string className, bool isProtocol, PropertyInstance[] properties)
        {
            InstanceName = className;
            IsProtocol = isProtocol;
            Properties = properties;
        }

        public void Generate(CodeGenContext context)
        {
            throw new NotImplementedException();
        }
    }
}
