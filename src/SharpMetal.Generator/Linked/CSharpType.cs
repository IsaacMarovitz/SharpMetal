namespace SharpMetal.Generator.Linked
{
    public enum TypeKind
    {
        Class = 0,
        Struct = 1,
        Enum = 2,
    }

    public abstract class CSharpType : ICodeFragmentProvider
    {
        public TypeKind Kind { get; private set; }

        public string Name { get; private set; }

        public List<CSharpTypeMember> Members { get; private set; }

        public List<string> Attributes { get; private set; }

        public List<string> BaseTypes { get; private set; }

        public CSharpType(TypeKind kind, string name)
        {
            Kind = kind;
            Name = name;
            BaseTypes = [];
            Members = [];
            Attributes = [];
        }

        public void AddMember(CSharpTypeMember member)
        {
            Members.Add(member);
        }

        public void Generate(CodeGenContext context)
        {
            context.WriteLine("[SupportedOSPlatform(\"macos\")]");
            foreach (var attribute in Attributes)
            {
                context.WriteLine(attribute);
            }

            string typeDeclaration = $"public {KindToType(Kind)} {Name}";
            if (BaseTypes.Count > 0)
            {
                typeDeclaration += $" : {string.Join(", ", BaseTypes)}";
            }
            context.WriteLine(typeDeclaration);
            context.EnterScope();

            foreach (var value in Members)
            {
               value.Generate(context);
            }

            context.LeaveScope();

            static string KindToType(TypeKind kind)
            {
                switch (kind)
                {
                    case TypeKind.Struct:
                        return "struct";
                    case TypeKind.Enum:
                        return "enum";
                }

                throw new ArgumentOutOfRangeException(nameof(kind), $"'{kind}' not supported.");
            }
        }
    }
}
