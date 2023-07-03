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
            var namespacePrefix = Namespaces.GetNamespace(filePath);

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

                    var convertedType = Types.ConvertType(type, namespacePrefix);
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
                instance.Generate(context);
            }

            for (var i = 0; i < headerInfo.StructInstances.Count; i++)
            {
                headerInfo.StructInstances[i].Generate(enumCache, context);

                if (i != headerInfo.StructInstances.Count - 1)
                {
                    context.WriteLine();
                }
            }

            context.LeaveScope();
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