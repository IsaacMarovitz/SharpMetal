using SharpMetal.Generator.Utilities;

namespace SharpMetal.Generator.Instances
{
    public class HeaderInstance
    {
        public List<EnumInstance> EnumInstances = new();
        // public List<ClassInstance> ClassInstances = new();
        // public List<StructInstance> StructInstances = new();
        // public List<MethodInstance> InFlightUnscopedMethods = new();

        public HeaderInstance(StreamReader sr)
        {
            while (!sr.EndOfStream)
            {
                var line = sr.ReadLine().Trim();

                // Ignore empty and pre-processors
                if (line == string.Empty ||
                    line.StartsWith("#"))
                {
                    continue;
                }

                if (line.StartsWith("typedef"))
                {
                    if (line.Contains("NS_OPTIONS") || line.Contains("NS_ENUM"))
                    {
                        EnumInstances.Add(new EnumInstance(sr, line));
                    }

                    if (line.Contains("struct"))
                    {
                    }
                    continue;
                }
            }
        }
    }
}
