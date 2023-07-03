using SharpMetal.Generator.Instances;

namespace SharpMetal.Generator
{
    public class HeaderInfo
    {
        public IncludeFlags IncludeFlags = IncludeFlags.None;
        public List<MethodInstance> NamespaceFunctions = new();
        public List<EnumInstance> EnumInstances = new();
        public List<ClassInstance> ClassInstances = new();
        public List<StructInstance> StructInstances = new();

        public HeaderInfo(string filePath)
        {
            using var sr = new StreamReader(File.OpenRead(filePath));
            var namespacePrefix = Namespaces.GetNamespace(filePath);

            while (!sr.EndOfStream)
            {
                var line = sr.ReadLine().Trim();

                if (line == string.Empty ||
                    line.StartsWith("//") ||
                    line.StartsWith("#pragma") ||
                    line.StartsWith("#define") ||
                    line.StartsWith("{") ||
                    line.StartsWith("}") ||
                    line.StartsWith("namespace") ||
                    line.StartsWith("using") ||
                    line.StartsWith("template") ||
                    line.StartsWith("MTL_DEF_FUNC") ||
                    line.StartsWith("_NS_CONST") ||
                    line.StartsWith("_MTL_CONST") ||
                    line.StartsWith("_MTL_PRIVATE_DEF_WEAK_CONST") ||
                    line.StartsWith("_MTL_PRIVATE_DEF_STR") ||
                    line.StartsWith("_NS_PRIVATE_DEF_CONST"))
                {
                    continue;
                }

                if (line.StartsWith("#include"))
                {
                    if (line.Contains("Foundation"))
                    {
                        IncludeFlags = IncludeFlags | IncludeFlags.Foundation;
                    }
                    else if (line.Contains("Metal"))
                    {
                        IncludeFlags = IncludeFlags | IncludeFlags.Metal;
                    }
                    else if (line.Contains("QuartzCore"))
                    {
                        IncludeFlags = IncludeFlags | IncludeFlags.QuartzCore;
                    }
                } else if (line.StartsWith("class"))
                {
                    if (!line.Contains(';'))
                    {
                        ClassInstances.Add(ClassInstance.Build(line, namespacePrefix, sr));
                    }
                }
                else if (line.StartsWith("struct"))
                {
                    if (!line.Contains(";"))
                    {
                        StructInstances.Add(StructInstance.Build(line, namespacePrefix, sr));
                    }
                }
                else if (line.StartsWith($"_{namespacePrefix}_ENUM") || line.StartsWith($"_{namespacePrefix}_OPTIONS"))
                {
                    EnumInstances.Add(EnumInstance.Build(line, namespacePrefix, sr));
                }
                // These contain all the selectors we need
                else if (line.StartsWith($"_{namespacePrefix}_INLINE"))
                {
                    List<IPropertyOwner> propertyOwners = new();

                    propertyOwners.AddRange(StructInstances);
                    propertyOwners.AddRange(ClassInstances);

                    SelectorInstance.Build(line, namespacePrefix, sr, propertyOwners);
                }
                else
                {
                    Console.WriteLine($"UNPROCESSED LINE: {line}");
                }
            }
        }
    }

    [Flags]
    public enum IncludeFlags
    {
        None = 0,
        Foundation = 1 << 0,
        Metal = 2 << 0,
        QuartzCore = 3 << 0,
    }
}