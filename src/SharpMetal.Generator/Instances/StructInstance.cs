using System.Text.RegularExpressions;
using SharpMetal.Generator.Utilities;

namespace SharpMetal.Generator.Instances
{
    public partial class StructInstance : TypeInstance
    {
        public List<MemberVariableInstance> MemberVariableInstances { get; }

        private StructInstance(string name) : base(name)
        {
            MemberVariableInstances = [];
        }

        public void AddMemberVariable(MemberVariableInstance memberVariableInstance)
        {
            // We don't want to include functions in this pass
            if (memberVariableInstance.Name.Contains('('))
            {
                return;
            }

            if (!MemberVariableInstances.Exists(x => x.Name == memberVariableInstance.Name))
            {
                MemberVariableInstances.Add(memberVariableInstance);
            }
        }

        public static StructInstance Build(string line, string namespacePrefix, StreamReader sr, bool skipValues = false)
        {
            var structInfo = line.Split(" ", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
            var structName = Namespaces.GetOverrideForSpecificTypes(namespacePrefix + structInfo[1]);

            var instance = new StructInstance(structName);

            var structEnded = false;
            sr.ReadLine();

            while (!structEnded)
            {
                var propertyLine = GeneratorUtils.ReadNextCodeLine(sr);
                if (propertyLine == null)
                {
                    break;
                }

                if (propertyLine.Contains('}'))
                {
                    structEnded = true;
                    continue;
                }

                if (skipValues)
                {
                    continue;
                }

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

                instance.AddMemberVariable(new MemberVariableInstance(type, propertyName));
            }

            return instance;
        }

        [GeneratedRegex(@"\[.*?\]")]
        private static partial Regex NameRegex();
    }
}
