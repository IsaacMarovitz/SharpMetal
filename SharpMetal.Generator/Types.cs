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

            { "Object**", "IntPtr" },
            { "id", "IntPtr" },
            { "CGSize", "IntPtr" },
            { "dispatch_queue_t", "IntPtr" },
            { "CFTimeInterval", "IntPtr" },
            { "ErrorDomain", "IntPtr" },
            { "TimeInterval", "IntPtr" },
            { "IOSurfaceRef", "IntPtr" },
            { "IOFileHandle", "IntPtr" },
            { "IOScratchBuffer", "IntPtr" },
            { "_Class", "IntPtr"},
            { "_ObjectType", "IntPtr" },
            { "IntPtr", "IntPtr" },
            { "MTLSharedEventNotificationBlock", "IntPtr"},
            { "MTLCoordinate2D", "IntPtr" },
            { "Coder", "IntPtr" },
            { "_Object", "IntPtr" },
            { "stdfunction<void>&", "IntPtr" },
            { "void", "void" }
        };

        public static string ConvertType(string type, string namespacePrefix)
        {
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

            foreach (var prefix in Namespaces.Prefixes)
            {
                if (type.StartsWith(prefix))
                {
                    startsWithPrefix = true;
                }
            }

            if (!startsWithPrefix)
            {
                return namespacePrefix + type;
            }

            return type;
        }
    }
}