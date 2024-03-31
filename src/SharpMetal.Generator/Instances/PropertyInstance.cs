namespace SharpMetal.Generator.Instances
{
    public class PropertyInstance : IEquatable<PropertyInstance>
    {
        public string Type;
        public string Name;
        public bool Reference;

        public PropertyInstance(string type, string name, bool reference = false)
        {
            Type = type;
            Name = name;
            Reference = reference;
        }

        public void Generate(CodeGenContext context)
        {
            context.WriteLine($"public {Type} {Name};");
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

            if (obj.GetType() != this.GetType())
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
