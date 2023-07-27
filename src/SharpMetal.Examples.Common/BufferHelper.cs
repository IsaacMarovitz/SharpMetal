using System.Runtime.Versioning;
using SharpMetal.Metal;

namespace SharpMetal.Examples.Common
{
    [SupportedOSPlatform("macos")]
    public static class BufferHelper
    {
        public static unsafe void CopyToBuffer<T>(T[] source, MTLBuffer buffer)
        {
            var span = new Span<T>(buffer.Contents.ToPointer(), source.Length);
            source.CopyTo(span);
        }
    }
}
