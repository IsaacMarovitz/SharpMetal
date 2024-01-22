namespace SharpMetal.Generator.Instances.Method
{
    public class MethodInputInstance : IInstance
    {
        /// <summary>
        /// The type of the method input.
        /// Must be a valid C# type or a generated type.
        /// </summary>
        public string Type;
        /// <summary>
        /// Defines whether or not this method input is a pointer type.
        /// If it is, this will be taken into account when generating the
        /// method signature.
        /// </summary>
        public bool IsPointer;
        /// <summary>
        /// Defines the name of the method input.
        /// </summary>
        public string InstanceName { get; set; }
        /// <summary>
        /// Defines in which SDKs this method input is available.
        /// </summary>
        public Compatability Compatability { get; set; }
        public Documentation Documentation { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="inputName">The name of the method input.</param>
        /// <param name="type">The type of the method input.</param>
        /// <param name="isPointer">True if value is a pointer.</param>
        public MethodInputInstance(string inputName, string type, bool isPointer)
        {
            InstanceName = inputName;
            Type = type;
            IsPointer = isPointer;
        }

        /// <summary>
        /// Generate C# code from the given method input instance.
        /// </summary>
        /// <param name="context">The context in which to write code.</param>
        /// <exception cref="NotImplementedException">Not yet implemented.</exception>
        public void Generate(CodeGenContext context)
        {
            throw new NotImplementedException();
        }
    }
}
