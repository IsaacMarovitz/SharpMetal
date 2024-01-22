using SharpMetal.Generator.Instances.Class;
using SharpMetal.Generator.Instances.Enums;
using SharpMetal.Generator.Instances.Struct;

namespace SharpMetal.Generator.Instances.Header
{
    public class HeaderInstance : IInstance
    {
        /// <summary>
        /// Defines all classes available in this header.
        /// </summary>
        public ClassInstance[] ClassInstances;
        /// <summary>
        /// Defines all enums available in this header.
        /// </summary>
        public EnumInstance[] EnumInstances;
        /// <summary>
        /// Defines all structs available in this header.
        /// </summary>
        public StructInstance[] StructInstances;
        /// <summary>
        /// Defines the name of the header.
        /// This will be used to generate the final file name.
        /// </summary>
        public string InstanceName { get; set; }
        /// <summary>
        /// Defines in which SDKs this header is available.
        /// This property is unused.
        /// </summary>
        public Compatability Compatability { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="headerName">Name of the header.</param>
        /// <param name="classes">Array of all classes available in this header.</param>
        /// <param name="enums">Array of all enums available in this header.</param>
        /// <param name="structs">Array of all structs available in this header.</param>
        public HeaderInstance(
            string headerName,
            ClassInstance[] classes,
            EnumInstance[] enums,
            StructInstance[] structs)
        {
            InstanceName = headerName;
            ClassInstances = classes;
            EnumInstances = enums;
            StructInstances = structs;
        }

        /// <summary>
        /// Generate C# code from the given header instance.
        /// </summary>
        /// <param name="context">The context in which to write code.</param>
        /// <exception cref="NotImplementedException">Not yet implemented.</exception>
        public void Generate(CodeGenContext context)
        {
            throw new NotImplementedException();
        }
    }
}
