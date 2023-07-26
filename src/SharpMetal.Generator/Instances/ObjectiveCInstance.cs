namespace SharpMetal.Generator.Instances
{
    public class ObjectiveCInstance : IEquatable<ObjectiveCInstance>, IComparable<ObjectiveCInstance>
    {
        public string Type;
        public List<string> Inputs;
        public static string[] VarNames = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };

        public ObjectiveCInstance(string type, List<string> inputs)
        {
            Type = type;
            Inputs = inputs;
        }

        public void Generate(CodeGenContext context)
        {
            context.WriteLine("[LibraryImport(ObjectiveC.ObjCRuntime, EntryPoint = \"objc_msgSend\")]");
            if (Type == "bool")
            {
                context.WriteLine("[return: MarshalAs(UnmanagedType.Bool)]");
            }
            context.Write($"{context.Indentation}public static partial {Type} ");

            if (Type != "void")
            {
                context.Write($"{Type}_");
            }

            context.Write("objc_msgSend(IntPtr receiver, IntPtr selector");

            for (var i = 0; i < Inputs.Count; i++)
            {
                context.Write(", ");

                if (Inputs[i] == "bool")
                {
                    context.Write("[MarshalAs(UnmanagedType.Bool)] ");
                }

                context.Write($"{Inputs[i]} {VarNames[i]}");
            }

            context.Write(");\n");
        }

        public bool Equals(ObjectiveCInstance? other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Type == other.Type && Inputs.All(other.Inputs.Contains) && other.Inputs.All(Inputs.Contains);
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
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
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            return string.Compare(Type, other.Type, StringComparison.Ordinal);
        }
    }
}
