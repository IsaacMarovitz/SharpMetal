namespace SharpMetal.Generator.CSharpCodeGen
{
    public enum MemberKind
    {
        Field,
        Property,
        Method,
    }

    public abstract class CSharpTypeMember(string name, MemberKind kind) : ICodeFragmentProvider
    {
        protected readonly List<string> Attributes = [];

        public string Name { get; } = name;
        public string VisibilityModifier { get; set; } = "public";
        public MemberKind Kind { get; } = kind;

        public void AddAttribute(string attribute)
        {
            Attributes.Add(attribute);
        }

        public abstract void Generate(CodeGenContext context);
    }
}
