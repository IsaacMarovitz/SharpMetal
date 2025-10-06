using System.Runtime.CompilerServices;
using SharpMetal.Generator.Instances;
using SharpMetal.Generator.Linked;

namespace SharpMetal.Generator
{
    public class Program
    {
        public static string GetSourceFilePathName([CallerFilePath] string? callerFilePath = null) => callerFilePath ?? "";

        public static void Main(string[] args)
        {
            var projectPaths = new DirectoryInfo(GetSourceFilePathName()).Parent?.Parent?.GetDirectories() ?? [];

            var generatorProjectPath = projectPaths.First(x => x.Name == "SharpMetal.Generator");
            var mainProjectPath = projectPaths.First(x => x.Name == "SharpMetal");

            // Set working directory to the actual project directory
            Directory.SetCurrentDirectory(mainProjectPath.FullName);

            foreach (var subDirectory in mainProjectPath.GetDirectories())
            {
                // Get rid of this condition when this folder is also generated
                // Exclude the Handwritten directory from the purge
                if (subDirectory.Name != "ObjectiveCCore" && subDirectory.Name != "bin" && subDirectory.Name != "obj" && subDirectory.Name != "Handwritten")
                {
                    subDirectory.Delete(true);
                }
            }

            // Get the paths to all the header files
            var headers = Directory.GetFiles(generatorProjectPath.FullName, "*.hpp", SearchOption.AllDirectories)
                .Where(header => !header.Contains("Defines") && !header.Contains("Private")).ToArray();

            var headerInfos = new List<HeaderInfo>();

            var enumCache = new List<EnumInstance>();
            var structCache = new List<StructInstance>();
            var classCache = new List<ClassInstance>();
            var selectorDefinitions = new List<SelectorDefinition>();

            // High-level overview of the generator:
            // 0. Parse the files into our representation model (*Instance, uses cpp/swift naming)
            // 1. Link the model into actual C# representable types (uses C# naming)
            // 2. Emit the code - lightweight emit that should not modify the prepared data in any way

            // Parse
            foreach (var header in headers)
            {
                var info = GenerateHeaderInfo(header);

                if (info != null)
                {
                    headerInfos.Add(info);
                    enumCache.AddRange(info.EnumInstances);
                    structCache.AddRange(info.StructInstances);
                    classCache.AddRange(info.ClassInstances);
                    selectorDefinitions.AddRange(info.SelectorDefinitions);
                }
            }

            var objectiveCInstances = new HashSet<ObjectiveCInstance>();

            // Link
            ModelLinker linker = new ModelLinker();
            var csharpFiles = linker.Link(headerInfos, selectorDefinitions, objectiveCInstances);

            // Emit
            foreach (var csharpFile in csharpFiles)
            {
                Generate(csharpFile);
            }

            GenerateObjectiveC(objectiveCInstances);
        }

        public static HeaderInfo? GenerateHeaderInfo(string filePath)
        {
            var headerInfo = new HeaderInfo(filePath);

            if (headerInfo.StructInstances.Count == 0 && headerInfo.ClassInstances.Count == 0 && headerInfo.EnumInstances.Count == 0)
            {
                return null;
            }

            return headerInfo;
        }

        public static void Generate(CSharpFile cSharpFile)
        {
            Directory.CreateDirectory(cSharpFile.Directory);
            using CodeGenContext context = new(File.CreateText(cSharpFile.FilePath));

            cSharpFile.Generate(context);
        }

        public static void Generate(HeaderInfo headerInfo, List<ClassInstance> classCache, List<EnumInstance> enumCache, List<StructInstance> structCache, ref HashSet<ObjectiveCInstance> objectiveCInstances)
        {
            Directory.CreateDirectory(headerInfo.FullNamespace);

            using CodeGenContext context = new(File.CreateText($"{headerInfo.FullNamespace}/{headerInfo.FileName}.cs"));

            context.WriteLine($"namespace SharpMetal.{headerInfo.FullNamespace}");
            context.EnterScope();

            for (var i = 0; i < headerInfo.StructInstances.Count; i++)
            {
                headerInfo.StructInstances[i].Generate(context);

                if (headerInfo.ClassInstances.Count != 0)
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
                var instances = headerInfo.ClassInstances[i].Generate(classCache, enumCache, structCache, context);

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
            context.WriteLine("internal static partial class ObjectiveCRuntime");
            context.EnterScope();

            var list = objectiveCInstances.ToList();
            list.Sort(ObjectiveCEmitOrderComparer);

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
            return;

            static int ObjectiveCEmitOrderComparer(ObjectiveCInstance x, ObjectiveCInstance y)
            {
                var typeComparison = string.Compare(x.Type, y.Type, StringComparison.InvariantCultureIgnoreCase);
                if (typeComparison != 0)
                {
                    return typeComparison;
                }

                var lengthComparison = x.Inputs.Length.CompareTo(y.Inputs.Length);
                if (lengthComparison != 0)
                {
                    return lengthComparison;
                }

                var xInputs = string.Join(" ", x.Inputs);
                var yInputs = string.Join(" ", y.Inputs);
                return string.Compare(xInputs, yInputs, StringComparison.InvariantCultureIgnoreCase);
            }
        }
    }
}
