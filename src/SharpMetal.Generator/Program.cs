using System.Runtime.CompilerServices;
using SharpMetal.Generator.CSharpCodeGen;
using SharpMetal.Generator.Transformers;

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

            var parsedModel = new ParsedModel();

            // High-level overview of the generator:
            // 0. Parse the files into our representation model (*Instance, uses cpp/swift naming)
            // 1. Transform the model into actual C# representable types (uses C# naming)
            // 2. Emit the code - lightweight emit that should not modify the prepared data in any way

            // Parse
            foreach (var header in headers)
            {
                var info = GenerateHeaderInfo(header);

                if (info != null)
                {
                    parsedModel.AddHeader(info);
                }
            }

            // Transform
            var transformer = new ModelTransformer();
            var csharpFiles = transformer.Link(parsedModel);

            // Emit
            foreach (var csharpFile in csharpFiles)
            {
                Generate(csharpFile);
            }
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
            if (!string.IsNullOrEmpty(cSharpFile.Directory))
            {
                Directory.CreateDirectory(cSharpFile.Directory);
            }
            using CodeGenContext context = new(File.CreateText(cSharpFile.FilePath));

            cSharpFile.Generate(context);
        }
    }
}
