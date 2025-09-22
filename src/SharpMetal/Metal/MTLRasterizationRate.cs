using System.Runtime.Versioning;
using SharpMetal.ObjectiveCCore;
using SharpMetal.Foundation;

namespace SharpMetal.Metal
{
    [SupportedOSPlatform("macos")]
    public struct MTLRasterizationRateLayerArray : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTLRasterizationRateLayerArray obj) => obj.NativePtr;
        public MTLRasterizationRateLayerArray(IntPtr ptr) => NativePtr = ptr;

        public MTLRasterizationRateLayerArray()
        {
            var cls = new ObjectiveCClass("MTLRasterizationRateLayerArray");
            NativePtr = cls.AllocInit();
        }

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public MTLRasterizationRateLayerDescriptor Object(ulong layerIndex)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_objectAtIndexedSubscript, layerIndex));
        }

        public void SetObject(MTLRasterizationRateLayerDescriptor layer, ulong layerIndex)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setObjectatIndexedSubscript, layer, layerIndex);
        }

        private static readonly Selector sel_objectAtIndexedSubscript = "objectAtIndexedSubscript:";
        private static readonly Selector sel_setObjectatIndexedSubscript = "setObject:atIndexedSubscript:";
        private static readonly Selector sel_release = "release";
    }

    [SupportedOSPlatform("macos")]
    public struct MTLRasterizationRateLayerDescriptor : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTLRasterizationRateLayerDescriptor obj) => obj.NativePtr;
        public MTLRasterizationRateLayerDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTLRasterizationRateLayerDescriptor()
        {
            var cls = new ObjectiveCClass("MTLRasterizationRateLayerDescriptor");
            NativePtr = cls.AllocInit();
        }

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public MTLRasterizationRateSampleArray Horizontal => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_horizontal));

        public float HorizontalSampleStorage => ObjectiveCRuntime.float_objc_msgSend(NativePtr, sel_horizontalSampleStorage);

        public MTLSize MaxSampleCount => ObjectiveCRuntime.MTLSize_objc_msgSend(NativePtr, sel_maxSampleCount);

        public MTLSize SampleCount
        {
            get => ObjectiveCRuntime.MTLSize_objc_msgSend(NativePtr, sel_sampleCount);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setSampleCount, value);
        }

        public MTLRasterizationRateSampleArray Vertical => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_vertical));

        public float VerticalSampleStorage => ObjectiveCRuntime.float_objc_msgSend(NativePtr, sel_verticalSampleStorage);

        public MTLRasterizationRateLayerDescriptor Init(MTLSize sampleCount)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_initWithSampleCount, sampleCount));
        }

        public MTLRasterizationRateLayerDescriptor Init(MTLSize sampleCount, float horizontal, float vertical)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_initWithSampleCounthorizontalvertical, sampleCount, horizontal, vertical));
        }

        private static readonly Selector sel_horizontal = "horizontal";
        private static readonly Selector sel_horizontalSampleStorage = "horizontalSampleStorage";
        private static readonly Selector sel_initWithSampleCount = "initWithSampleCount:";
        private static readonly Selector sel_initWithSampleCounthorizontalvertical = "initWithSampleCount:horizontal:vertical:";
        private static readonly Selector sel_maxSampleCount = "maxSampleCount";
        private static readonly Selector sel_sampleCount = "sampleCount";
        private static readonly Selector sel_setSampleCount = "setSampleCount:";
        private static readonly Selector sel_vertical = "vertical";
        private static readonly Selector sel_verticalSampleStorage = "verticalSampleStorage";
        private static readonly Selector sel_release = "release";
    }

    [SupportedOSPlatform("macos")]
    public struct MTLRasterizationRateMap : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTLRasterizationRateMap obj) => obj.NativePtr;
        public MTLRasterizationRateMap(IntPtr ptr) => NativePtr = ptr;

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public MTLDevice Device => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_device));

        public NSString Label => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_label));

        public ulong LayerCount => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_layerCount);

        public MTLSizeAndAlign ParameterBufferSizeAndAlign => ObjectiveCRuntime.MTLSizeAndAlign_objc_msgSend(NativePtr, sel_parameterBufferSizeAndAlign);

        public MTLSize PhysicalGranularity => ObjectiveCRuntime.MTLSize_objc_msgSend(NativePtr, sel_physicalGranularity);

        public MTLSize ScreenSize => ObjectiveCRuntime.MTLSize_objc_msgSend(NativePtr, sel_screenSize);

        public void CopyParameterDataToBuffer(MTLBuffer buffer, ulong offset)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_copyParameterDataToBufferoffset, buffer, offset);
        }

        public IntPtr MapPhysicalToScreenCoordinates(IntPtr physicalCoordinates, ulong layerIndex)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_mapPhysicalToScreenCoordinatesforLayer, physicalCoordinates, layerIndex));
        }

        public IntPtr MapScreenToPhysicalCoordinates(IntPtr screenCoordinates, ulong layerIndex)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_mapScreenToPhysicalCoordinatesforLayer, screenCoordinates, layerIndex));
        }

        public MTLSize PhysicalSize(ulong layerIndex)
        {
            return ObjectiveCRuntime.MTLSize_objc_msgSend(NativePtr, sel_physicalSizeForLayer, layerIndex);
        }

        private static readonly Selector sel_copyParameterDataToBufferoffset = "copyParameterDataToBuffer:offset:";
        private static readonly Selector sel_device = "device";
        private static readonly Selector sel_label = "label";
        private static readonly Selector sel_layerCount = "layerCount";
        private static readonly Selector sel_mapPhysicalToScreenCoordinatesforLayer = "mapPhysicalToScreenCoordinates:forLayer:";
        private static readonly Selector sel_mapScreenToPhysicalCoordinatesforLayer = "mapScreenToPhysicalCoordinates:forLayer:";
        private static readonly Selector sel_parameterBufferSizeAndAlign = "parameterBufferSizeAndAlign";
        private static readonly Selector sel_physicalGranularity = "physicalGranularity";
        private static readonly Selector sel_physicalSizeForLayer = "physicalSizeForLayer:";
        private static readonly Selector sel_screenSize = "screenSize";
        private static readonly Selector sel_release = "release";
    }

    [SupportedOSPlatform("macos")]
    public struct MTLRasterizationRateMapDescriptor : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTLRasterizationRateMapDescriptor obj) => obj.NativePtr;
        public MTLRasterizationRateMapDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTLRasterizationRateMapDescriptor()
        {
            var cls = new ObjectiveCClass("MTLRasterizationRateMapDescriptor");
            NativePtr = cls.AllocInit();
        }

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public NSString Label
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_label));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setLabel, value);
        }

        public ulong LayerCount => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_layerCount);

        public MTLRasterizationRateLayerArray Layers => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_layers));

        public MTLSize ScreenSize
        {
            get => ObjectiveCRuntime.MTLSize_objc_msgSend(NativePtr, sel_screenSize);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setScreenSize, value);
        }

        public MTLRasterizationRateLayerDescriptor Layer(ulong layerIndex)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_layerAtIndex, layerIndex));
        }

        public static MTLRasterizationRateMapDescriptor RasterizationRateMapDescriptor(MTLSize screenSize)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(new ObjectiveCClass("MTLRasterizationRateMapDescriptor"), sel_rasterizationRateMapDescriptorWithScreenSize, screenSize));
        }

        public static MTLRasterizationRateMapDescriptor RasterizationRateMapDescriptor(MTLSize screenSize, MTLRasterizationRateLayerDescriptor layer)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(new ObjectiveCClass("MTLRasterizationRateMapDescriptor"), sel_rasterizationRateMapDescriptorWithScreenSizelayer, screenSize, layer));
        }

        public static MTLRasterizationRateMapDescriptor RasterizationRateMapDescriptor(MTLSize screenSize, ulong layerCount, MTLRasterizationRateLayerDescriptor layers)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(new ObjectiveCClass("MTLRasterizationRateMapDescriptor"), sel_rasterizationRateMapDescriptorWithScreenSizelayerCountlayers, screenSize, layerCount, layers));
        }

        public void SetLayer(MTLRasterizationRateLayerDescriptor layer, ulong layerIndex)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setLayeratIndex, layer, layerIndex);
        }

        private static readonly Selector sel_label = "label";
        private static readonly Selector sel_layerAtIndex = "layerAtIndex:";
        private static readonly Selector sel_layerCount = "layerCount";
        private static readonly Selector sel_layers = "layers";
        private static readonly Selector sel_rasterizationRateMapDescriptorWithScreenSize = "rasterizationRateMapDescriptorWithScreenSize:";
        private static readonly Selector sel_rasterizationRateMapDescriptorWithScreenSizelayer = "rasterizationRateMapDescriptorWithScreenSize:layer:";
        private static readonly Selector sel_rasterizationRateMapDescriptorWithScreenSizelayerCountlayers = "rasterizationRateMapDescriptorWithScreenSize:layerCount:layers:";
        private static readonly Selector sel_screenSize = "screenSize";
        private static readonly Selector sel_setLabel = "setLabel:";
        private static readonly Selector sel_setLayeratIndex = "setLayer:atIndex:";
        private static readonly Selector sel_setScreenSize = "setScreenSize:";
        private static readonly Selector sel_release = "release";
    }

    [SupportedOSPlatform("macos")]
    public struct MTLRasterizationRateSampleArray : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTLRasterizationRateSampleArray obj) => obj.NativePtr;
        public MTLRasterizationRateSampleArray(IntPtr ptr) => NativePtr = ptr;

        public MTLRasterizationRateSampleArray()
        {
            var cls = new ObjectiveCClass("MTLRasterizationRateSampleArray");
            NativePtr = cls.AllocInit();
        }

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public NSNumber Object(ulong index)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_objectAtIndexedSubscript, index));
        }

        public void SetObject(NSNumber value, ulong index)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setObjectatIndexedSubscript, value, index);
        }

        private static readonly Selector sel_objectAtIndexedSubscript = "objectAtIndexedSubscript:";
        private static readonly Selector sel_setObjectatIndexedSubscript = "setObject:atIndexedSubscript:";
        private static readonly Selector sel_release = "release";
    }
}
