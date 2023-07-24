using System.Runtime.Versioning;

namespace SharpMetal.ObjectiveCCore
{
    [SupportedOSPlatform("macos")]
    public struct ObjectiveCClass
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(ObjectiveCClass c) => c.NativePtr;

        public ObjectiveCClass(IntPtr ptr)
        {
            NativePtr = ptr;
        }

        public ObjectiveCClass(string name)
        {
            var ptr = ObjectiveC.objc_getClass(name);

            if (ptr == IntPtr.Zero)
            {
                Console.WriteLine($"Failed to get class {name}!");
            }

            NativePtr = ptr;
        }

        public ObjectiveCClass AllocInit()
        {
            var value = ObjectiveC.IntPtr_objc_msgSend(NativePtr, "alloc");
            ObjectiveC.objc_msgSend(value, "init");
            return new ObjectiveCClass(value);
        }

        public ObjectiveCClass Alloc()
        {
            var value = ObjectiveC.IntPtr_objc_msgSend(NativePtr, "alloc");
            return new ObjectiveCClass(value);
        }

        public void SendMessage(Selector selector)
        {
            ObjectiveC.objc_msgSend(NativePtr, selector);
        }

        public void SendMessage(Selector selector, byte value)
        {
            ObjectiveC.objc_msgSend(NativePtr, selector, value);
        }

        public void SendMessage(Selector selector, ObjectiveCClass objectiveCClass)
        {
            ObjectiveC.objc_msgSend(NativePtr, selector, objectiveCClass.NativePtr);
        }

        public void SendMessage(Selector selector, ObjectiveC.NSRect point)
        {
            ObjectiveC.objc_msgSend(NativePtr, selector, point);
        }

        public void SendMessage(Selector selector, ObjectiveC.NSRect rect, ulong a, ulong b, byte c)
        {
            ObjectiveC.objc_msgSend(NativePtr, selector, rect, a, b, c);
        }

        public void SendMessage(Selector selector, ObjectiveC.NSRect frame, byte value)
        {
            ObjectiveC.objc_msgSend(NativePtr, selector, frame, value);
        }

        public void SendMessage(Selector selector, double value)
        {
            ObjectiveC.objc_msgSend(NativePtr, selector, value);
        }
    }
}
