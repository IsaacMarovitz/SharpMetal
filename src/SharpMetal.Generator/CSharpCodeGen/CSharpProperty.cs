namespace SharpMetal.Generator.CSharpCodeGen
{
    public class CSharpProperty(string name, string type) : CSharpTypeMember(name, MemberKind.Property)
    {
        public bool IsStatic { get; set; }
        public string Type { get; } = type;
        public string? Getter { get; set; }
        public string? Setter { get; set; }

        public override void Generate(CodeGenContext context)
        {
            foreach (var attribute in Attributes)
            {
                context.WriteLine(attribute);
            }

            var sb = context.AcquireTempStringBuilder();
            sb.Append(VisibilityModifier);

            if (IsStatic)
            {
                sb.Append(" static");
            }

            sb.Append(' ');
            sb.Append(Type);
            sb.Append(' ');
            sb.Append(Name);

            if (string.IsNullOrEmpty(Setter))
            {
                sb.Append(" => ");
                sb.Append(Getter);
                sb.Append(';');
                context.WriteLine(sb.ToString());
            }
            else
            {
                context.WriteLine(sb.ToString());
                context.EnterScope();
                context.WriteLine($"get => {Getter};");
                context.WriteLine($"set => {Setter};");
                context.LeaveScope();
            }

            context.ReleaseTempStringBuilder(sb);
        }
    }
}
