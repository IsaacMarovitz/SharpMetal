namespace SharpMetal.Generator.Linked
{
    public class CSharpField : CSharpTypeMember
    {
        public string VariableType { get; private set; }

        public string? DefaultValue { get; set; }

        public CSharpField(string variableType, string name): base(name, MemberKind.Field)
        {
            VariableType = variableType;
        }

        public override void Generate(CodeGenContext context)
        {
            var fieldLine = $"{VisibilityModifier} {VariableType} {Name}";
            if (DefaultValue != null)
            {
                fieldLine = $"{fieldLine} = {DefaultValue}";
            }
            context.WriteLine($"{fieldLine.Trim()};");
        }
    }
}
