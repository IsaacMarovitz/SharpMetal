using System.Text.RegularExpressions;

namespace SharpMetal.Generator.Instances
{
    public partial class StructInstance
    {
        public readonly string Name;
        private readonly List<PropertyInstance> _propertyInstances;

        private StructInstance(string name)
        {
            Name = name;
            _propertyInstances = [];
        }

        public void AddProperty(PropertyInstance propertyInstance)
        {
            // We don't want to include functions in this pass
            if (propertyInstance.Name.Contains('('))
            {
                return;
            }

            if (!_propertyInstances.Exists(x => x.Name == propertyInstance.Name))
            {
                _propertyInstances.Add(propertyInstance);
            }
        }

        public void Generate(CodeGenContext context)
        {
            context.WriteLine("[SupportedOSPlatform(\"macos\")]");
            context.WriteLine("[StructLayout(LayoutKind.Sequential)]");

            context.WriteLine($"public struct {Name}");
            context.EnterScope();

            for (var j = 0; j < _propertyInstances.Count; j++)
            {
                _propertyInstances[j].Generate(context);
            }

            context.LeaveScope();
        }

        public static StructInstance Build(string line, string namespacePrefix, StreamReader sr, bool skipValues = false)
        {
            var structInfo = line.Split(" ", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
            var structName = namespacePrefix + structInfo[1];

            var instance = new StructInstance(structName);

            var structEnded = false;
            sr.ReadLine();

            while (!structEnded)
            {
                var propertyLine = sr.ReadLine() ?? "";

                if (propertyLine.Contains('}'))
                {
                    structEnded = true;
                    continue;
                }

                if (!skipValues)
                {
                    if (propertyLine.Contains('(') && propertyLine.Contains(')'))
                    {
                        continue;
                    }

                    var propertyInfo = propertyLine.Replace(";", "").Split(" ", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

                    if (propertyInfo.Length != 2)
                    {
                        continue;
                    }

                    var type = Types.ConvertType(propertyInfo[0], namespacePrefix);
                    var propertyName = propertyInfo[1];

                    propertyName = NameRegex().Replace(propertyName, "");

                    instance.AddProperty(new PropertyInstance(type, propertyName));
                }
            }

            return instance;
        }

        [GeneratedRegex(@"\[.*?\]")]
        private static partial Regex NameRegex();
    }
}
