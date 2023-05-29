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

            for (int i = 0; i < files.Length; i++)
            {
                if (!files[i].Contains("Defines") && !files[i].Contains("Private"))
                {
                    Generate(files[i]);
                }
            }
        }

        public static void Generate(string filePath)
        {
            string fileName = new DirectoryInfo(filePath).Name.Replace(".hpp", "");
            var HeaderInfo = new HeaderInfo(filePath);
            var depth = 0;

            using (StreamWriter sw = File.CreateText($"Output/{fileName}.cs"))
            {
                var hasSelectors = false;

                foreach (var structInstance in HeaderInfo.StructInstances)
                {
                    if (structInstance.SelectorInstances.Any())
                    {
                        hasSelectors = true;
                    }
                }

                if (HeaderInfo.StructInstances.Count > 0)
                {
                    sw.WriteLine("using System.Runtime.InteropServices;");
                    sw.WriteLine("using System.Runtime.Versioning;");
                }

                if (hasSelectors)
                {
                    sw.WriteLine("using SharpMetal.ObjectiveC;");
                    sw.WriteLine();
                }

                sw.WriteLine("namespace SharpMetal");
                sw.WriteLine("{");
                depth += 1;

                // Start with enums since they're nice and easy
                foreach (var instance in HeaderInfo.EnumInstances) {
                    sw.WriteLine(GetIndent() + $"public enum {instance.Name}: {instance.Type.Name}");
                    sw.WriteLine(GetIndent() + "{");

                    depth += 1;
                    foreach (var value in instance.Values)
                    {
                        sw.WriteLine(GetIndent() + $"{value.Key} = {value.Value},");
                    }

                    depth -= 1;

                    sw.WriteLine(GetIndent() + "}");
                    sw.WriteLine();
                }

                for (var i = 0; i < HeaderInfo.StructInstances.Count; i++)
                {
                    var instance = HeaderInfo.StructInstances[i];
                    sw.WriteLine(GetIndent() + "[SupportedOSPlatform(\"macos\")]");
                    sw.WriteLine(GetIndent() + "[StructLayout(LayoutKind.Sequential)]");
                    sw.WriteLine(GetIndent() + $"public struct {instance.Name}");
                    sw.WriteLine(GetIndent() + "{");

                    depth += 1;

                    sw.WriteLine(GetIndent() + "public readonly IntPtr NativePtr;");
                    sw.WriteLine(GetIndent() +
                                 $"public static implicit operator IntPtr({instance.Name} obj) => obj.NativePtr;");
                    sw.WriteLine(GetIndent() + $"public {instance.Name}(IntPtr ptr) => NativePtr = ptr;");

                    if (instance.SelectorInstances.Any())
                    {
                        sw.WriteLine();
                    }

                    // TODO: Properties and functions


                    foreach (var selector in instance.SelectorInstances)
                    {
                        sw.WriteLine(GetIndent() +
                                     $"private static readonly Selector {selector.Name} = \"{selector.Selector}\";");
                    }

                    depth -= 1;

                    sw.WriteLine(GetIndent() + "}");

                    if (i != HeaderInfo.StructInstances.Count - 1)
                    {
                        sw.WriteLine();
                    }
                }

                sw.WriteLine("}");
                depth -= 1;

            }

            string GetIndent()
            {
                return new StringBuilder().Insert(0, "    ", depth).ToString();
            }
        }
    }
}