namespace SharpMetal.Generator.Instances
{
    public class SelectorInstance
    {
        public string Name;
        public string Selector;

        public SelectorInstance(string selector)
        {
            Name = "sel_" + selector.Replace(":", "");
            Selector = selector;
        }
    }
}