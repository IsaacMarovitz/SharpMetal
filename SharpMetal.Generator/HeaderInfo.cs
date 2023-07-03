using SharpMetal.Generator.Instances;

namespace SharpMetal.Generator
{
    public class HeaderInfo
    {
        public List<EnumInstance> EnumInstances = new();
        public List<StructInstance> StructInstances = new();

        public HeaderInfo(string filePath)
        {
            using var sr = new StreamReader(File.OpenRead(filePath));
            var namespacePrefix = Namespaces.GetNamespace(filePath);

            while (!sr.EndOfStream)
            {
                var line = sr.ReadLine();

                if (line.StartsWith("class"))
                {
                    if (!line.Contains(';'))
                    {
                        StructInstances.Add(StructInstance.BuildClass(line, namespacePrefix, sr));
                    }
                }

                if (line.StartsWith("struct"))
                {
                    if (!line.Contains(";"))
                    {
                        StructInstances.Add(StructInstance.Build(line, namespacePrefix, sr));
                    }
                }

                if (line.StartsWith($"_{namespacePrefix}_ENUM") || line.StartsWith($"_{namespacePrefix}_OPTIONS"))
                {
                    EnumInstances.Add(EnumInstance.Build(line, namespacePrefix, sr));
                }

                // These contain all the selectors we need
                if (line.StartsWith($"_{namespacePrefix}_INLINE"))
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
                        var parentIndex = StructInstances.FindIndex(x => x.Name == parentStructName);

                        if (parentIndex != -1)
                        {
                            StructInstances[parentIndex].AddSelector(new SelectorInstance(selector));
                        }
                        else
                        {
                            Console.WriteLine($"Orphaned Selector! Looking for {parentStructName}");
                        }
                    }
                }
            }
        }
    }
}