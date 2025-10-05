namespace SharpMetal.Generator.Instances
{
    public class ObjectiveCInstance : IEquatable<ObjectiveCInstance>, IComparable<ObjectiveCInstance>
    {
        public readonly string Type;
        public readonly string[] Inputs;

        public ObjectiveCInstance(string type, List<string> inputs)
        {
            Type = type;
            Inputs = inputs.ToArray();
        }

        public bool Equals(ObjectiveCInstance? other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Type == other.Type && Inputs.All(other.Inputs.Contains) && other.Inputs.All(Inputs.Contains);
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

            return Equals((ObjectiveCInstance)obj);
        }

        public override int GetHashCode()
        {
            var hashCode = new HashCode();

            foreach (var input in Inputs)
            {
                hashCode.Add(input);
            }

            hashCode.Add(Type);

            return hashCode.ToHashCode();
        }

        public int CompareTo(ObjectiveCInstance? other)
        {
            if (ReferenceEquals(this, other))
            {
                return 0;
            }

            if (ReferenceEquals(null, other))
            {
                return 1;
            }

            return string.Compare(Type, other.Type, StringComparison.Ordinal);
        }
    }
}
