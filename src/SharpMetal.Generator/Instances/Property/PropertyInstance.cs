namespace SharpMetal.Generator.Instances.Property
{
    public class PropertyInstance : IInstance
    {
        /// <summary>
        /// Defines the type of this property.
        /// Must be a valid C# type or a generated type.
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

        /// <summary>
        /// A custom read selector.
        /// If not set, default <c>property:</c> format will be used.
        /// </summary>
        public string? ReadSelector;
        /// <summary>
        /// A custom write selector.
        /// If not set, default <c>setProperty:</c> format will be used.
        /// </summary>
        public string? WriteSelector;

        /// <summary>
        /// The name of the property instance.
        /// </summary>
        public string InstanceName { get; set; }
        /// <summary>
        /// Defines in which SDKs this property is available.
        /// </summary>
        public Compatability Compatability { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="name">The name of the property.</param>
        /// <param name="type">The type of the property.</param>
        /// <param name="isNullable">Is this property nullable?</param>
        /// <param name="isReadonly">Is this property readonly?</param>
        /// <param name="readSelector">Custom selector for property read.</param>
        /// <param name="writeSelector">Custom selector for property write.</param>
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

        /// <summary>
        /// Generate C# code from the given property instance.
        /// </summary>
        /// <param name="context">The context in which to write code.</param>
        /// <exception cref="NotImplementedException">Not yet implemented.</exception>
        public void Generate(CodeGenContext context)
        {
            throw new NotImplementedException();
        }
    }
}
