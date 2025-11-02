namespace SharpMetal.Generator.CSharpCodeGen
{
    public class CSharpEnumValue : CSharpTypeMember
    {
        public string? DefaultValue { get; set; }

        public CSharpEnumValue(string name) : base(name, MemberKind.Field)
        {
        }

        public override void Generate(CodeGenContext context)
        {
            if (DefaultValue != null)
            {
                context.WriteLine($"{Name} = {DefaultValue},");
            }
            else
            {
                context.WriteLine($"{Name},");
            }
        }
    }
}
