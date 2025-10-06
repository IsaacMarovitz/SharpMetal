namespace SharpMetal.Generator.Linked
{
    public class CSharpFile : ICodeFragmentProvider
    {
        public List<CSharpNamespace> Namespaces { get; private set; }

        public string Name;

        public string Directory;

        public string FilePath;

        private List<string> _usings = [];

        public CSharpFile(string name, string directory)
        {
            Name = name;
            Directory = directory;
            FilePath = $"{directory}/{name}.cs";
            Namespaces = [];
        }

        public CSharpNamespace GetOrCreateNamespace(string @namespace)
        {
            foreach (var ns in Namespaces)
            {
                if (ns.Name == @namespace)
                {
                    return ns;
                }
            }

            var rv = new CSharpNamespace(@namespace);
            Namespaces.Add(rv);
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

            foreach (var ns in Namespaces)
            {
                context.WriteLine($"namespace {ns.Name}");
                context.EnterScope();

                for (var index = 0; index < ns.Types.Count; index++)
                {
                    var type = ns.Types[index];
                    type.Generate(context);
                    // TODO: For BC of the emitted code, we need to emit an empty line after enums, even if the file contains just enums
                    // This will be removed to unify the emits later
                    // But for now it makes less changes in diffs, which is good for refactoring the logic
                    if (index != ns.Types.Count - 1 || type.Kind == TypeKind.Enum)
                    {
                        context.WriteLine();
                    }
                }

                context.LeaveScope();
            }
        }

        public void AddUsing(string @namespace)
        {
            _usings.Add(@namespace);
        }
    }
}
