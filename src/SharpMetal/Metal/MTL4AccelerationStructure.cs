using System.Runtime.Versioning;
using SharpMetal.ObjectiveCCore;
using SharpMetal.Foundation;

namespace SharpMetal.Metal
{
    [SupportedOSPlatform("macos")]
    public struct MTL4AccelerationStructureBoundingBoxGeometryDescriptor : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTL4AccelerationStructureBoundingBoxGeometryDescriptor obj) => obj.NativePtr;
        public static implicit operator MTL4AccelerationStructureGeometryDescriptor(MTL4AccelerationStructureBoundingBoxGeometryDescriptor obj) => new(obj.NativePtr);
        public MTL4AccelerationStructureBoundingBoxGeometryDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTL4AccelerationStructureBoundingBoxGeometryDescriptor()
        {
            var cls = new ObjectiveCClass("MTL4AccelerationStructureBoundingBoxGeometryDescriptor");
            NativePtr = cls.AllocInit();
        }

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }










        private static readonly Selector sel_release = "release";
    }

    [SupportedOSPlatform("macos")]
    public struct MTL4AccelerationStructureCurveGeometryDescriptor : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTL4AccelerationStructureCurveGeometryDescriptor obj) => obj.NativePtr;
        public static implicit operator MTL4AccelerationStructureGeometryDescriptor(MTL4AccelerationStructureCurveGeometryDescriptor obj) => new(obj.NativePtr);
        public MTL4AccelerationStructureCurveGeometryDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTL4AccelerationStructureCurveGeometryDescriptor()
        {
            var cls = new ObjectiveCClass("MTL4AccelerationStructureCurveGeometryDescriptor");
            NativePtr = cls.AllocInit();
        }

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }





















        private static readonly Selector sel_release = "release";
    }

    [SupportedOSPlatform("macos")]
    public struct MTL4AccelerationStructureDescriptor : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTL4AccelerationStructureDescriptor obj) => obj.NativePtr;
        public static implicit operator MTLAccelerationStructureDescriptor(MTL4AccelerationStructureDescriptor obj) => new(obj.NativePtr);
        public MTL4AccelerationStructureDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTL4AccelerationStructureDescriptor()
        {
            var cls = new ObjectiveCClass("MTL4AccelerationStructureDescriptor");
            NativePtr = cls.AllocInit();
        }

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }

        public MTLAccelerationStructureUsage Usage
        {
            get => (MTLAccelerationStructureUsage)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_usage);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setUsage, (ulong)value);
        }

        private static readonly Selector sel_setUsage = "setUsage:";
        private static readonly Selector sel_usage = "usage";
        private static readonly Selector sel_release = "release";
    }

    [SupportedOSPlatform("macos")]
    public struct MTL4AccelerationStructureGeometryDescriptor : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTL4AccelerationStructureGeometryDescriptor obj) => obj.NativePtr;
        public MTL4AccelerationStructureGeometryDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTL4AccelerationStructureGeometryDescriptor()
        {
            var cls = new ObjectiveCClass("MTL4AccelerationStructureGeometryDescriptor");
            NativePtr = cls.AllocInit();
        }

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }







        private static readonly Selector sel_release = "release";
    }

    [SupportedOSPlatform("macos")]
    public struct MTL4AccelerationStructureMotionBoundingBoxGeometryDescriptor : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTL4AccelerationStructureMotionBoundingBoxGeometryDescriptor obj) => obj.NativePtr;
        public static implicit operator MTL4AccelerationStructureGeometryDescriptor(MTL4AccelerationStructureMotionBoundingBoxGeometryDescriptor obj) => new(obj.NativePtr);
        public MTL4AccelerationStructureMotionBoundingBoxGeometryDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTL4AccelerationStructureMotionBoundingBoxGeometryDescriptor()
        {
            var cls = new ObjectiveCClass("MTL4AccelerationStructureMotionBoundingBoxGeometryDescriptor");
            NativePtr = cls.AllocInit();
        }

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }










        private static readonly Selector sel_release = "release";
    }

    [SupportedOSPlatform("macos")]
    public struct MTL4AccelerationStructureMotionCurveGeometryDescriptor : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTL4AccelerationStructureMotionCurveGeometryDescriptor obj) => obj.NativePtr;
        public static implicit operator MTL4AccelerationStructureGeometryDescriptor(MTL4AccelerationStructureMotionCurveGeometryDescriptor obj) => new(obj.NativePtr);
        public MTL4AccelerationStructureMotionCurveGeometryDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTL4AccelerationStructureMotionCurveGeometryDescriptor()
        {
            var cls = new ObjectiveCClass("MTL4AccelerationStructureMotionCurveGeometryDescriptor");
            NativePtr = cls.AllocInit();
        }

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }





















        private static readonly Selector sel_release = "release";
    }

    [SupportedOSPlatform("macos")]
    public struct MTL4AccelerationStructureMotionTriangleGeometryDescriptor : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTL4AccelerationStructureMotionTriangleGeometryDescriptor obj) => obj.NativePtr;
        public static implicit operator MTL4AccelerationStructureGeometryDescriptor(MTL4AccelerationStructureMotionTriangleGeometryDescriptor obj) => new(obj.NativePtr);
        public MTL4AccelerationStructureMotionTriangleGeometryDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTL4AccelerationStructureMotionTriangleGeometryDescriptor()
        {
            var cls = new ObjectiveCClass("MTL4AccelerationStructureMotionTriangleGeometryDescriptor");
            NativePtr = cls.AllocInit();
        }

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }















        private static readonly Selector sel_release = "release";
    }

    [SupportedOSPlatform("macos")]
    public struct MTL4AccelerationStructureTriangleGeometryDescriptor : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTL4AccelerationStructureTriangleGeometryDescriptor obj) => obj.NativePtr;
        public static implicit operator MTL4AccelerationStructureGeometryDescriptor(MTL4AccelerationStructureTriangleGeometryDescriptor obj) => new(obj.NativePtr);
        public MTL4AccelerationStructureTriangleGeometryDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTL4AccelerationStructureTriangleGeometryDescriptor()
        {
            var cls = new ObjectiveCClass("MTL4AccelerationStructureTriangleGeometryDescriptor");
            NativePtr = cls.AllocInit();
        }

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }















        private static readonly Selector sel_release = "release";
    }

    [SupportedOSPlatform("macos")]
    public struct MTL4IndirectInstanceAccelerationStructureDescriptor : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTL4IndirectInstanceAccelerationStructureDescriptor obj) => obj.NativePtr;
        public static implicit operator MTL4AccelerationStructureDescriptor(MTL4IndirectInstanceAccelerationStructureDescriptor obj) => new(obj.NativePtr);
        public MTL4IndirectInstanceAccelerationStructureDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTL4IndirectInstanceAccelerationStructureDescriptor()
        {
            var cls = new ObjectiveCClass("MTL4IndirectInstanceAccelerationStructureDescriptor");
            NativePtr = cls.AllocInit();
        }

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }












        public MTLAccelerationStructureUsage Usage
        {
            get => (MTLAccelerationStructureUsage)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_usage);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setUsage, (ulong)value);
        }

        private static readonly Selector sel_setUsage = "setUsage:";
        private static readonly Selector sel_usage = "usage";
        private static readonly Selector sel_release = "release";
    }

    [SupportedOSPlatform("macos")]
    public struct MTL4InstanceAccelerationStructureDescriptor : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTL4InstanceAccelerationStructureDescriptor obj) => obj.NativePtr;
        public static implicit operator MTL4AccelerationStructureDescriptor(MTL4InstanceAccelerationStructureDescriptor obj) => new(obj.NativePtr);
        public MTL4InstanceAccelerationStructureDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTL4InstanceAccelerationStructureDescriptor()
        {
            var cls = new ObjectiveCClass("MTL4InstanceAccelerationStructureDescriptor");
            NativePtr = cls.AllocInit();
        }

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }










        public MTLAccelerationStructureUsage Usage
        {
            get => (MTLAccelerationStructureUsage)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_usage);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setUsage, (ulong)value);
        }

        private static readonly Selector sel_setUsage = "setUsage:";
        private static readonly Selector sel_usage = "usage";
        private static readonly Selector sel_release = "release";
    }

    [SupportedOSPlatform("macos")]
    public struct MTL4PrimitiveAccelerationStructureDescriptor : IDisposable
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTL4PrimitiveAccelerationStructureDescriptor obj) => obj.NativePtr;
        public static implicit operator MTL4AccelerationStructureDescriptor(MTL4PrimitiveAccelerationStructureDescriptor obj) => new(obj.NativePtr);
        public MTL4PrimitiveAccelerationStructureDescriptor(IntPtr ptr) => NativePtr = ptr;

        public MTL4PrimitiveAccelerationStructureDescriptor()
        {
            var cls = new ObjectiveCClass("MTL4PrimitiveAccelerationStructureDescriptor");
            NativePtr = cls.AllocInit();
        }

        public void Dispose()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_release);
        }







        public MTLAccelerationStructureUsage Usage
        {
            get => (MTLAccelerationStructureUsage)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_usage);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setUsage, (ulong)value);
        }

        private static readonly Selector sel_setUsage = "setUsage:";
        private static readonly Selector sel_usage = "usage";
        private static readonly Selector sel_release = "release";
    }
}
