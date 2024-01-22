namespace SharpMetal.Generator.Instances.Enums
{
    public class EnumValue : IInstance
    {
        public string Value;
        /// <summary>
        /// Defines if this value is calculated as bitwise value.
        /// If it is, it will be generated in C# with the base value defined in <c>Value</c>,
        /// the shift direction defined by <c>ShiftRight</c>, and the shift value defined by <c>ShiftValue</c>.
        /// </summary>
        public bool IsBitwise;
        public bool ShiftRight;
        public int ShiftValue;
        public string InstanceName { get; set; }
        public Compatability Compatability { get; set; }

        public EnumValue(string valueName, string value)
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
            Value = value.ToString();
            IsBitwise = true;
            ShiftRight = shiftRight;
            ShiftValue = shiftValue;
        }

        public void Generate(CodeGenContext context)
        {
            throw new NotImplementedException();
        }
    }
}
