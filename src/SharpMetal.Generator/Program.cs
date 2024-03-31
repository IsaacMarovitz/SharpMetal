using System.Runtime.CompilerServices;
using CppAst;
using Microsoft.Extensions.Logging;
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
                if (subDirectory.Name != "ObjectiveCCore" && subDirectory.Name != "bin" && subDirectory.Name != "obj")
                {
                    subDirectory.Delete(true);
                }
            }

            // Get the paths to all the header files
            var headers = Directory.GetFiles(generatorProjectPath.FullName, "*.hpp", SearchOption.AllDirectories)
                .Where(header => !header.Contains("Defines") && !header.Contains("Private")).ToArray();

            var parserOptions = new CppParserOptions
            {
                SystemIncludeFolders =
                {
                    "/Library/Developer/CommandLineTools/SDKs/MacOSX.sdk/usr/include/c++/v1",
                    "/Library/Developer/CommandLineTools/usr/lib/clang/15.0.0/include"
                },
                AdditionalArguments =
                {
                    "-isysroot",
                    "/Library/Developer/CommandLineTools/SDKs/MacOSX.sdk",
                },
                TargetCpu = CppTargetCpu.ARM64,
                TargetSystem = "darwin",
                TargetVendor = "apple",
                ParseSystemIncludes = true,
                ParseMacros = true
            };

            var compilation = CppParser.ParseFiles(headers.ToList(), parserOptions);

            // var loggerFactory = LoggerFactory.Create(builder => builder
            //     .AddConsole()
            //     .SetMinimumLevel(LogLevel.Information));
            // var logger = loggerFactory.CreateLogger<Program>();
            //
            // foreach (var message in compilation.Diagnostics.Messages)
            // {
            //     switch(message.Type)
            //     {
            //         case CppLogMessageType.Info:
            //             logger.LogInformation(message.Text);
            //             break;
            //         case CppLogMessageType.Warning:
            //             logger.LogWarning(message.Text);
            //             break;
            //         case CppLogMessageType.Error:
            //             logger.LogError(message.Text);
            //             break;
            //     };
            // }

            foreach (var cppNamespace in compilation.Namespaces)
            {
                Generate(cppNamespace);
            }
        }

        public static void Generate(CppNamespace cppNamespace)
        {
            var fullNamespace = Namespaces.GetPrettyNamespace(cppNamespace.Name);

            Console.WriteLine($"Generating Namespace: \"{fullNamespace}\"");
            Directory.CreateDirectory(fullNamespace);

            Dictionary<string, CodeGenContext> sourceFileMap = new();

            foreach (var cppEnum in cppNamespace.Enums)
            {
                var codeGenContext = GetOrCreateContext(cppEnum.SourceFile, cppNamespace, ref sourceFileMap);

                var enumInstance = new EnumInstance(cppEnum);
                enumInstance.Generate(codeGenContext);
                Console.WriteLine($"Generating Enum: \"{cppEnum.Name}\"");
            }

            foreach (var cppClass in cppNamespace.Classes)
            {
                var context = GetOrCreateContext(cppClass.SourceFile, cppNamespace, ref sourceFileMap);

                if (cppClass.ClassKind == CppClassKind.Struct)
                {
                    var structInstance = new StructInstance(cppClass);
                    structInstance.Generate(context);
                    Console.WriteLine($"Generating Struct: \"{cppClass.Name}\"");
                }
                else
                {
                    var classInstance = new ClassInstance(cppClass);
                    classInstance.Generate(context);
                    Console.WriteLine($"Generating Class: \"{cppClass.Name}\"");
                }
            }

            foreach (var context in sourceFileMap.Values)
            {
                context.LeaveScope();
                context.Dispose();
            }
        }

        public static CodeGenContext GetOrCreateContext(string sourceFile,
            CppNamespace cppNamespace,
            ref Dictionary<string, CodeGenContext> sourceFileMap)
        {
            var fullNamespace = Namespaces.GetPrettyNamespace(cppNamespace.Name);

            if (!sourceFileMap.TryGetValue(sourceFile, out var codeGenContext))
            {
                var fileInfo = new FileInfo(sourceFile);
                var fileName = fileInfo.Name.Replace(fileInfo.Extension, "");

                codeGenContext = new CodeGenContext(File.CreateText($"{fullNamespace}/{fileName}.cs"));

                GenerateUsings(cppNamespace, codeGenContext);
                codeGenContext.WriteLine($"namespace SharpMetal.{fullNamespace}");
                codeGenContext.EnterScope();

                sourceFileMap.Add(sourceFile, codeGenContext);
            }

            return codeGenContext;
        }

        public static void GenerateUsings(CppNamespace cppNamespace, CodeGenContext context)
        {
            if (cppNamespace.Classes.Any())
            {
                context.WriteLine("using System.Runtime.InteropServices;");
            }

            if (cppNamespace.Classes.Any() ||cppNamespace.Enums.Any())
            {
                context.WriteLine("using System.Runtime.Versioning;");
            }

            // TODO: See if we can minify these
            context.WriteLine("using SharpMetal.ObjectiveCCore;");
            context.WriteLine("using SharpMetal.Foundation;");
            context.WriteLine("using SharpMetal.Metal;");
            context.WriteLine("using SharpMetal.QuartzCore;");
            context.WriteLine();
        }

        public static void GenerateObjectiveC(HashSet<ObjectiveCInstance> objectiveCInstances)
        {
            // objectiveCInstances.RemoveWhere(x => x.Type == string.Empty);
            //
            // using CodeGenContext context = new(File.CreateText("ObjectiveCRuntime.cs"));
            //
            // context.WriteLine("using System.Runtime.InteropServices;");
            // context.WriteLine("using System.Runtime.Versioning;");
            // context.WriteLine("using SharpMetal.ObjectiveCCore;");
            // context.WriteLine("using SharpMetal.Foundation;");
            // context.WriteLine("using SharpMetal.Metal;");
            // context.WriteLine();
            //
            // context.WriteLine("namespace SharpMetal");
            // context.EnterScope();
            //
            // context.WriteLine("[SupportedOSPlatform(\"macos\")]");
            // context.WriteLine("public static partial class ObjectiveCRuntime");
            // context.EnterScope();
            //
            // var list = objectiveCInstances.ToList();
            // list.Sort();
            //
            // for (var i = 0; i < list.Count; i++)
            // {
            //     list[i].Generate(context);
            //     if (i != list.Count - 1)
            //     {
            //         context.WriteLine();
            //     }
            // }
            //
            // context.LeaveScope();
            // context.LeaveScope();
        }
    }
}
