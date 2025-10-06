namespace SharpMetal.Generator.Linked
{
    public class CSharpNamespace
    {
        public List<CSharpType> Types { get; private set; }

        public string Name { get; private set; }

        public CSharpNamespace(string name)
        {
            Name = name;
            Types = [];
        }

        public void AddType(CSharpType csEnum)
        {
            Types.Add(csEnum);
        }
    }
}
