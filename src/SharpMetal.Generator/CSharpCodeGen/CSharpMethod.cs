namespace SharpMetal.Generator.CSharpCodeGen
{
    public class CSharpMethod : CSharpTypeMember
    {
        private readonly List<string> _bodyContents = [];
        private readonly List<(string Type, string Name, string Attribute)> _parameterList;

        public bool HasExpressionBody => PreferExpressionBody && _bodyContents.Count == 1;
        public bool PreferExpressionBody { get; set; }
        public string ReturnType { get; private set; }
        public bool IsStatic { get; set; }
        public bool IsPartial { get; set; }

        public CSharpMethod(string name, string returnType) : base(name, MemberKind.Method)
        {
            ReturnType = returnType;
            _parameterList = [];
        }

        public CSharpMethod(string name, string returnType, (string Type, string Name, string Attribute) parameter) : base(name, MemberKind.Method)
        {
            ReturnType = returnType;
            _parameterList = [parameter];
        }

        public CSharpMethod(string name, string returnType, List<(string Type, string Name, string Attribute)> parameterList) : base(name, MemberKind.Method)
        {
            ReturnType = returnType;
            _parameterList = parameterList;
        }

        public void AddBodyLine(string line)
        {
            _bodyContents.Add(line);
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
            if (IsPartial)
            {
                sb.Append(" partial");
            }
            // Special formatting case for ctors that have empty return type
            if (!string.IsNullOrEmpty(ReturnType))
            {
                sb.Append(' ');
                sb.Append(ReturnType);
            }
            sb.Append(' ');
            sb.Append(Name);
            sb.Append('(');
            sb.Append(string.Join(", ", _parameterList.Select(x => $"{x.Attribute} {x.Type} {x.Name}".Trim())));
            sb.Append(')');
            if (!IsPartial)
            {
                if (HasExpressionBody)
                {
                    sb.Append($" => {_bodyContents[0]};");
                    context.WriteLine(sb.ToString());
                }
                else
                {
                    context.WriteLine(sb.ToString());
                    context.EnterScope();
                    foreach (var line in _bodyContents)
                    {
                        context.WriteLine($"{line};");
                    }
                    context.LeaveScope();
                }
            }
            else
            {
                sb.Append(';');
                context.WriteLine(sb.ToString());
            }
            context.ReleaseTempStringBuilder(sb);
        }
    }
}
