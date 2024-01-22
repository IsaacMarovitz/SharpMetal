namespace SharpMetal.Generator.Instances.Method
{
    public class MethodInstance : IInstance
    {
        /// <summary>
        /// Defines the return type of the method.
        /// Must be a valid C# type or a generated type.
        /// </summary>
        public string ReturnType;
        /// <summary>
        /// Defines the selector for this method that will be used
        /// to invoke it from Objective-C.
        /// </summary>
        public string Selector;
        /// <summary>
        /// Defines the inputs for this method.
        /// </summary>
        public MethodInputInstance[] Inputs;
        /// <summary>
        /// Defines the name of this method.
        /// </summary>
        public string InstanceName { get; set; }
        /// <summary>
        /// Defines in which SDKs this method is available.
        /// </summary>
        public Compatability Compatability { get; set; }
        public Documentation Documentation { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="methodName">The name of the method.</param>
        /// <param name="returnType">The return type of the method.</param>
        /// <param name="selector">The selector of the method.</param>
        /// <param name="inputs">The inputs of this method.</param>
        public MethodInstance(string methodName, string returnType, string selector, MethodInputInstance[] inputs)
        {
            InstanceName = methodName;
            ReturnType = returnType;
            Selector = selector;
            Inputs = inputs;
        }

        /// <summary>
        /// Generate C# code from the given method instance.
        /// </summary>
        /// <param name="context">The context in which to write code.</param>
        /// <exception cref="NotImplementedException">Not yet implemented.</exception>
        public void Generate(CodeGenContext context)
        {
            throw new NotImplementedException();
        }
    }
}
