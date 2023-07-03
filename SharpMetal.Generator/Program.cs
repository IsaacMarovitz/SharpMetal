using System.Runtime.CompilerServices;
using SharpMetal.Generator.Instances;

namespace SharpMetal.Generator
{
    public class Program
    {
        public static string GetSourceFilePathName([CallerFilePath] string? callerFilePath = null) => callerFilePath ?? "";

        public static void Main(string[] args)
        {
            var projectPaths = new DirectoryInfo(GetSourceFilePathName()).Parent.Parent.GetDirectories();

            var generatorProjectPath = projectPaths.First(x => x.Name == "SharpMetal.Generator");
            var mainProjectPath = projectPaths.First(x => x.Name == "SharpMetal");

            // Set working directory to the actual project directory
            Directory.SetCurrentDirectory(mainProjectPath.FullName);

            foreach (var subDirectory in mainProjectPath.GetDirectories())
            {
                // Get rid of this condition when this folder is also generated
                if (subDirectory.Name != "ObjectiveC" && subDirectory.Name != "bin" && subDirectory.Name != "obj")
                {
                    subDirectory.Delete(true);
                }
            }

            // Get the paths to all the header files
            var headers = Directory.GetFiles(generatorProjectPath.FullName, "*.hpp", SearchOption.AllDirectories)
                .Where(header => !header.Contains("Defines") && !header.Contains("Private")).ToArray();

            var enumCache = new List<EnumInstance>();

            foreach (var header in headers)
            {
                GenerateEnumCache(header, ref enumCache);
            }

            foreach (var header in headers)
            {
                Generate(header, enumCache);
            }
        }

        public static void GenerateEnumCache(string filePath, ref List<EnumInstance> enumCache)
        {
            using var sr = new StreamReader(File.OpenRead(filePath));
            var namespacePrefix = Namespaces.GetNamespace(filePath);

            while (!sr.EndOfStream)
            {
                var line = sr.ReadLine();

                if (line.StartsWith($"_{namespacePrefix}_ENUM") || line.StartsWith($"_{namespacePrefix}_OPTIONS"))
                {
                    enumCache.Add(EnumInstance.Build(line, namespacePrefix, sr, true));
                }
            }
        }

        public static void Generate(string filePath, List<EnumInstance> enumCache)
        {
            var headerInfo = new HeaderInfo(filePath);

            if (headerInfo.StructInstances.Count == 0 && headerInfo.EnumInstances.Count == 0)
            {
                return;
            }

            string fileName = Path.GetFileNameWithoutExtension(filePath);
            var fullNamespace = Namespaces.GetFullNamespace(filePath);

            Directory.CreateDirectory(fullNamespace);

            using CodeGenContext context = new(File.CreateText($"{fullNamespace}/{fileName}.cs"));

            GenerateUsings(headerInfo, context);

            // TODO: Need to keep track of where types are from for proper namespacing while avoiding unnecessary using statements.
            // context.WriteLine($"namespace SharpMetal.{fullNamespace}");

            context.WriteLine($"namespace SharpMetal");
            context.EnterScope();

            foreach (var instance in headerInfo.EnumInstances)
            {
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