namespace SharpMetal.Generator.CSharpCodeGen
{
    public class CSharpMethod : CSharpTypeMember
    {
        private readonly List<(int Indent, string Line)> _bodyContents = [];
        private readonly List<(string Type, string Name, string Attribute)> _parameterList;

        public bool HasExpressionBody => PreferExpressionBody && _bodyContents.Count == 1;
        public bool PreferExpressionBody { get; set; }
        public string ReturnType { get; }
        public bool IsStatic { get; set; }
        public bool IsUnsafe { get; set; }
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
            _bodyContents.Add((0, line));
        }

        public void AddBodyScope(string line)
        {
            _bodyContents.Add((1, line));
        }

        public void AddBodyLineLeaveScope()
        {
            _bodyContents.Add((-1, string.Empty));
        }

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
            if (IsUnsafe)
            {
                sb.Append(" unsafe");
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
                    sb.Append($" => {_bodyContents[0].Line};");
                    context.WriteLine(sb.ToString());
                }
                else
                {
                    context.WriteLine(sb.ToString());

                    context.EnterScope();

                    foreach (var line in _bodyContents)
                    {
                        switch (line.Indent)
                        {
                            case 1:
                                context.WriteLine($"{line.Line}");
                                context.EnterScope();
                                break;
                            case -1:
                                context.LeaveScope();
                                break;
                            default:
                                context.WriteLine($"{line.Line};");
                                break;
                        }
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
