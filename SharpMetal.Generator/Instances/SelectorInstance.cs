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

        public static void Build(string line, string namespacePrefix, StreamReader sr, List<StructInstance> structInstances)
        {
            var inlineInfo = line.Split(" ", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
            var parentStructName = string.Empty;

            foreach (var section in inlineInfo)
            {
                if (section.Contains("::") && section.Contains("("))
                {
                    var parentStructInfo = section.Split("::");
                    parentStructName = namespacePrefix + parentStructInfo[1];
                }
            }

            sr.ReadLine();
            var selector = sr.ReadLine();
            sr.ReadLine();

            string lookingFor = $"_{namespacePrefix}_PRIVATE_SEL(";
            int index = selector.IndexOf(lookingFor);

            if (index != -1)
            {
                // Only get stuff in the brackets of the _MTL_PRIVATE_SEL
                selector = selector.Substring(index + lookingFor.Length);
                selector = selector.Substring(0, selector.IndexOf(")"));
                selector = selector.Replace("_", ":");
                var parentIndex = structInstances.FindIndex(x => x.Name == parentStructName);

                if (parentIndex != -1)
                {
                    structInstances[parentIndex].AddSelector(new SelectorInstance(selector));
                }
                else
                {
                    Console.WriteLine($"Orphaned Selector! Looking for {parentStructName}");
                }
            }
        }
    }
}