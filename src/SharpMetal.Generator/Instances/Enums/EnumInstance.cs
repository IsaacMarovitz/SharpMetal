namespace SharpMetal.Generator.Instances.Enums
{
    public class EnumInstance : Instance
    {
        public EnumValue[] Values;
        /// <summary>
        /// Is this enum a bitflag? Will be generated in C# with the <c>[Flags]</c> attribute.
        /// </summary>
        public bool IsFlags;

        public EnumInstance(string enumName, EnumValue[] values, bool isFlags)
        {
            InstanceName = enumName;
            Values = values;
            IsFlags = isFlags;
        }
    }
}
