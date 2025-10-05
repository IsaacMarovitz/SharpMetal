namespace SharpMetal.Generator.CSharpCodeGen
{
    public enum MemberKind
    {
        Field,
        Property,
        Method,
    }

    public abstract class CSharpTypeMember : ICodeFragmentProvider
    {
        protected readonly List<string> _attributes = [];

        public string Name { get; }
        public string VisibilityModifier { get; set; } = "public";
        public MemberKind Kind { get; }

        public CSharpTypeMember(string name, MemberKind kind)
        {
            Name = name;
            Kind = kind;
        }

        public void AddAttribute(string attribute)
        {
            _attributes.Add(attribute);
        }

        public abstract void Generate(CodeGenContext context);
    }
}
