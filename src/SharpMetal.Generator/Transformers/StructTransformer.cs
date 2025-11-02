using SharpMetal.Generator.CSharpCodeGen;
using SharpMetal.Generator.Instances;

namespace SharpMetal.Generator.Transformers
{
    public static class StructTransformer
    {
        public static CSharpStructType TransformStruct(StructInstance structInstance)
        {
            var csStruct = new CSharpStructType(structInstance.Name);
            foreach (var memberVariable in structInstance.MemberVariableInstances)
            {
                csStruct.AddMember(new CSharpField(memberVariable.Type, memberVariable.Name));
            }

            // Mark as sequential layout
            csStruct.Attributes.Add("[StructLayout(LayoutKind.Sequential)]");

            return csStruct;
        }
    }
}
