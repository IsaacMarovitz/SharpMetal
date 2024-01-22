namespace SharpMetal.Generator.Instances
{
    public class PropertyInstance : Instance
    {
        /// <summary>
        /// A string that defines the type that this property represents.
        /// </summary>
        public string Type;
        /// <summary>
        /// Can this property be null? If so, it will be generated in C# with a nullable operator.
        /// </summary>
        public bool Nullable;
        /// <summary>
        /// Is this property read-only?
        /// </summary>
        public bool Readonly;

        public string? ReadSelector;
        public string? WriteSelector;

        public PropertyInstance(
            string name,
            string type,
            bool isNullable,
            bool isReadonly,
            string? readSelector = null,
            string? writeSelector = null)
        {
            InstanceName = name;
            Type = type;
            Nullable = isNullable;
            Readonly = isReadonly;
            ReadSelector = readSelector;
            WriteSelector = writeSelector;
        }
    }
}
