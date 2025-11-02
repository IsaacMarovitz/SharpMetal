using SharpMetal.Generator.CSharpCodeGen;
using SharpMetal.Generator.Instances;

namespace SharpMetal.Generator.Transformers
{
    public static class EnumTransformer
    {
        public static CSharpEnumType TransformEnum(EnumInstance enumInstance)
        {
            var csEnum = new CSharpEnumType(enumInstance.Name);
            csEnum.SetPrimitiveType(enumInstance.BackingType);
            csEnum.AddValues(enumInstance.Values);

            if (enumInstance.IsFlag)
            {
                csEnum.MarkAsFlags();
            }

            return csEnum;
        }
    }
}
