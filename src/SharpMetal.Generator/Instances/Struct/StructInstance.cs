using SharpMetal.Generator.Instances.Method;
using SharpMetal.Generator.Instances.Property;

namespace SharpMetal.Generator.Instances.Struct
{
    public class StructInstance : IInstance
    {
        /// <summary>
        /// Defines all properties available in this class.
        /// </summary>
        public PropertyInstance[] Properties;
        /// <summary>
        /// Defines all methods available in this class.
        /// </summary>
        public MethodInstance[] Methods;
        /// <summary>
        /// Defines the name of the struct.
        /// </summary>
        public string InstanceName { get; set; }
        /// <summary>
        /// Generate C# code from the given struct instance.
        /// </summary>
        /// <param name="context">The context in which to write code.</param>
        /// <exception cref="NotImplementedException">Not yet implemented.</exception>
        public Compatability Compatability { get; set; }
        public Documentation Documentation { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="structName">The name of the struct.</param>
        /// <param name="properties">The properties on this struct.</param>
        /// <param name="methods">The methods on this struct.</param>
        public StructInstance(string structName, PropertyInstance[] properties, MethodInstance[] methods)
        {
            InstanceName = structName;
            Properties = properties;
            Methods = methods;
        }

        /// <summary>
        /// Generate C# code from the given struct instance.
        /// </summary>
        /// <param name="context">The context in which to write code.</param>
        /// <exception cref="NotImplementedException">Not yet implemented.</exception>
        public void Generate(CodeGenContext context)
        {
            throw new NotImplementedException();
        }
    }
}
