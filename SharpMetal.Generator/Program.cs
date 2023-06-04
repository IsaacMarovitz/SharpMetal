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

            using CodeGenContext context = new(File.CreateText($"Output/{fileName}.cs"));

            GenerateUsings(headerInfo, context);

            context.WriteLine("namespace SharpMetal");
            context.EnterScope();

            foreach (var instance in headerInfo.EnumInstances) {
                GenerateEnum(instance, context);
            }

            for (var i = 0; i < headerInfo.StructInstances.Count; i++)
            {
                GenerateStruct(headerInfo.StructInstances[i], enumCache, context);

                if (i != headerInfo.StructInstances.Count - 1)
                {
                    context.WriteLine();
                }
            }

            context.LeaveScope();
        }

        public static void GenerateEnum(EnumInstance instance, CodeGenContext context)
        {
            context.WriteLine($"public enum {instance.Name}: {instance.Type}");
            context.EnterScope();

            foreach (var value in instance.Values)
            {
                if (value.Value != string.Empty)
                {
                    context.WriteLine($"{value.Key} = {value.Value},");
                }
                else
                {
                    context.WriteLine($"{value.Key},");
                }
            }

            context.LeaveScope();
            context.WriteLine();
        }

        public static void GenerateStruct(StructInstance instance, List<EnumCacheInstance> enumCache, CodeGenContext context)
        {
            context.WriteLine("[SupportedOSPlatform(\"macos\")]");

            if (!instance.IsClass)
            {
                context.WriteLine("[StructLayout(LayoutKind.Sequential)]");
            }

            context.WriteLine($"public struct {instance.Name}");
            context.EnterScope();

            context.WriteLine("public readonly IntPtr NativePtr;");
            context.WriteLine($"public static implicit operator IntPtr({instance.Name} obj) => obj.NativePtr;");
            context.WriteLine($"public {instance.Name}(IntPtr ptr) => NativePtr = ptr;");

            if (instance.HasAlloc)
            {
                context.WriteLine();
                context.WriteLine($"public {instance.Name}()");
                context.EnterScope();

                context.WriteLine($"var cls = new ObjectiveCClass(\"{instance.Name}\");");

                if (instance.HasInit)
                {
                    context.WriteLine("NativePtr = cls.AllocInit();");
                }
                else
                {
                    context.WriteLine("NativePtr = cls.Alloc();");
                }

                context.LeaveScope();
            }

            if (instance.PropertyInstances.Any())
            {
                context.WriteLine();
            }

            for (var j = 0; j < instance.PropertyInstances.Count; j++)
            {
                GenerateProperty(instance, instance.PropertyInstances[j], enumCache, context);

                if (j != instance.PropertyInstances.Count - 1)
                {
                    context.WriteLine();
                }
            }


            if (instance.SelectorInstances.Any())
            {
                context.WriteLine();
            }

            foreach (var selector in instance.SelectorInstances)
            {
                context.WriteLine($"private static readonly Selector {selector.Name} = \"{selector.Selector}\";");
            }

            context.LeaveScope();
        }

        public static void GenerateProperty(StructInstance instance, PropertyInstance property, List<EnumCacheInstance> enumCache, CodeGenContext context)
        {
            var selector = instance.SelectorInstances.Find(x => x.Selector.ToLower() == property.Name.ToLower());

            if (selector == null)
            {
                // This can sometimes select the wrong selector, so we only want to use it as a backup
                selector = instance.SelectorInstances.Find(x => x.Selector.ToLower().Contains(property.Name.ToLower()));
            }

            if (selector != null)
            {
                // We assume a type of IntPtr, which encapsulates any possible type
                var runtimeFuncReturn = "IntPtr";
                var setterSelector = instance.SelectorInstances.Find(x => x.Selector.ToLower().Contains("set" + selector.Selector.ToLower()));
                var csharpNativeTypes = new[] { "bool", "ulong", "uint", "int", "float", "double", "long", "byte", "short", "ushort" };

                // If the property is a type that exists in C# then we can safely set the
                // return type to be that type, otherwise further conversion will be needed later
                if (csharpNativeTypes.Contains(property.Type))
                {
                    runtimeFuncReturn = property.Type;
                }

                // Return type of IntPtr could either mean it returns a struct of some kind
                // or it returns an enum value, so we need to check if an enum with a matching
                // name exists.
                if (runtimeFuncReturn == "IntPtr")
                {
                    // Need to adjust this to support enums from other headers
                    var enumInstance = enumCache.Find(x => x.Name == property.Type);

                    if (enumInstance != null)
                    {
                        if (setterSelector != null)
                        {
                            context.WriteLine($"public {property.Type} {property.Name}");
                            context.EnterScope();

                            context.WriteLine($"get => ({enumInstance.Name})ObjectiveCRuntime.{enumInstance.Type}_objc_msgSend(NativePtr, {selector.Name});");
                            context.WriteLine($"set => ObjectiveCRuntime.objc_msgSend(NativePtr, {setterSelector.Name}, ({enumInstance.Type})value);");

                            context.LeaveScope();
                        }
                        else
                        {
                            context.WriteLine($"public {property.Type} {property.Name} => ({enumInstance.Name})ObjectiveCRuntime.{enumInstance.Type}_objc_msgSend(NativePtr, {selector.Name});");
                        }
                    }
                    else
                    {
                        if (setterSelector != null)
                        {
                            context.WriteLine($"public {property.Type} {property.Name}");
                            context.EnterScope();

                            context.WriteLine($"get => new(ObjectiveCRuntime.{runtimeFuncReturn}_objc_msgSend(NativePtr, {selector.Name}));");
                            context.WriteLine($"set => ObjectiveCRuntime.objc_msgSend(NativePtr, {setterSelector.Name}, value);");

                            context.LeaveScope();
                        }
                        else
                        {
                            context.WriteLine($"public {property.Type} {property.Name} => new(ObjectiveCRuntime.{runtimeFuncReturn}_objc_msgSend(NativePtr, {selector.Name}));");
                        }
                    }
                }
                else
                {
                    if (setterSelector != null)
                    {
                        context.WriteLine($"public {property.Type} {property.Name}");
                        context.EnterScope();

                        context.WriteLine($"get => ObjectiveCRuntime.{runtimeFuncReturn}_objc_msgSend(NativePtr, {selector.Name});");
                        context.WriteLine($"set => ObjectiveCRuntime.objc_msgSend(NativePtr, {setterSelector.Name}, value);");

                        context.LeaveScope();
                    }
                    else
                    {
                        context.WriteLine($"public {property.Type} {property.Name} => ObjectiveCRuntime.{runtimeFuncReturn}_objc_msgSend(NativePtr, {selector.Name});");
                    }
                }
            }
            else
            {
                context.WriteLine($"public {property.Type} {property.Name};");
            }
        }

        public static void GenerateUsings(HeaderInfo headerInfo, CodeGenContext context)
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
                context.WriteLine("using System.Runtime.InteropServices;");
                hasAnyUsings = true;
            }

            if (headerInfo.StructInstances.Count > 0)
            {
                context.WriteLine("using System.Runtime.Versioning;");
                hasAnyUsings = true;
            }

            if (hasSelectors)
            {
                context.WriteLine("using SharpMetal.ObjectiveC;");
                hasAnyUsings = true;
            }

            if (hasAnyUsings)
            {
                context.WriteLine();
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