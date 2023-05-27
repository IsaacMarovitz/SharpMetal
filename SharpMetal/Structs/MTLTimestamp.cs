namespace SharpMetal
{
    public struct MTLTimestamp
    {
        public ulong Value;
        public MTLTimestamp(ulong value) => Value = value;
        public static implicit operator ulong(MTLTimestamp timestamp) => timestamp.Value;
    }
}