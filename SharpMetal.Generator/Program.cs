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
                if (!files[i].Contains("Defines"))
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
                if (HeaderInfo.SelectorInstances.Count > 0)
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

                foreach (var instance in HeaderInfo.SelectorInstances)
                {
                    sw.WriteLine(GetIndent() + $"private static readonly Selector {instance.Name} = \"{instance.Selector}\";");
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