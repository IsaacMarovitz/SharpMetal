namespace SharpMetal.Generator.Instances
{
    public class SelectorInstance
    {
        public readonly string Name;
        public readonly string RawName;
        public readonly string Selector;
        public bool UsedInProperty { get; set; }

        private SelectorInstance(string selector, string rawName)
        {
            Name = "sel_" + selector.Replace(":", "");
            RawName = rawName;
            Selector = selector;
        }

        public static void Build(string line, string namespacePrefix, StreamReader sr, List<ClassInstance> propertyOwners)
        {
            var inlineInfo = line.Split(" ", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
            var parentStructName = string.Empty;
            var rawName = "";

            for (var i = 0; i < inlineInfo.Length; i++)
            {
                var section = inlineInfo[i];
                if (section.Contains("::") && section.Contains('('))
                {
                    var parentStructInfo = section.Split("::");
                    parentStructName = namespacePrefix + parentStructInfo[1];

                    var rawNameStartIndex = line.IndexOf(section, StringComparison.Ordinal);
                    if (rawNameStartIndex >= 0)
                    {
                        rawName = line.Substring(rawNameStartIndex, line.Length - rawNameStartIndex);
                    }
                }
            }

            sr.ReadLine();
            var selector = sr.ReadLine() ?? "";
            var closingBracketLine = sr.ReadLine() ?? "";
            // some selectors are split on two lines -- in that case append the line
            if (closingBracketLine.Trim() != "}")
            {
                selector += closingBracketLine;
                sr.ReadLine();
            }

            var macroNamespaces = Namespaces.GetMacroNamespace(namespacePrefix);

            var lookingFor = $"_{macroNamespaces}_PRIVATE_SEL(";
            var index = selector.IndexOf(lookingFor, StringComparison.Ordinal);

            if (index != -1)
            {
                // Only get stuff in the brackets of the _MTL_PRIVATE_SEL
                selector = selector[(index + lookingFor.Length)..];
                selector = selector[..selector.IndexOf(')')];
                selector = selector.Replace("_", ":");

                // We don't want to deal with these functions
                if (selector.Contains("std::function") || selector.Contains("Handler") || selector.Contains("Observer"))
                {
                    return;
                }

                var parentIndex = propertyOwners.FindIndex(x => x.Name == parentStructName);

                if (parentIndex != -1)
                {
                    propertyOwners[parentIndex].AddSelector(new SelectorInstance(selector.Trim(), rawName));
                }
                else
                {
                    Console.WriteLine($"Orphaned Selector! Looking for {parentStructName}");
                }
            }
        }
    }
}
