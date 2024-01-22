using SharpMetal.Generator.Instances.Class;
using SharpMetal.Generator.Instances.Enums;
using SharpMetal.Generator.Instances.Struct;

namespace SharpMetal.Generator.Instances
{
    public class HeaderInstance : Instance
    {
        public ClassInstance[] ClassInstances;
        public EnumInstance[] EnumInstances;
        public StructInstance[] StructInstances;

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
    }
}
