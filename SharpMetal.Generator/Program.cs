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
            var structCache = new List<StructInstance>();
            var objectiveCInstances = new HashSet<ObjectiveCInstance>();

            foreach (var header in headers)
            {
                GenerateCaches(header, ref enumCache, ref structCache);
            }

            foreach (var header in headers)
            {
                Generate(header, enumCache, structCache, ref objectiveCInstances);
            }

            GenerateObjectiveC(objectiveCInstances);
        }

        public static void GenerateCaches(string filePath, ref List<EnumInstance> enumCache, ref List<StructInstance> structCache)
        {
            using var sr = new StreamReader(File.OpenRead(filePath));
            var namespacePrefix = Namespaces.GetNamespace(filePath);

            while (!sr.EndOfStream)
            {
                var line = sr.ReadLine();

                if (line.StartsWith("struct"))
                {
                    if (!line.Contains(";"))
                    {
                        structCache.Add(StructInstance.Build(line, namespacePrefix, sr, true));
                    }
                }
                else if (line.StartsWith($"_{namespacePrefix}_ENUM") || line.StartsWith($"_{namespacePrefix}_OPTIONS"))
                {
                    enumCache.Add(EnumInstance.Build(line, namespacePrefix, sr, true));
                }
            }
        }
        public static void Generate(string filePath, List<EnumInstance> enumCache, List<StructInstance> structCache, ref HashSet<ObjectiveCInstance> objectiveCInstances)
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
                headerInfo.StructInstances[i].Generate(context);

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
                var instances = headerInfo.ClassInstances[i].Generate(enumCache, structCache, context);

                foreach (var instance in instances)
                {
                    objectiveCInstances.Add(instance);
                }

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
                context.WriteLine("using SharpMetal.ObjectiveCCore;");
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

        public static void GenerateObjectiveC(HashSet<ObjectiveCInstance> objectiveCInstances)
        {
            objectiveCInstances.RemoveWhere(x => x.Type == string.Empty);

            using CodeGenContext context = new(File.CreateText("ObjectiveCRuntime.cs"));

            context.WriteLine("using System.Runtime.InteropServices;");
            context.WriteLine("using System.Runtime.Versioning;");
            context.WriteLine("using SharpMetal.ObjectiveCCore;");
            context.WriteLine("using SharpMetal.Foundation;");
            context.WriteLine("using SharpMetal.Metal;");
            context.WriteLine();

            context.WriteLine("namespace SharpMetal");
            context.EnterScope();

            context.WriteLine("[SupportedOSPlatform(\"macos\")]");
            context.WriteLine("public static partial class ObjectiveCRuntime");
            context.EnterScope();

            var list = objectiveCInstances.ToList();

            for (var i = 0; i < list.Count; i++)
            {
                list[i].Generate(context);
                if (i != list.Count - 1)
                {
                    context.WriteLine();
                }
            }

            context.LeaveScope();
            context.LeaveScope();
        }
    }
}