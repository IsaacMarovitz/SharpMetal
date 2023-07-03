using System.Text.RegularExpressions;

namespace SharpMetal.Generator.Instances
{
    public class StructInstance : IPropertyOwner
    {
        public string Name { get; set; }
        private List<PropertyInstance> _propertyInstances;
        private List<SelectorInstance> _selectorInstances;

        private StructInstance(string name)
        {
            Name = name;
            _selectorInstances = new();
            _propertyInstances = new();
        }

        public void AddSelector(SelectorInstance selectorInstance)
        {
            if (!_selectorInstances.Exists(x => x.Selector == selectorInstance.Selector))
            {
                _selectorInstances.Add(selectorInstance);
            }
        }

        public void AddProperty(PropertyInstance propertyInstance)
        {
            // We don't want to include functions in this pass
            if (propertyInstance.Name.Contains("("))
            {
                return;
            }

            if (!_propertyInstances.Exists(x => x.Name == propertyInstance.Name))
            {
                _propertyInstances.Add(propertyInstance);
            }
        }

        public void Generate(List<EnumInstance> enumCache, CodeGenContext context)
        {
            context.WriteLine("[SupportedOSPlatform(\"macos\")]");
            context.WriteLine("[StructLayout(LayoutKind.Sequential)]");

            context.WriteLine($"public struct {Name}");
            context.EnterScope();

            context.WriteLine("public readonly IntPtr NativePtr;");
            context.WriteLine($"public static implicit operator IntPtr({Name} obj) => obj.NativePtr;");
            context.WriteLine($"public {Name}(IntPtr ptr) => NativePtr = ptr;");

            if (_propertyInstances.Any())
            {
                context.WriteLine();
            }

            for (var j = 0; j < _propertyInstances.Count; j++)
            {
                _propertyInstances[j].Generate(this, enumCache, context);

                if (j != _propertyInstances.Count - 1)
                {
                    context.WriteLine();
                }
            }

            if (_selectorInstances.Any())
            {
                context.WriteLine();
            }

            foreach (var selector in _selectorInstances)
            {
                context.WriteLine($"private static readonly Selector {selector.Name} = \"{selector.Selector}\";");
            }

            context.LeaveScope();
        }

        public static StructInstance Build(string line, string namespacePrefix, StreamReader sr)
        {
            var structInfo = line.Split(" ", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
            var structName = namespacePrefix + structInfo[1];

            var instance = new StructInstance(structName);

            bool structEnded = false;
            sr.ReadLine();

            while (!structEnded)
            {
                var propertyLine = sr.ReadLine();
                if (propertyLine.Contains('}'))
                {
                    structEnded = true;
                    continue;
                }

                if (propertyLine.Contains('(') && propertyLine.Contains(')')) continue;

                var propertyInfo = propertyLine.Replace(";", "").Split(" ", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

                if (propertyInfo.Length != 2) continue;

                var type = Types.ConvertType(propertyInfo[0], namespacePrefix);
                var propertyName = propertyInfo[1];

                string pattern = @"\[.*?\]";
                propertyName = Regex.Replace(propertyName, pattern, "");

                instance.AddProperty(new PropertyInstance(type, propertyName));
            }

            return instance;
        }

        public List<SelectorInstance> GetSelectors()
        {
            return _selectorInstances;
        }
    }
}