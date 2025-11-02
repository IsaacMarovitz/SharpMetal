namespace SharpMetal.Generator.CSharpCodeGen
{
    public class CSharpEnumValue(string name) : CSharpTypeMember(name, MemberKind.Field)
    {
        public string? DefaultValue { get; set; }

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
