namespace SharpMetal.Generator.Instances.Enums
{
    public class EnumInstance : IInstance
    {
        /// <summary>
        /// Defines all values available in this enum.
        /// </summary>
        public EnumValue[] Values;
        /// <summary>
        /// Is this enum a bitflag? Will be generated in C# with the <c>[Flags]</c> attribute.
        /// </summary>
        public bool IsFlags;
        /// <summary>
        /// Defines the name of the enum.
        /// </summary>
        public string InstanceName { get; set; }
        /// <summary>
        /// Defines in which SDKs this enum is available.
        /// </summary>
        public Compatability Compatability { get; set; }
        public Documentation Documentation { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="enumName">Name of the enum.</param>
        /// <param name="values">Array of all values available in this enum.</param>
        /// <param name="isFlags">True if the enum is a flag set.</param>
        public EnumInstance(string enumName, EnumValue[] values, bool isFlags)
        {
            InstanceName = enumName;
            Values = values;
            IsFlags = isFlags;
        }

        /// <summary>
        /// Generate C# code from the given enum instance.
        /// </summary>
        /// <param name="context">The context in which to write code.</param>
        /// <exception cref="NotImplementedException">Not yet implemented.</exception>
        public void Generate(CodeGenContext context)
        {
            throw new NotImplementedException();
        }
    }
}
