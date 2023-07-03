using System.Runtime.Versioning;

namespace SharpMetal.Foundation
{
    [SupportedOSPlatform("macos")]
    public class NSSharedPtr
    {
        public readonly IntPtr NativePtr;
        public static implicit operator IntPtr(NSSharedPtr obj) => obj.NativePtr;
        public NSSharedPtr(IntPtr ptr) => NativePtr = ptr;

        public NS DestroySharedPtr;

        public IntPtr Get;

        public NS SharedPtr(NSSharedPtr<_Class>& other)
        {
            throw new NotImplementedException();
        }

        public NS SharedPtr()
        {
            throw new NotImplementedException();
        }

        public NS SharedPtr(NSSharedPtr<_Class>&& other)
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        public void Detach()
        {
            throw new NotImplementedException();
        }

        public NSfriend SharedPtr<_OtherClass> RetainPtr(NS_OtherClass ptr)
        {
            throw new NotImplementedException();
        }

        public NSfriend SharedPtr<_OtherClass> TransferPtr(NS_OtherClass ptr)
        {
            throw new NotImplementedException();
        }
    }
}
