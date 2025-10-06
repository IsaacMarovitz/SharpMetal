namespace SharpMetal.Generator.Linked
{
    public class CSharpEnumType : CSharpType
    {
        public CSharpEnumType(string name) : base(TypeKind.Enum, name)
        {
        }

        public void SetPrimitiveType(string type)
        {
            BaseTypes.Clear();
            BaseTypes.Add(type);
        }

        public void MarkAsFlags()
        {
            Attributes.Add("[Flags]");
        }

        public void AddValues(Dictionary<string, string> values)
        {
            foreach (var value in values)
            {
                var field = new CSharpEnumValue(value.Key);
                if (!string.IsNullOrEmpty(value.Value))
                {
                    field.DefaultValue = value.Value;
                }
                AddMember(field);
            }
        }
    }
}
