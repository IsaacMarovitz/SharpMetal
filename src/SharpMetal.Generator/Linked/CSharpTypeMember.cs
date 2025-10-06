namespace SharpMetal.Generator.Linked
{
    public enum MemberKind
    {
        Field,
        Property,
        Method,
    }

    public abstract class CSharpTypeMember : ICodeFragmentProvider
    {
        public string Name { get; private set; }

        public string VisibilityModifier { get; set; } = "public";

        public MemberKind Kind { get; private set; }

        public CSharpTypeMember(string name, MemberKind kind)
        {
            Name = name;
            Kind = kind;
        }

        public abstract void Generate(CodeGenContext context);
    }
}
