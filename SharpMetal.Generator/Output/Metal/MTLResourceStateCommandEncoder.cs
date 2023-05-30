using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using SharpMetal.ObjectiveC;

namespace SharpMetal
{
    public enum MTLSparseTextureMappingMode: ulong
    {
        Map = 0,
        Unmap = 1,
    }

    [SupportedOSPlatform("macos")]
    [StructLayout(LayoutKind.Sequential)]
    public struct MTLMapIndirectArguments
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLMapIndirectArguments obj) => obj.NativePtr;
        public MTLMapIndirectArguments(IntPtr ptr) => NativePtr = ptr;

        public uint regionOriginX;
        public uint regionOriginY;
        public uint regionOriginZ;
        public uint regionSizeWidth;
        public uint regionSizeHeight;
        public uint regionSizeDepth;
        public uint mipMapLevel;
        public uint sliceId;
    }

    [SupportedOSPlatform("macos")]
    public struct MTLResourceStateCommandEncoder
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLResourceStateCommandEncoder obj) => obj.NativePtr;
        public MTLResourceStateCommandEncoder(IntPtr ptr) => NativePtr = ptr;

        private static readonly Selector sel_updateTextureMappingsmoderegionsmipLevelsslicesnumRegions = "updateTextureMappings:mode:regions:mipLevels:slices:numRegions:";
        private static readonly Selector sel_updateTextureMappingmoderegionmipLevelslice = "updateTextureMapping:mode:region:mipLevel:slice:";
        private static readonly Selector sel_updateTextureMappingmodeindirectBufferindirectBufferOffset = "updateTextureMapping:mode:indirectBuffer:indirectBufferOffset:";
        private static readonly Selector sel_updateFence = "updateFence:";
        private static readonly Selector sel_waitForFence = "waitForFence:";
        private static readonly Selector sel_moveTextureMappingsFromTexturesourceSlicesourceLevelsourceOriginsourceSizetoTexturedestinationSlicedestinationLeveldestinationOrigin = "moveTextureMappingsFromTexture:sourceSlice:sourceLevel:sourceOrigin:sourceSize:toTexture:destinationSlice:destinationLevel:destinationOrigin:";
    }
}
