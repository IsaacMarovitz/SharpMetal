using CppAst;

namespace SharpMetal.Generator.Utilities
{
    public static class VisibilityStringise
    {
        public static string VisibilityAsString(CppVisibility visibility)
        {
            return visibility switch
            {
                CppVisibility.Default => "public",
                CppVisibility.Public => "public",
                CppVisibility.Private => "private",
                CppVisibility.Protected => "protected"
            };
        }
    }
}
