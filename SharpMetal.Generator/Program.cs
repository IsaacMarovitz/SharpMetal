using System.Text;

namespace SharpMetal.Generator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Set working directory to the actual project directory
            Directory.SetCurrentDirectory(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName);

            // Get the paths to all the header files
            var files = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.hpp", SearchOption.AllDirectories);

            if (Directory.Exists("Output"))
            {
                Directory.Delete("Output", true);
            }

            Directory.CreateDirectory("Output");
            // TODO: Don't hardcode these
            Directory.CreateDirectory("Output/Metal");
            Directory.CreateDirectory("Output/Foundation");
            Directory.CreateDirectory("Output/QuartzCore");

            var enumCache = new List<EnumCacheInstance>();

            for (int i = 0; i < files.Length; i++)
            {
                if (!files[i].Contains("Defines") && !files[i].Contains("Private"))
                {
                    GenerateEnumCache(files[i], ref enumCache);
                }
            }

            for (int i = 0; i < files.Length; i++)
            {
                if (!files[i].Contains("Defines") && !files[i].Contains("Private"))
                {
                    Generate(files[i], enumCache);
                }
            }
        }

        public static void GenerateEnumCache(string filePath, ref List<EnumCacheInstance> enumCache)
        {
            using var sr = new StreamReader(File.OpenRead(filePath));
            var namespacePrefix = HeaderInfo.GetNamespace(filePath);

            while (!sr.EndOfStream)
            {
                var line = sr.ReadLine();

                if (line.StartsWith($"_{namespacePrefix}_ENUM") || line.StartsWith($"_{namespacePrefix}_OPTIONS"))
                {
                    line = line.Replace($"_{namespacePrefix}_ENUM(", "");
                    line = line.Replace($"_{namespacePrefix}_OPTIONS(", "");
                    line = line.Replace(") {", "");
                    var info = line.Split(",", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
                    var type = info[0].Replace("::", "");
                    var name = namespacePrefix + info[1];

                    var finishedEnumerating = false;

                    while (!finishedEnumerating)
                    {
                        if (sr.ReadLine() == "};")
                        {
                            finishedEnumerating = true;
                        }
                    }

                    var convertedType = HeaderInfo.ConvertType(type, namespacePrefix);
                    enumCache.Add(new EnumCacheInstance(convertedType, name));
                }
            }
        }

        public static void Generate(string filePath, List<EnumCacheInstance> enumCache)
        {
            var headerInfo = new HeaderInfo(filePath);

            if (headerInfo.StructInstances.Count == 0 && headerInfo.EnumInstances.Count == 0)
            {
                return;
            }

            filePath = filePath.Substring(filePath.IndexOf("Headers/") + "Headers/".Length);
            string fileName = filePath.Replace(".hpp", "");
            var depth = 0;

            using StreamWriter sw = File.CreateText($"Output/{fileName}.cs");

            GenerateUsings(headerInfo, sw);

            sw.WriteLine("namespace SharpMetal");
            sw.WriteLine("{");
            depth += 1;

            // Start with enums since they're nice and easy
            foreach (var instance in headerInfo.EnumInstances) {
                sw.WriteLine(GetIndent() + $"public enum {instance.Name}: {instance.Type}");
                sw.WriteLine(GetIndent() + "{");

                depth += 1;
                foreach (var value in instance.Values)
                {
                    if (value.Value != string.Empty)
                    {
                        sw.WriteLine(GetIndent() + $"{value.Key} = {value.Value},");
                    }
                    else
                    {
                        sw.WriteLine(GetIndent() + $"{value.Key},");
                    }
                }

                depth -= 1;

                sw.WriteLine(GetIndent() + "}");
                sw.WriteLine();
            }

            for (var i = 0; i < headerInfo.StructInstances.Count; i++)
            {
                var instance = headerInfo.StructInstances[i];
                sw.WriteLine(GetIndent() + "[SupportedOSPlatform(\"macos\")]");

                if (!instance.IsClass)
                {
                    sw.WriteLine(GetIndent() + "[StructLayout(LayoutKind.Sequential)]");
                }

                sw.WriteLine(GetIndent() + $"public struct {instance.Name}");
                sw.WriteLine(GetIndent() + "{");

                depth += 1;

                sw.WriteLine(GetIndent() + "public readonly IntPtr NativePtr;");
                sw.WriteLine(GetIndent() + $"public static implicit operator IntPtr({instance.Name} obj) => obj.NativePtr;");
                sw.WriteLine(GetIndent() + $"public {instance.Name}(IntPtr ptr) => NativePtr = ptr;");

                if (instance.PropertyInstances.Any())
                {
                    sw.WriteLine();
                }

                foreach (var property in instance.PropertyInstances)
                {
                    var selector = instance.SelectorInstances.Find(x => x.Selector.ToLower().Contains(property.Name.ToLower()));

                    if (selector != null)
                    {
                        var runtimeFuncReturn = "IntPtr";

                        switch (property.Type)
                        {
                            case "bool":
                                runtimeFuncReturn = "bool";
                                break;
                            case "ulong":
                                runtimeFuncReturn = "ulong";
                                break;
                            case "uint":
                                runtimeFuncReturn = "uint";
                                break;
                            case "int":
                                runtimeFuncReturn = "int";
                                break;
                            case "float":
                                runtimeFuncReturn = "float";
                                break;
                            case "double":
                                runtimeFuncReturn = "double";
                                break;
                            case "long":
                                runtimeFuncReturn = "long";
                                break;
                            case "byte":
                                runtimeFuncReturn = "byte";
                                break;
                            case "short":
                                runtimeFuncReturn = "short";
                                break;
                            case "ushort":
                                runtimeFuncReturn = "ushort";
                                break;
                        }

                        if (runtimeFuncReturn == "IntPtr")
                        {
                            // Need to adjust this to support enums from other headers
                            var enumInstance = enumCache.Find(x => x.Name == property.Type);

                            if (enumInstance != null)
                            {
                                sw.WriteLine(GetIndent() + $"public {property.Type} {property.Name} => ({enumInstance.Name})ObjectiveCRuntime.{enumInstance.Type}_objc_msgSend(NativePtr, {selector.Name});");
                            }
                            else
                            {
                                sw.WriteLine(GetIndent() + $"public {property.Type} {property.Name} => new(ObjectiveCRuntime.{runtimeFuncReturn}_objc_msgSend(NativePtr, {selector.Name}));");
                            }
                        }
                        else
                        {
                            sw.WriteLine(GetIndent() + $"public {property.Type} {property.Name} => ObjectiveCRuntime.{runtimeFuncReturn}_objc_msgSend(NativePtr, {selector.Name});");
                        }
                    }
                    else
                    {
                        sw.WriteLine(GetIndent() + $"public {property.Type} {property.Name};");
                    }
                }


                if (instance.SelectorInstances.Any())
                {
                    sw.WriteLine();
                }

                foreach (var selector in instance.SelectorInstances)
                {
                    sw.WriteLine(GetIndent() + $"private static readonly Selector {selector.Name} = \"{selector.Selector}\";");
                }

                depth -= 1;

                sw.WriteLine(GetIndent() + "}");

                if (i != headerInfo.StructInstances.Count - 1)
                {
                    sw.WriteLine();
                }
            }

            sw.WriteLine("}");
            depth -= 1;

            string GetIndent()
            {
                return new StringBuilder().Insert(0, "    ", depth).ToString();
            }
        }

        public static void GenerateUsings(HeaderInfo headerInfo, StreamWriter sw)
        {
            var hasSelectors = false;
            var hasStructs = false;
            var hasAnyUsings = false;

            foreach (var structInstance in headerInfo.StructInstances)
            {
                if (structInstance.SelectorInstances.Any())
                {
                    hasSelectors = true;
                }

                if (!structInstance.IsClass)
                {
                    hasStructs = true;
                }
            }

            if (hasStructs)
            {
                sw.WriteLine("using System.Runtime.InteropServices;");
                hasAnyUsings = true;
            }

            if (headerInfo.StructInstances.Count > 0)
            {
                sw.WriteLine("using System.Runtime.Versioning;");
                hasAnyUsings = true;
            }

            if (hasSelectors)
            {
                sw.WriteLine("using SharpMetal.ObjectiveC;");
                hasAnyUsings = true;
            }

            if (hasAnyUsings)
            {
                sw.WriteLine();
            }
        }
    }
}

public class EnumCacheInstance
{
    public string Type;
    public string Name;

    public EnumCacheInstance(string type, string name)
    {
        Type = type;
        Name = name;
    }
}