using SharpMetal.Generator.Instances;
using SharpMetal.Generator.Utilities;

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
            var inMTLPrivateDefSel = false;

            while (!sr.EndOfStream)
            {
                var line = sr.ReadLine().Trim();

                // Ignore garbage
                if (line == string.Empty ||
                    line.StartsWith("//") ||
                    line.StartsWith("::") ||
                    line.StartsWith("[[") ||
                    line.StartsWith("/**") ||
                    line.StartsWith("#error") ||
                    line.StartsWith("#pragma") ||
                    line.StartsWith("#define") ||
                    line.StartsWith("__block") ||
                    line.StartsWith("_Ret") ||
                    line.StartsWith("Object") ||
                    line.StartsWith("~Object") ||
                    line.StartsWith("_Class*") ||
                    line.StartsWith("{") ||
                    line.StartsWith("}") ||
                    line.StartsWith("(") ||
                    line.StartsWith(",") ||
                    line.StartsWith("private:") ||
                    line.StartsWith("public:") ||
                    line.StartsWith("namespace") ||
                    line.StartsWith("using") ||
                    line.StartsWith("template") ||
                    line.StartsWith("return") ||
                    line.StartsWith("const") ||
                    line.StartsWith("static") ||
                    line.StartsWith("if") ||
                    line.StartsWith("else") ||
                    line.StartsWith("#if") ||
                    line.StartsWith("#else") ||
                    line.StartsWith("#elif") ||
                    line.StartsWith("#endif") ||
                    line.StartsWith("MTL_DEF_FUNC") ||
                    line.StartsWith("_NS_CONST") ||
                    line.StartsWith("_MTL_CONST") ||
                    line.StartsWith("_MTL_PRIVATE_DEF_WEAK_CONST") ||
                    line.StartsWith("_MTL_PRIVATE_DEF_CONST") ||
                    line.StartsWith("_MTL_PRIVATE_DEF_STR") ||
                    line.StartsWith("_MTL_PRIVATE_DEF_CLS") ||
                    line.StartsWith("_MTL_PRIVATE_DEF_PRO") ||
                    line.StartsWith("_NS_PRIVATE_DEF_CONST"))
                {
                    continue;
                }

                // These take two lines, no idea why
                if (line.StartsWith("_MTL_PRIVATE_DEF_SEL"))
                {
                    inMTLPrivateDefSel = true;
                    continue;
                }

                if (inMTLPrivateDefSel)
                {
                    inMTLPrivateDefSel = false;
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
                    line = line.Replace("_NS_EXPORT ", "");
                    if (StringUtils.IsValidFunctionSignature(line) && line.Contains("(") && line.Contains(";") && !line.Contains("extern \"C\"") && !line.Contains("::Private"))
                    {
                        // These are static methods that aren't in a class
                        // Just so happens that one of these is incredibly important
                        Console.WriteLine($"UNPROCESSED LINE: {line}");
                    }
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