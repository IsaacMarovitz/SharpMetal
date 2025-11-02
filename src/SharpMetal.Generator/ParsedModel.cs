using SharpMetal.Generator.Instances;

namespace SharpMetal.Generator
{
    /// <summary>
    /// Collected data from the parser, representing the C++ code
    /// </summary>
    public readonly ref struct ParsedModel
    {
        public List<HeaderInfo> Headers { get; } = [];
        public List<EnumInstance> Enums { get; } = [];
        public List<StructInstance> Structs { get; } = [];
        public List<ClassInstance> Classes { get; } = [];

        public ParsedModel()
        {
        }

        public void AddHeader(HeaderInfo header)
        {
            Headers.Add(header);
            Enums.AddRange(header.EnumInstances);
            Structs.AddRange(header.StructInstances);
            Classes.AddRange(header.ClassInstances);
        }

        public ClassInstance? FindClass(string typeName)
        {
            return Classes.Find(x => x.Name == typeName);
        }

        public EnumInstance? FindEnum(string typeName)
        {
            return Enums.Find(x => x.Name == typeName);
        }

        public TypeInstance? FindType(string typeName)
        {
            var enumInstance = FindEnum(typeName);
            if (enumInstance != null)
            {
                return enumInstance;
            }

            return FindStruct(typeName);
        }

        public StructInstance? FindStruct(string typeName)
        {
            return Structs.Find(x => x.Name == typeName);
        }
    }
}
