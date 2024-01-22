namespace SharpMetal.Generator.Instances
{
    public interface IInstance
    {
        public string InstanceName { get; set; }
        public Compatability Compatability { get; set; }
        public Documentation Documentation { get; set; }

        public void Generate(CodeGenContext context);
    }
}
