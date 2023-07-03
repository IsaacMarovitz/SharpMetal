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
                    SelectorInstance.Build(line, namespacePrefix, sr, StructInstances);
                }
            }
        }
    }
}