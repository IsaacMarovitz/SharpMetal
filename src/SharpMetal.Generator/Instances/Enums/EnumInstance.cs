namespace SharpMetal.Generator.Instances.Enums
{
    public class EnumInstance : IInstance
    {
        public EnumValue[] Values;
        /// <summary>
        /// Is this enum a bitflag? Will be generated in C# with the <c>[Flags]</c> attribute.
        /// </summary>
        public bool IsFlags;
        public string InstanceName { get; set; }
        public Compatability Compatability { get; set; }

        public EnumInstance(string enumName, EnumValue[] values, bool isFlags)
        {
            InstanceName = enumName;
            Values = values;
            IsFlags = isFlags;
        }

        public void Generate(CodeGenContext context)
        {
            throw new NotImplementedException();
        }
    }
}
