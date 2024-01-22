using SharpMetal.Generator.Instances.Class;
using SharpMetal.Generator.Instances.Enums;
using SharpMetal.Generator.Instances.Struct;

namespace SharpMetal.Generator.Instances.Header
{
    public class HeaderInstance : IInstance
    {
        public ClassInstance[] ClassInstances;
        public EnumInstance[] EnumInstances;
        public StructInstance[] StructInstances;
        public string InstanceName { get; set; }
        public Compatability Compatability { get; set; }

        public HeaderInstance(
            string headerName,
            ClassInstance[] classes,
            EnumInstance[] enums,
            StructInstance[] structs)
        {
            InstanceName = headerName;
            ClassInstances = classes;
            EnumInstances = enums;
            StructInstances = structs;
        }

        public void Generate(CodeGenContext context)
        {
            throw new NotImplementedException();
        }
    }
}
