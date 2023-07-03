using SharpMetal.Foundation;

namespace SharpMetal.Metal
{
    public enum MTLIOCompressionStatus : long
    {
        Complete = 0,
        Error = 1,
    }

    public static class MTLIOCompressor
    {
        public static IntPtr IOCompressionContextDefaultChunkSize()
        {
            throw new NotImplementedException();
        }

        public static IntPtr IOCreateCompressionContext(ushort path, MTLIOCompressionMethod type, IntPtr chunkSize)
        {
            throw new NotImplementedException();
        }

        public static void IOCompressionContextAppendData(IntPtr context, IntPtr data, IntPtr size)
        {
            throw new NotImplementedException();
        }

        public static MTLIOCompressionStatus IOFlushAndDestroyCompressionContext(IntPtr context)
        {
            throw new NotImplementedException();
        }
    }
}
