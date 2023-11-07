namespace SharpMetal.Generator
{
    public static class Types
    {
        public enum NativeType
        {
            Ulong,
            Uint,
            Int,
            Long,
            Byte,
            UShort,
            IntPtr,
            Void
        }

        public static readonly Dictionary<string, NativeType> TypeMap = new()
        {
            { "uint64_t", NativeType.Ulong },
            { "MTLTimestamp", NativeType.Ulong },
            { "NSUInteger", NativeType.Ulong },
            { "UInteger", NativeType.Ulong },

            { "NSInteger", NativeType.Long },

            { "uint16_t", NativeType.UShort },

            { "uint32_t", NativeType.Uint },

            { "int32_t", NativeType.Int },

            { "uint8_t", NativeType.Byte },

            { "id", NativeType.IntPtr },
            { "CFTimeInterval", NativeType.IntPtr },
            { "ErrorDomain", NativeType.IntPtr },
            { "Coder", NativeType.IntPtr },
            { "dispatch_queue_t", NativeType.IntPtr },
            { "dispatch_data_t", NativeType.IntPtr },
            { "IOSurfaceRef", NativeType.IntPtr },
            { "IOFileHandle", NativeType.IntPtr },
            { "IOScratchBuffer", NativeType.IntPtr },
            { "IOCommandQueue", NativeType.IntPtr },
            { "IOCommandQueueDescriptor", NativeType.IntPtr },
            { "_Class", NativeType.IntPtr},
            { "_ObjectType", NativeType.IntPtr },
            { "_Object", NativeType.IntPtr },
            { "MTLSharedEventNotificationBlock", NativeType.IntPtr},
            { "MTLCoordinate2D", NativeType.IntPtr },
            { "MTLAutoreleasedComputePipelineReflection", NativeType.IntPtr },
            { "MTLAutoreleasedRenderPipelineReflection", NativeType.IntPtr },
            { "MTLAutoreleasedArgument", NativeType.IntPtr },
            { "Enumerator<Object>", NativeType.IntPtr },
            { "size_t", NativeType.IntPtr },

            { "IntPtr", NativeType.IntPtr },
            { "void", NativeType.Void },
        };

        public static NativeType ConvertType(string type)
        {
            if (type == string.Empty)
            {
                return NativeType.Void;
            }

            if (TypeMap.TryGetValue(type, out var convertType))
            {
                return convertType;
            }

            return NativeType.Void;
        }
    }
}
