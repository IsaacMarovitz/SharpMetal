namespace SharpMetal.Generator
{
    public static class Types
    {
        public static string[] CSharpNativeTypes = { "bool", "ulong", "uint", "int", "float", "double", "long", "byte", "short", "ushort" };
        public static Dictionary<string, string> TypeMap = new()
        {
            { "uint64_t", "ulong" },
            { "MTLTimestamp", "ulong" },
            { "stduint64_t", "ulong" },
            { "NSUInteger", "ulong" },
            { "UInteger", "ulong" },
            { "unsigned long", "ulong" },
            { "unsigned long long", "ulong" },

            { "NSInteger", "long" },
            { "Integer", "long" },
            { "long long", "long" },

            { "unsigned short", "ushort" },
            { "char", "ushort" },
            { "unichar", "ushort" },
            { "uint16_t", "ushort" },

            { "uint32_t", "uint" },
            { "unsigned int", "uint" },

            { "int32_t", "int" },

            { "uint8_t", "byte" },
            { "unsigned char", "byte" },

            { "Enumerator<_KeyType>", "NSEnumerator" },
            { "IOScratchBufferAllocator", "MTLIOScratchBufferAllocator" },
            { "IOCommandBuffer", "MTLIOCommandBuffer" },
            { "IOCompressionMethod", "MTLIOCompressionMethod" },
            { "IOCompressionStatus", "MTLIOCompressionStatus" },

            { "stdfunction<void>&", "IntPtr" },
            { "Object**", "IntPtr" },
            { "id", "IntPtr" },
            { "CGSize", "IntPtr" },
            { "CFTimeInterval", "IntPtr" },
            { "TimeInterval", "IntPtr" },
            { "ErrorDomain", "IntPtr" },
            { "Coder", "IntPtr" },
            { "dispatch_queue_t", "IntPtr" },
            { "dispatch_data_t", "IntPtr" },
            { "IOSurfaceRef", "IntPtr" },
            { "IOFileHandle", "IntPtr" },
            { "IOScratchBuffer", "IntPtr" },
            { "IOCommandQueue", "IntPtr" },
            { "IOCommandQueueDescriptor", "IntPtr" },
            { "_Class", "IntPtr"},
            { "_ObjectType", "IntPtr" },
            { "_Object", "IntPtr" },
            { "MTLSharedEventNotificationBlock", "IntPtr"},
            { "MTLCoordinate2D", "IntPtr" },
            { "MTLAutoreleasedComputePipelineReflection", "IntPtr" },
            { "MTLAutoreleasedRenderPipelineReflection", "IntPtr" },
            { "MTLAutoreleasedArgument", "IntPtr" },
            { "Enumerator<Object>", "IntPtr" },
            { "size_t", "IntPtr" },

            { "IntPtr", "IntPtr" },
            { "void", "void" },
        };

        public static string ConvertType(string type, string namespacePrefix)
        {
            if (type == string.Empty)
            {
                return type;
            }

            type = type.Replace("::", "");

            if (CSharpNativeTypes.Contains(type))
            {
                return type;
            }

            if (TypeMap.TryGetValue(type, out var convertType))
            {
                return convertType;
            }

            var startsWithPrefix = false;
            //
            // foreach (var prefix in Namespaces.Prefixes)
            // {
            //     if (type.StartsWith(prefix))
            //     {
            //         startsWithPrefix = true;
            //     }
            // }

            if (!startsWithPrefix)
            {
                return namespacePrefix + type;
            }

            return type;
        }
    }
}
