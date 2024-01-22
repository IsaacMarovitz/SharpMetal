namespace SharpMetal.Generator.Instances.Enums
{
    public class EnumValue : IInstance
    {
        /// <summary>
        /// The base value of this enum value.
        /// If <c>IsBitwise</c> is true, this will be the base value that gets shifted.
        /// </summary>
        public int Value;
        /// <summary>
        /// Defines if this value is calculated as bitwise value.
        /// If it is, it will be generated in C# with the base value defined in <c>Value</c>,
        /// the shift direction defined by <c>ShiftRight</c>, and the shift value defined by <c>ShiftValue</c>.
        /// </summary>
        public bool IsBitwise;
        /// <summary>
        /// True if shift direction is right.
        /// Ignored if <c>IsBitwise</c> is false.
        /// </summary>
        public bool ShiftRight;
        /// <summary>
        /// The amount with which to shift the base value.
        /// Ignored if <c>IsBitwise</c> is false.
        /// </summary>
        public int ShiftValue;
        /// <summary>
        /// Defines the name of the value.
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
        /// <param name="valueName">The name of the value.</param>
        /// <param name="value">The integer value of the value.</param>
        public EnumValue(string valueName, int value)
        {
            InstanceName = valueName;
            Value = value;
            IsBitwise = false;
        }

        /// <summary>
        /// Constructor for a bitwise enum value.
        /// </summary>
        /// <param name="valueName">The name of the value.</param>
        /// <param name="value">The integer base value being shifted.</param>
        /// <param name="shiftRight">The direction with which to shift.</param>
        /// <param name="shiftValue">The amount with which to shift.</param>
        public EnumValue(string valueName, int value, bool shiftRight, int shiftValue)
        {
            InstanceName = valueName;
            Value = value;
            IsBitwise = true;
            ShiftRight = shiftRight;
            ShiftValue = shiftValue;
        }

        /// <summary>
        /// Generate C# code from the given enum value instance.
        /// </summary>
        /// <param name="context">The context in which to write code.</param>
        /// <exception cref="NotImplementedException">Not yet implemented.</exception>
        public void Generate(CodeGenContext context)
        {
            throw new NotImplementedException();
        }
    }
}
