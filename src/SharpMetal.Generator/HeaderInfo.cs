using SharpMetal.Generator.Instances;
using SharpMetal.Generator.Utilities;

namespace SharpMetal.Generator
{
    public class HeaderInfo
    {
        public String FilePath { get; }
        public IncludeFlags IncludeFlags = IncludeFlags.None;
        public List<EnumInstance> EnumInstances = new();
        public List<ClassInstance> ClassInstances = new();
        public List<StructInstance> StructInstances = new();
        public List<MethodInstance> InFlightUnscopedMethods = new();

        public HeaderInfo(string filePath)
        {
            FilePath = filePath;
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
                        IncludeFlags |= IncludeFlags.Foundation;
                    }
                    else if (line.Contains("Metal"))
                    {
                        IncludeFlags |= IncludeFlags.Metal;
                    }
                    else if (line.Contains("QuartzCore"))
                    {
                        IncludeFlags |= IncludeFlags.QuartzCore;
                    }
                }
                else if (line.StartsWith("class"))
                {
                    if (!line.Contains(';'))
                    {
                        ClassInstances.Add(ClassInstance.Build(line, namespacePrefix, sr, InFlightUnscopedMethods));
                        InFlightUnscopedMethods.Clear();
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
                    SelectorInstance.Build(line, namespacePrefix, sr, ClassInstances);
                }
                else
                {
                    line = line.Replace("_NS_EXPORT ", "");
                    if (StringUtils.IsValidFunctionSignature(line) && line.Contains("(") && line.Contains(";") && !line.Contains("extern \"C\"") && !line.Contains("::Private"))
                    {
                        var rawName = line;
                        // These are static methods that aren't in a class
                        // Just so happens that one of these is incredibly important
                        line = StringUtils.FunctionSignatureCleanup(line);

                        var info = line.Split(" ", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
                        var returnType = "";
                        var name = "";
                        var nameIndex = 0;
                        MethodInstance? method = null;

                        for (int i = 0; i < info.Length; i++)
                        {
                            if (info[i].Contains("("))
                            {
                                // This element is the function name
                                // everything before it is the returnType
                                nameIndex = i;
                                returnType = Types.ConvertType(string.Join(" ", info, 0, i), namespacePrefix);

                                int index = info[i].IndexOf("(");
                                if (index >= 0)
                                {
                                    name = info[i].Substring(0, index);
                                }
                            }
                        }

                        if (line.Contains("()"))
                        {
                            // Function has no arguments
                            method = new MethodInstance(returnType, name, rawName, true, true, new List<PropertyInstance>());
                        }
                        else
                        {
                            var inputs = info[Range.StartAt(nameIndex)];
                            var inputString = String.Join(" ", inputs);

                            // Remove everything before and including (
                            int startIndex = inputString.IndexOf("(");
                            if (startIndex >= 0)
                            {
                                inputString = inputString.Substring(startIndex + 1);
                            }

                            // Remove everything after and include )
                            int endIndex = inputString.IndexOf(")");
                            if (endIndex >= 0)
                            {
                                inputString = inputString.Substring(0, endIndex);
                            }

                            var inputArguments = inputString.Split(",", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
                            List<PropertyInstance> arguments = new();

                            foreach (var argument in inputArguments)
                            {
                                var array = argument.Split(" ", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
                                var argumentType = Types.ConvertType(string.Join(" ", array[..^1]), namespacePrefix);
                                var argumentName = array.Last();

                                // Fix array inputs
                                // Might need to be NSArray
                                if (argumentName.Contains("[]"))
                                {
                                    argumentType += "[]";
                                    argumentName = argumentName.Replace("[]", "");
                                }

                                // String is a keyword in C#
                                if (argumentName == "string")
                                {
                                    argumentName = "nsString";
                                }

                                // Event is a keyword in C#
                                if (argumentName == "event")
                                {
                                    argumentName = "mtlEvent";
                                }

                                arguments.Add(new PropertyInstance(argumentType, argumentName));
                            }

                            if (returnType != string.Empty)
                            {
                                method = new MethodInstance(returnType, name, rawName, true, true, arguments);
                            }
                        }

                        if (method != null)
                        {
                            InFlightUnscopedMethods.Add(method);
                        }
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
        MetalFX = 4 << 0
    }
}
