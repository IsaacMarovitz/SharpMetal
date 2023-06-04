using System.Runtime.Versioning;
using SharpMetal.ObjectiveC;

namespace SharpMetal
{
    [SupportedOSPlatform("macos")]
    public struct MTLRasterizationRateSampleArray
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLRasterizationRateSampleArray obj) => obj.NativePtr;
        public MTLRasterizationRateSampleArray(IntPtr ptr) => NativePtr = ptr;

        public MTLRasterizationRateSampleArray()
        {
            var cls = new ObjectiveCClass("MTLRasterizationRateSampleArray");
            NativePtr = cls.AllocInit();
        }

        private static readonly Selector sel_objectAtIndexedSubscript = "objectAtIndexedSubscript:";
        private static readonly Selector sel_setObjectatIndexedSubscript = "setObject:atIndexedSubscript:";
    }

    [SupportedOSPlatform("macos")]
    public struct MTLRasterizationRateLayerDescriptor
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLRasterizationRateLayerDescriptor obj) => obj.NativePtr;
        public MTLRasterizationRateLayerDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTLRasterizationRateLayerDescriptor()
        {
            var cls = new ObjectiveCClass("MTLRasterizationRateLayerDescriptor");
            NativePtr = cls.AllocInit();
        }

        public MTLSize SampleCount
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_sampleCount));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setSampleCount, value);
        }
        public MTLSize MaxSampleCount => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_maxSampleCount));
        public float HorizontalSampleStorage => ObjectiveCRuntime.float_objc_msgSend(NativePtr, sel_horizontalSampleStorage);
        public float VerticalSampleStorage => ObjectiveCRuntime.float_objc_msgSend(NativePtr, sel_verticalSampleStorage);
        public MTLRasterizationRateSampleArray Horizontal => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_horizontal));
        public MTLRasterizationRateSampleArray Vertical => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_vertical));

        private static readonly Selector sel_initWithSampleCount = "initWithSampleCount:";
        private static readonly Selector sel_initWithSampleCounthorizontalvertical = "initWithSampleCount:horizontal:vertical:";
        private static readonly Selector sel_sampleCount = "sampleCount";
        private static readonly Selector sel_maxSampleCount = "maxSampleCount";
        private static readonly Selector sel_horizontalSampleStorage = "horizontalSampleStorage";
        private static readonly Selector sel_verticalSampleStorage = "verticalSampleStorage";
        private static readonly Selector sel_horizontal = "horizontal";
        private static readonly Selector sel_vertical = "vertical";
        private static readonly Selector sel_setSampleCount = "setSampleCount:";
    }

    [SupportedOSPlatform("macos")]
    public struct MTLRasterizationRateLayerArray
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLRasterizationRateLayerArray obj) => obj.NativePtr;
        public MTLRasterizationRateLayerArray(IntPtr ptr) => NativePtr = ptr;

        public MTLRasterizationRateLayerArray()
        {
            var cls = new ObjectiveCClass("MTLRasterizationRateLayerArray");
            NativePtr = cls.AllocInit();
        }

        private static readonly Selector sel_objectAtIndexedSubscript = "objectAtIndexedSubscript:";
        private static readonly Selector sel_setObjectatIndexedSubscript = "setObject:atIndexedSubscript:";
    }

    [SupportedOSPlatform("macos")]
    public struct MTLRasterizationRateMapDescriptor
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLRasterizationRateMapDescriptor obj) => obj.NativePtr;
        public MTLRasterizationRateMapDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTLRasterizationRateMapDescriptor()
        {
            var cls = new ObjectiveCClass("MTLRasterizationRateMapDescriptor");
            NativePtr = cls.AllocInit();
        }

        public MTLRasterizationRateLayerArray Layers => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_layers));
        public MTLSize ScreenSize
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_screenSize));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setScreenSize, value);
        }
        public NSString Label
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_label));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setLabel, value);
        }
        public ulong LayerCount => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_layerCount);

        private static readonly Selector sel_rasterizationRateMapDescriptorWithScreenSize = "rasterizationRateMapDescriptorWithScreenSize:";
        private static readonly Selector sel_rasterizationRateMapDescriptorWithScreenSizelayer = "rasterizationRateMapDescriptorWithScreenSize:layer:";
        private static readonly Selector sel_rasterizationRateMapDescriptorWithScreenSizelayerCountlayers = "rasterizationRateMapDescriptorWithScreenSize:layerCount:layers:";
        private static readonly Selector sel_layerAtIndex = "layerAtIndex:";
        private static readonly Selector sel_setLayeratIndex = "setLayer:atIndex:";
        private static readonly Selector sel_layers = "layers";
        private static readonly Selector sel_screenSize = "screenSize";
        private static readonly Selector sel_setScreenSize = "setScreenSize:";
        private static readonly Selector sel_label = "label";
        private static readonly Selector sel_setLabel = "setLabel:";
        private static readonly Selector sel_layerCount = "layerCount";
    }

    [SupportedOSPlatform("macos")]
    public struct MTLRasterizationRateMap
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(MTLRasterizationRateMap obj) => obj.NativePtr;
        public MTLRasterizationRateMap(IntPtr ptr) => NativePtr = ptr;

        public MTLDevice Device => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_device));
        public NSString Label => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_label));
        public MTLSize ScreenSize => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_screenSize));
        public MTLSize PhysicalGranularity => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_physicalGranularity));
        public ulong LayerCount => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_layerCount);
        public MTLSizeAndAlign ParameterBufferSizeAndAlign => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_parameterBufferSizeAndAlign));

        private static readonly Selector sel_device = "device";
        private static readonly Selector sel_label = "label";
        private static readonly Selector sel_screenSize = "screenSize";
        private static readonly Selector sel_physicalGranularity = "physicalGranularity";
        private static readonly Selector sel_layerCount = "layerCount";
        private static readonly Selector sel_parameterBufferSizeAndAlign = "parameterBufferSizeAndAlign";
        private static readonly Selector sel_copyParameterDataToBufferoffset = "copyParameterDataToBuffer:offset:";
        private static readonly Selector sel_physicalSizeForLayer = "physicalSizeForLayer:";
        private static readonly Selector sel_mapScreenToPhysicalCoordinatesforLayer = "mapScreenToPhysicalCoordinates:forLayer:";
        private static readonly Selector sel_mapPhysicalToScreenCoordinatesforLayer = "mapPhysicalToScreenCoordinates:forLayer:";
    }
}
