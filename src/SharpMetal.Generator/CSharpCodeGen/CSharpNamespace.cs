namespace SharpMetal.Generator.CSharpCodeGen
{
    public class CSharpNamespace : ICodeFragmentProvider
    {
        private readonly List<CSharpType> _types = [];

        public string Name { get; }

        public CSharpNamespace(string name)
        {
            Name = name;
        }

        public void AddType(CSharpType csType)
        {
            _types.Add(csType);
        }

        public void Generate(CodeGenContext context)
        {
            context.WriteLine($"namespace {Name}");
            context.EnterScope();

            for (var index = 0; index < _types.Count; index++)
            {
                var type = _types[index];
                type.Generate(context);
                if (index != _types.Count - 1)
                {
                    context.WriteLine();
                }
            }

            context.LeaveScope();
        }
    }
}
