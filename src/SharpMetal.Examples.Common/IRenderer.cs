using System.Runtime.Versioning;
using SharpMetal.Metal;

namespace SharpMetal.Examples.Common
{
    [SupportedOSPlatform("macos")]
    public interface IRenderer
    {
        static abstract IRenderer Init(MTLDevice device);
        void Draw(MTKView view);
    }
}
