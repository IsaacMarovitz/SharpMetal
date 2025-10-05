namespace SharpMetal.Generator.Instances
{
    public class FunctionParameterInstance : IEquatable<FunctionParameterInstance>
    {
        public readonly string Type;
        public readonly string Name;
        public readonly bool Reference;

        public FunctionParameterInstance(string type, string name, bool reference = false)
        {
            Type = type;
            Name = name;
            Reference = reference;
        }

        public bool Equals(FunctionParameterInstance? other)
        {
            if (other is null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Type == other.Type && Name == other.Name && Reference == other.Reference;
        }

        public override bool Equals(object? obj)
        {
            if (obj is null)
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

            return Equals((FunctionParameterInstance)obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Type, Name, Reference);
        }
    }
}
