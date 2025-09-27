using SharpMetal.ObjectiveCCore;

namespace SharpMetal.Metal
{
    public partial struct MTLSamplerDescriptor
    {
        /// <summary>
        /// This is a private Metal API.
        /// It is not recommended for use in any production applications,
        /// and may break at any time without warning. Hic sunt dracones.
        /// </summary>
        public float LodBias
        {
            get => ObjectiveCRuntime.float_objc_msgSend(NativePtr, sel_lodBias);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setLodBias, value);
        }

        private static readonly Selector sel_lodBias = "lodBias";
        private static readonly Selector sel_setLodBias = "setLodBias:";
    }
}
