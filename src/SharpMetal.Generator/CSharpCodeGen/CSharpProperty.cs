namespace SharpMetal.Generator.CSharpCodeGen
{
    public class CSharpProperty : CSharpTypeMember
    {
        public bool IsStatic { get; set; }
        public string Type { get; private set; }
        public string? Getter { get; set; }
        public string? Setter { get; set; }

        public CSharpProperty(string name, string type) : base(name, MemberKind.Property)
        {
            Type = type;
        }

        public override void Generate(CodeGenContext context)
        {
            foreach (var attribute in _attributes)
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
