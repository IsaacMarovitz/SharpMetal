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
        /// <summary>
        /// Defines all properties available in this class.
        /// </summary>
        public PropertyInstance[] Properties;
        /// <summary>
        /// Defines the name of the class.
        /// </summary>
        public string InstanceName { get; set; }
        /// <summary>
        /// Defines in which SDKs this class is available.
        /// </summary>
        public Compatability Compatability { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="className">Name of the class.</param>
        /// <param name="isProtocol">True if the class is an Objective-C Protocol.</param>
        /// <param name="properties">Array of all properties available in this class.</param>
        public ClassInstance(string className, bool isProtocol, PropertyInstance[] properties)
        {
            InstanceName = className;
            IsProtocol = isProtocol;
            Properties = properties;
        }

        /// <summary>
        /// Generate C# code from the given class instance.
        /// </summary>
        /// <param name="context">The context in which to write code.</param>
        /// <exception cref="NotImplementedException">Not yet implemented.</exception>
        public void Generate(CodeGenContext context)
        {
            throw new NotImplementedException();
        }
    }
}
