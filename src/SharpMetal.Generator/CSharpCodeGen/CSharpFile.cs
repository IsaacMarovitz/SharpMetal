namespace SharpMetal.Generator.CSharpCodeGen
{
    public class CSharpFile : ICodeFragmentProvider
    {
        private readonly HashSet<string> _usings = [];
        private readonly List<CSharpNamespace> _namespaces = [];

        public string Name { get; }
        public string Directory { get; }
        public string FilePath { get; }

        public CSharpFile(string name)
        {
            Name = name;
            Directory = "";
            FilePath = $"{name}.cs";
        }

        public CSharpFile(string name, string directory)
        {
            Name = name;
            Directory = directory;
            FilePath = $"{directory}/{name}.cs";
        }

        public CSharpNamespace GetOrCreateNamespace(string @namespace)
        {
            foreach (var ns in _namespaces)
            {
                if (ns.Name == @namespace)
                {
                    return ns;
                }
            }

            var rv = new CSharpNamespace(@namespace);
            _namespaces.Add(rv);
            return rv;
        }

        public void Generate(CodeGenContext context)
        {
            if (_usings.Count > 0)
            {
                foreach (var @using in _usings)
                {
                    context.WriteLine($"using {@using};");
                }
                context.WriteLine();
            }

            for (var index = 0; index < _namespaces.Count; index++)
            {
                var ns = _namespaces[index];
                ns.Generate(context);
                if (index != _namespaces.Count - 1)
                {
                    context.WriteLine();
                }
            }
        }

        public void AddUsing(string @namespace)
        {
            _usings.Add(@namespace);
        }
    }
}
