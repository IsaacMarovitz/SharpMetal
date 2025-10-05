namespace SharpMetal.Generator.CSharpCodeGen
{
    public class CSharpField : CSharpTypeMember
    {
        public string VariableType { get; private set; }
        public string? DefaultValue { get; set; }
        public bool IsStatic { get; set; }
        public bool IsReadonly { get; set; }

        public CSharpField(string variableType, string name) : base(name, MemberKind.Field)
        {
            VariableType = variableType;
        }

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
