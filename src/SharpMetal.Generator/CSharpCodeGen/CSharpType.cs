namespace SharpMetal.Generator.CSharpCodeGen
{
    public enum TypeKind
    {
        Class = 0,
        Struct = 1,
        Enum = 2,
    }

    public abstract class CSharpType : ICodeFragmentProvider
    {
        public TypeKind Kind { get; }
        public string Name { get; }
        public List<CSharpTypeMember> Members { get; }
        public List<string> Attributes { get; }
        public List<string> BaseTypes { get; }
        public bool IsPartial { get; set; }
        public bool IsStatic { get; set; }
        public string VisibilityModifier { get; set; }

        public CSharpType(TypeKind kind, string name)
        {
            Kind = kind;
            Name = name;
            VisibilityModifier = "public";
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

            string typeDeclaration = $"{VisibilityModifier} {(IsStatic ? "static " : "")}{(IsPartial ? "partial " : "")}{KindToType(Kind)} {Name}";
            if (BaseTypes.Count > 0)
            {
                typeDeclaration += $" : {string.Join(", ", BaseTypes)}";
            }

            context.WriteLine(typeDeclaration);
            context.EnterScope();

            for (var i = 0; i < Members.Count; i++)
            {
                var value = Members[i];
                if (i > 0)
                {
                    // Add extra lines in special cases, to keep identical emits to previous versions formatting-wise
                    var oneLiner = value is CSharpMethod m && m.HasExpressionBody;
                    if ((value.Kind != MemberKind.Field || value.Kind != Members[i - 1].Kind) && !oneLiner)
                    {
                        context.WriteLine();
                    }
                }

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
                    case TypeKind.Class:
                        return "class";
                }

                throw new ArgumentOutOfRangeException(nameof(kind), $"'{kind}' not supported.");
            }
        }
    }
}
