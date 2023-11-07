using System.Diagnostics;
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

            // Check if Xcode is installed and get path
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.CreateNoWindow = true;
            startInfo.FileName = "/usr/bin/xcode-select";
            startInfo.Arguments = "-p";
            startInfo.RedirectStandardOutput = true;
            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();

            if (process.ExitCode != 0)
            {
                Console.WriteLine("Xcode is not installed!");
                return;
            }

            var path = process.StandardOutput.ReadToEnd().Trim();
            Console.WriteLine($"Found Xcode at '{path}'");

            var pathToHeaders = $"{path}/Platforms/MacOSX.platform/Developer/SDKs/MacOSX.sdk/System/Library/Frameworks/Metal.framework/Versions/A/Headers";

            // Get the paths to all the header files
            var headers = Directory.GetFiles(pathToHeaders, "*.h", SearchOption.AllDirectories);

            var pathToApiNotes = $"{pathToHeaders}/Metal.apinotes";

            // 1. Parse API Notes
            // API notes contain the Swift signatures for each function selector. Swift function names
            // are much less verbose and match C#'s method name styling better than their Objective-C counterparts.
            // by parsing this data, we can make the library nicer to use. This data is formatted in YML.

            // 2. Parse Headers
            // Parse all headers into an intermediate data representation. This allows us to only have to read
            // the sources files once, and have all the information we need to complete generation.

            // 3. Generate Bindings
            // Using the intermediate representation, and the API notes we gained earlier, create complete
            // C# bindings of the whole API, including comments.

            foreach (var header in headers)
            {
                using var sr = new StreamReader(File.OpenRead(header));

                var _ = new HeaderInstance(sr);
            }
        }
    }
}
