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

            if (headerInfo.StructInstances.Count == 0 && headerInfo.ClassInstances.Count == 0 && headerInfo.EnumInstances.Count == 0)
            {
                return;
            }

            string fileName = Path.GetFileNameWithoutExtension(filePath);
            var fullNamespace = Namespaces.GetFullNamespace(filePath);

            Directory.CreateDirectory(fullNamespace);

            using CodeGenContext context = new(File.CreateText($"{fullNamespace}/{fileName}.cs"));

            GenerateUsings(headerInfo, context, fullNamespace);

            context.WriteLine($"namespace SharpMetal.{fullNamespace}");
            context.EnterScope();

            foreach (var instance in headerInfo.EnumInstances)
            {
                instance.Generate(context);
            }

            for (var i = 0; i < headerInfo.StructInstances.Count; i++)
            {
                headerInfo.StructInstances[i].Generate(enumCache, context);

                if (headerInfo.ClassInstances.Any())
                {
                    context.WriteLine();
                }
                else if (i != headerInfo.StructInstances.Count - 1)
                {
                    context.WriteLine();
                }
            }

            for (var i = 0; i < headerInfo.ClassInstances.Count; i++)
            {
                headerInfo.ClassInstances[i].Generate(enumCache, context);

                if (i != headerInfo.ClassInstances.Count - 1)
                {
                    context.WriteLine();
                }
            }

            context.LeaveScope();
        }

        public static void GenerateUsings(HeaderInfo headerInfo, CodeGenContext context, string fullNamespace)
        {
            var hasAnyUsings = false;
            var hasSelectors = false;

            foreach (var instance in headerInfo.StructInstances)
            {
                if (instance.GetSelectors().Any())
                {
                    hasSelectors = true;
                }
            }

            foreach (var instance in headerInfo.ClassInstances)
            {
                if (instance.GetSelectors().Any())
                {
                    hasSelectors = true;
                }
            }

            if (headerInfo.StructInstances.Any())
            {
                context.WriteLine("using System.Runtime.InteropServices;");
                hasAnyUsings = true;
            }

            if (headerInfo.StructInstances.Any() || headerInfo.ClassInstances.Any())
            {
                context.WriteLine("using System.Runtime.Versioning;");
                hasAnyUsings = true;
            }

            if (hasSelectors)
            {
                context.WriteLine("using SharpMetal.ObjectiveC;");
            }

            if (headerInfo.IncludeFlags != IncludeFlags.None)
            {
                hasAnyUsings = true;
                if ((headerInfo.IncludeFlags & IncludeFlags.Foundation) == IncludeFlags.Foundation)
                {
                    if (fullNamespace != "Foundation")
                    {
                        context.WriteLine("using SharpMetal.Foundation;");
                    }
                }
                if ((headerInfo.IncludeFlags & IncludeFlags.Metal) == IncludeFlags.Metal)
                {
                    if (fullNamespace != "Metal")
                    {
                        context.WriteLine("using SharpMetal.Metal;");
                    }
                }
                if ((headerInfo.IncludeFlags & IncludeFlags.QuartzCore) == IncludeFlags.QuartzCore)
                {
                    if (fullNamespace != "QuartzCore")
                    {
                        context.WriteLine("using SharpMetal.QuartzCore;");
                    }
                }
            }

            if (hasAnyUsings)
            {
                context.WriteLine();
            }
        }
    }
}