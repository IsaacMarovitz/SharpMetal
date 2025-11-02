namespace SharpMetal.Generator.Instances
{
    public abstract class TypeInstance
    {
        public string Name { get; }

        protected TypeInstance(string name)
        {
            Name = name;
        }
    }
}
