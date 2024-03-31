using CppAst;

namespace SharpMetal.Generator.Utilities
{
    public static class StringUtils
    {
        /// <summary>
        /// Turns camelCase text to PascaleCase.
        /// </summary>
        /// <param name="value">Input value in camelCase</param>
        /// <returns>Input value in PascaleCase</returns>
        public static string CamelToPascale(string value)
        {
            if (value != string.Empty)
            {
                var firstChar = char.ToUpper(value[0]);
                return firstChar + value[1..];
            }

            return value;
        }

        public static string FunctionSignatureCleanup(string value)
        {
            value = value.Replace(";", "");
            value = value.Replace("~", "Destroy");
            value = value.Replace("::", "");
            value = value.Replace("void*", "IntPtr");
            value = value.Replace("void()", "void");
            value = value.Replace("*", "");
            value = value.Replace("class ", "");
            value = value.Replace("const ", "");
            return value;
        }

        public static bool IsValidFunctionSignature(string value)
        {
            return !(value.Contains("template") || value.Contains("^") || value.Contains("=") || value.Contains("typename") || value.Contains("operator") || value.Contains("std::function") || value.Contains("Handler") || value.Contains("Observer"));
        }

        public static string VisibilityToString(CppVisibility visibility)
        {
            return visibility switch
            {
                CppVisibility.Default => "public",
                CppVisibility.Public => "public",
                CppVisibility.Private => "private",
                CppVisibility.Protected => "protected",
                _ => throw new ArgumentOutOfRangeException(nameof(visibility), visibility, null)
            };
        }

        public static string TypeToString(CppType type)
        {
            var primitiveType = TypeToPrimitive(type);

            if (primitiveType is CppClass cppClass)
            {
                return cppClass.Name;
            }

            if (primitiveType is CppPrimitiveType cppPrimitiveType)
            {
                return PrimitiveToString(cppPrimitiveType.Kind);
            }

            return primitiveType.GetDisplayName();
        }

        public static CppType TypeToPrimitive(CppType type)
        {
            if (type.TypeKind == CppTypeKind.Typedef)
            {
                var typedef = type as CppTypedef;
                return TypeToPrimitive(typedef.ElementType);
            }

            return type;
        }

        public static string PrimitiveToString(CppPrimitiveKind primitive)
        {
            return primitive switch
            {
                CppPrimitiveKind.Void => "void",
                CppPrimitiveKind.Bool => "bool",
                CppPrimitiveKind.Char => "ushort",
                CppPrimitiveKind.Short => "short",
                CppPrimitiveKind.Int => "int",
                CppPrimitiveKind.LongLong => "long",
                CppPrimitiveKind.UnsignedChar => "byte",
                CppPrimitiveKind.UnsignedShort => "ushort",
                CppPrimitiveKind.UnsignedInt => "uint",
                CppPrimitiveKind.UnsignedLongLong => "ulong",
                CppPrimitiveKind.Float => "float",
                CppPrimitiveKind.Double => "double",
                _ => throw new ArgumentOutOfRangeException(nameof(primitive), primitive, null)
            };
        }
    }
}
