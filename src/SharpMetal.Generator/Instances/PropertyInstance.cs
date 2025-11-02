namespace SharpMetal.Generator.Instances
{
    public class PropertyInstance : IEquatable<PropertyInstance>
    {
        public readonly ClassInstance ContainingClass;
        public readonly string Type;
        public readonly string Name;
        public readonly bool Reference;
        public readonly bool IsStatic;
        public readonly bool IsDeprecated;
        public readonly string RawName;

        public PropertyInstance(ClassInstance containingClass, string type, string name, string rawName, bool reference = false, bool isStatic = false, bool isDeprecated = false)
        {
            ContainingClass = containingClass;
            Type = type;
            Name = name;
            Reference = reference;
            IsStatic = isStatic;
            IsDeprecated = isDeprecated;
            RawName = rawName;
        }

        public bool Equals(PropertyInstance? other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Type == other.Type && Name == other.Name;
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != GetType())
            {
                return false;
            }

            return Equals((PropertyInstance)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Type.GetHashCode() * 397) ^ Name.GetHashCode();
            }
        }
    }
}
