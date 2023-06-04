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

            foreach (var instance in headerInfo.EnumInstances) {
                GenerateEnum(instance, sw, ref depth);
            }

            for (var i = 0; i < headerInfo.StructInstances.Count; i++)
            {
                GenerateStruct(headerInfo.StructInstances[i], enumCache, sw, ref depth);

                if (i != headerInfo.StructInstances.Count - 1)
                {
                    sw.WriteLine();
                }
            }

            sw.WriteLine("}");
            depth -= 1;
        }

        public static void GenerateEnum(EnumInstance instance, StreamWriter sw, ref int depth)
        {
            sw.WriteLine(GetIndent(depth) + $"public enum {instance.Name}: {instance.Type}");
            sw.WriteLine(GetIndent(depth) + "{");

            depth += 1;
            foreach (var value in instance.Values)
            {
                if (value.Value != string.Empty)
                {
                    sw.WriteLine(GetIndent(depth) + $"{value.Key} = {value.Value},");
                }
                else
                {
                    sw.WriteLine(GetIndent(depth) + $"{value.Key},");
                }
            }

            depth -= 1;

            sw.WriteLine(GetIndent(depth) + "}");
            sw.WriteLine();
        }

        public static void GenerateStruct(StructInstance instance, List<EnumCacheInstance> enumCache, StreamWriter sw, ref int depth)
        {
            sw.WriteLine(GetIndent(depth) + "[SupportedOSPlatform(\"macos\")]");

            if (!instance.IsClass)
            {
                sw.WriteLine(GetIndent(depth) + "[StructLayout(LayoutKind.Sequential)]");
            }

            sw.WriteLine(GetIndent(depth) + $"public struct {instance.Name}");
            sw.WriteLine(GetIndent(depth) + "{");

            depth += 1;

            sw.WriteLine(GetIndent(depth) + "public readonly IntPtr NativePtr;");
            sw.WriteLine(GetIndent(depth) + $"public static implicit operator IntPtr({instance.Name} obj) => obj.NativePtr;");
            sw.WriteLine(GetIndent(depth) + $"public {instance.Name}(IntPtr ptr) => NativePtr = ptr;");

            if (instance.HasAlloc)
            {
                sw.WriteLine();
                sw.WriteLine(GetIndent(depth) + $"public {instance.Name}()");
                sw.WriteLine(GetIndent(depth) + "{");

                depth += 1;

                sw.WriteLine(GetIndent(depth) + $"var cls = new ObjectiveCClass(\"{instance.Name}\");");

                if (instance.HasInit)
                {
                    sw.WriteLine(GetIndent(depth) + "NativePtr = cls.AllocInit();");
                }
                else
                {
                    sw.WriteLine(GetIndent(depth) + "NativePtr = cls.Alloc();");
                }

                depth -= 1;
                sw.WriteLine(GetIndent(depth) + "}");
            }

            if (instance.PropertyInstances.Any())
            {
                sw.WriteLine();
            }

            for (var j = 0; j < instance.PropertyInstances.Count; j++)
            {
                GenerateProperty(instance, instance.PropertyInstances[j], enumCache, sw, ref depth);

                if (j != instance.PropertyInstances.Count - 1)
                {
                    sw.WriteLine();
                }
            }


            if (instance.SelectorInstances.Any())
            {
                sw.WriteLine();
            }

            foreach (var selector in instance.SelectorInstances)
            {
                sw.WriteLine(GetIndent(depth) + $"private static readonly Selector {selector.Name} = \"{selector.Selector}\";");
            }

            depth -= 1;

            sw.WriteLine(GetIndent(depth) + "}");
        }

        public static void GenerateProperty(StructInstance instance, PropertyInstance property, List<EnumCacheInstance> enumCache, StreamWriter sw, ref int depth)
        {
            var selector = instance.SelectorInstances.Find(x => x.Selector.ToLower() == property.Name.ToLower());

            if (selector == null)
            {
                // This can sometimes select the wrong selector, so we only want to use it as a backup
                selector = instance.SelectorInstances.Find(x => x.Selector.ToLower().Contains(property.Name.ToLower()));
            }

            if (selector != null)
            {
                var runtimeFuncReturn = "IntPtr";
                var setterSelector = instance.SelectorInstances.Find(x => x.Selector.ToLower().Contains("set" + selector.Selector.ToLower()));

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

                if (setterSelector != null)
                {
                    if (runtimeFuncReturn == "IntPtr")
                    {
                        // Need to adjust this to support enums from other headers
                        var enumInstance = enumCache.Find(x => x.Name == property.Type);

                        if (enumInstance != null)
                        {
                            sw.WriteLine(GetIndent(depth) + $"public {property.Type} {property.Name}");
                            sw.WriteLine(GetIndent(depth) + "{");
                            depth += 1;

                            sw.WriteLine(GetIndent(depth) + $"get => ({enumInstance.Name})ObjectiveCRuntime.{enumInstance.Type}_objc_msgSend(NativePtr, {selector.Name});");
                            sw.WriteLine(GetIndent(depth) + $"set => ObjectiveCRuntime.objc_msgSend(NativePtr, {setterSelector.Name}, ({enumInstance.Type})value);");
                            depth -= 1;

                            sw.WriteLine(GetIndent(depth) + "}");
                        }
                        else
                        {
                            sw.WriteLine(GetIndent(depth) + $"public {property.Type} {property.Name}");
                            sw.WriteLine(GetIndent(depth) + "{");
                            depth += 1;

                            sw.WriteLine(GetIndent(depth) + $"get => new(ObjectiveCRuntime.{runtimeFuncReturn}_objc_msgSend(NativePtr, {selector.Name}));");
                            sw.WriteLine(GetIndent(depth) + $"set => ObjectiveCRuntime.objc_msgSend(NativePtr, {setterSelector.Name}, value);");
                            depth -= 1;

                            sw.WriteLine(GetIndent(depth) + "}");
                        }
                    }
                    else
                    {
                        sw.WriteLine(GetIndent(depth) + $"public {property.Type} {property.Name}");
                        sw.WriteLine(GetIndent(depth) + "{");
                        depth += 1;

                        sw.WriteLine(GetIndent(depth) + $"get => ObjectiveCRuntime.{runtimeFuncReturn}_objc_msgSend(NativePtr, {selector.Name});");
                        sw.WriteLine(GetIndent(depth) + $"set => ObjectiveCRuntime.objc_msgSend(NativePtr, {setterSelector.Name}, value);");
                        depth -= 1;

                        sw.WriteLine(GetIndent(depth) + "}");
                    }
                }
                else
                {
                    if (runtimeFuncReturn == "IntPtr")
                    {
                        // Need to adjust this to support enums from other headers
                        var enumInstance = enumCache.Find(x => x.Name == property.Type);

                        if (enumInstance != null)
                        {
                            sw.WriteLine(GetIndent(depth) + $"public {property.Type} {property.Name} => ({enumInstance.Name})ObjectiveCRuntime.{enumInstance.Type}_objc_msgSend(NativePtr, {selector.Name});");
                        }
                        else
                        {
                            sw.WriteLine(GetIndent(depth) + $"public {property.Type} {property.Name} => new(ObjectiveCRuntime.{runtimeFuncReturn}_objc_msgSend(NativePtr, {selector.Name}));");
                        }
                    }
                    else
                    {
                        sw.WriteLine(GetIndent(depth) + $"public {property.Type} {property.Name} => ObjectiveCRuntime.{runtimeFuncReturn}_objc_msgSend(NativePtr, {selector.Name});");
                    }
                }
            }
            else
            {
                sw.WriteLine(GetIndent(depth) + $"public {property.Type} {property.Name};");
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

        public static string GetIndent(int depth)
        {
            return new StringBuilder().Insert(0, "    ", depth).ToString();
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