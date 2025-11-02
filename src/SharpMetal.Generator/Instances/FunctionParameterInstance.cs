namespace SharpMetal.Generator.Instances
{
    public class FunctionParameterInstance : IEquatable<FunctionParameterInstance>
    {
        public readonly string Type;
        public readonly string Name;
        public readonly bool Reference;
        public readonly bool Array;

        public FunctionParameterInstance(string type, string name, bool reference, bool array)
        {
            Type = type;
            Name = name;
            Reference = reference;
            Array = array;
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

            return Type == other.Type && Name == other.Name && Reference == other.Reference && Array == other.Array;
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

            return obj.GetType() == GetType() && Equals((FunctionParameterInstance)obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Type, Name, Reference, Array);
        }
    }
}
