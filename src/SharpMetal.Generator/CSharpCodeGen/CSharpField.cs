namespace SharpMetal.Generator.CSharpCodeGen
{
    public class CSharpField(string variableType, string name) : CSharpTypeMember(name, MemberKind.Field)
    {
        public string VariableType { get; } = variableType;
        public string? DefaultValue { get; set; }
        public bool IsStatic { get; set; }
        public bool IsReadonly { get; set; }

        public override void Generate(CodeGenContext context)
        {
            var sb = context.AcquireTempStringBuilder();
            sb.Append(VisibilityModifier);
            if (IsStatic)
            {
                sb.Append(" static");
            }

            if (IsReadonly)
            {
                sb.Append(" readonly");
            }

            sb.Append(' ');
            sb.Append(VariableType);
            sb.Append(' ');
            sb.Append(Name);
            if (DefaultValue != null)
            {
                sb.Append($" = {DefaultValue}");
            }

            context.WriteLine($"{sb.ToString().Trim()};");
            context.ReleaseTempStringBuilder(sb);
        }
    }
}
