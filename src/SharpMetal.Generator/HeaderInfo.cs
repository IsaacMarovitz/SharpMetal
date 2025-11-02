using SharpMetal.Generator.Instances;
using SharpMetal.Generator.Utilities;

namespace SharpMetal.Generator
{
    public class HeaderInfo
    {
        private readonly List<MethodInstance> _inFlightUnscopedMethods = [];

        public string FilePath { get; }
        public string FileName { get; }
        public string FullNamespace { get; }
        public IncludeFlags Flags { get; } = IncludeFlags.None;
        public List<EnumInstance> EnumInstances { get; } = [];
        public List<ClassInstance> ClassInstances { get; } = [];
        public List<StructInstance> StructInstances { get; } = [];

        public HeaderInfo(string filePath)
        {
            FilePath = filePath;
            FileName = Path.GetFileNameWithoutExtension(filePath);
            FullNamespace = Namespaces.GetFullNamespace(filePath);
            using var sr = new StreamReader(File.OpenRead(filePath));
            var namespacePrefix = Namespaces.GetNamespace(filePath);
            var macroNamespacePrefix = Namespaces.GetMacroNamespace(namespacePrefix);

            while (!sr.EndOfStream)
            {
                var line = GeneratorUtils.ReadNextCodeLine(sr);
                if (line == null)
                {
                    break;
                }

                // Ignore garbage
                if (line.StartsWith("::") ||
                    line.StartsWith("[[") ||
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
                    // Let's just consume the second line straight away
                    sr.ReadLine();
                    continue;
                }

                if (line.StartsWith("#include"))
                {
                    if (line.Contains("Foundation"))
                    {
                        Flags |= IncludeFlags.Foundation;
                    }
                    else if (line.Contains("Metal"))
                    {
                        Flags |= IncludeFlags.Metal;
                    }
                    else if (line.Contains("QuartzCore"))
                    {
                        Flags |= IncludeFlags.QuartzCore;
                    }
                }
                else if (line.StartsWith("class"))
                {
                    if (!line.Contains(';'))
                    {
                        if (_inFlightUnscopedMethods.Count > 0)
                        {
                            Console.WriteLine($"Unscoped methods found in header {filePath}:");
                            foreach (var unscopedMethod in _inFlightUnscopedMethods)
                            {
                                Console.WriteLine($"- {unscopedMethod.Name}");
                            }
                            _inFlightUnscopedMethods.Clear();
                        }
                        var classInstance = ClassInstance.Build(line, namespacePrefix, sr);
                        if (classInstance.IsValid && !GeneratorUtils.IsBannedType(classInstance.Name))
                        {
                            ClassInstances.Add(classInstance);
                        }
                    }
                }
                else if (line.StartsWith("struct"))
                {
                    if (!line.Contains(";"))
                    {
                        StructInstances.Add(StructInstance.Build(line, namespacePrefix, sr));
                    }
                }
                else if (line.StartsWith($"_{macroNamespacePrefix}_ENUM") || line.StartsWith($"_{macroNamespacePrefix}_OPTIONS"))
                {
                    EnumInstances.Add(EnumInstance.Build(line, namespacePrefix, sr));
                }
                // These contain all the selectors we need
                else if (line.StartsWith($"_{macroNamespacePrefix}_INLINE"))
                {
                    SelectorInstance.Build(line, namespacePrefix, sr, ClassInstances);
                }
                else
                {
                    line = line.Replace("_NS_EXPORT ", "");

                    if (StringUtils.IsValidFunctionSignature(line) && line.Contains('(') && line.Contains(';') && !line.Contains("extern \"C\"") && !line.Contains("::Private"))
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

                        for (var i = 0; i < info.Length; i++)
                        {
                            if (info[i].Contains('('))
                            {
                                // This element is the function name
                                // everything before it is the returnType
                                nameIndex = i;
                                returnType = Types.ConvertType(string.Join(" ", info, 0, i), namespacePrefix);

                                var index = info[i].IndexOf('(');
                                if (index >= 0)
                                {
                                    name = info[i][..index];
                                }
                            }
                        }

                        if (line.Contains("()"))
                        {
                            // Function has no arguments
                            method = new MethodInstance(returnType, name, rawName, true, false, []);
                        }
                        else
                        {
                            var inputs = info[Range.StartAt(nameIndex)];
                            var inputString = string.Join(" ", inputs);

                            // Remove everything before and including (
                            var startIndex = inputString.IndexOf('(');
                            if (startIndex >= 0)
                            {
                                inputString = inputString[(startIndex + 1)..];
                            }

                            // Remove everything after and include )
                            var endIndex = inputString.IndexOf(')');
                            if (endIndex >= 0)
                            {
                                inputString = inputString[..endIndex];
                            }

                            var inputArguments = inputString.Split(",", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
                            List<FunctionParameterInstance> arguments = [];

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

                                arguments.Add(new FunctionParameterInstance(argumentType, argumentName));
                            }

                            if (returnType != string.Empty)
                            {
                                // This is just for recording the unscoped method, no actual real method goes through this codepath
                                method = new MethodInstance(returnType, name, rawName, true, false, arguments);
                            }
                        }

                        if (method != null)
                        {
                            _inFlightUnscopedMethods.Add(method);
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
