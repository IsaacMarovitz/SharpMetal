namespace SharpMetal.Generator.Instances
{
    public interface IPropertyOwner
    {
        public string Name { get; set; }

        List<SelectorInstance> GetSelectors();
        public void AddSelector(SelectorInstance selectorInstance);
    }
}