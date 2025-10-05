namespace SharpMetal.Generator.Instances
{
    public class MemberVariableInstance
    {
        public readonly string Type;
        public readonly string Name;

        public MemberVariableInstance(string type, string name)
        {
            Type = type;
            Name = name;
        }

        public void Generate(CodeGenContext context)
        {
            context.WriteLine($"public {Type} {Name};");
        }
    }
}
