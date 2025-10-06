using SharpMetal.Generator.Instances;
using SharpMetal.Generator.Linked;

namespace SharpMetal.Generator
{
    public class ModelLinker
    {
        public List<CSharpFile> Link(List<HeaderInfo> headers, List<SelectorDefinition> selectorDefinitions, HashSet<ObjectiveCInstance> objectiveCInstances)
        {
            var rv = new List<CSharpFile>();

            foreach (var header in headers)
            {
                var outputFile = new CSharpFile(header.FileName, header.FullNamespace);
                var ns = outputFile.GetOrCreateNamespace($"SharpMetal.{header.FullNamespace}");

                header.EnumInstances.Sort((a, b) => string.Compare(a.Name, b.Name, StringComparison.InvariantCultureIgnoreCase));
                header.StructInstances.Sort((a, b) => string.Compare(a.Name, b.Name, StringComparison.InvariantCultureIgnoreCase));
                header.ClassInstances.Sort((a, b) => string.Compare(a.Name, b.Name, StringComparison.InvariantCultureIgnoreCase));

                foreach (var enumInstance in header.EnumInstances)
                {
                    var csEnum = new CSharpEnumType(enumInstance.Name);
                    csEnum.SetPrimitiveType(enumInstance.Type);
                    csEnum.AddValues(enumInstance.Values);
                    if (enumInstance.IsFlag)
                    {
                        csEnum.MarkAsFlags();
                    }
                    ns.AddType(csEnum);
                }

                foreach (var structInstance in header.StructInstances)
                {
                    var csStruct = new CSharpStructType(structInstance.Name);
                    foreach (var memberVariable in structInstance.MemberVariableInstances)
                    {
                        csStruct.AddMember(new CSharpField(memberVariable.Type, memberVariable.Name));
                    }
                    // Mark as sequential layout
                    csStruct.Attributes.Add("[StructLayout(LayoutKind.Sequential)]");
                    ns.AddType(csStruct);
                }

                foreach (var classInstance in header.ClassInstances)
                {

                }

                AddUsings(outputFile, header);

                rv.Add(outputFile);
            }

            return rv;
        }

        private static void AddUsings(CSharpFile outputFile, HeaderInfo headerInfo)
        {
            if (headerInfo.StructInstances.Count != 0)
            {
                outputFile.AddUsing("System.Runtime.InteropServices");
            }

            if (headerInfo.StructInstances.Count != 0 || headerInfo.ClassInstances.Count != 0 || headerInfo.EnumInstances.Count != 0)
            {
                outputFile.AddUsing("System.Runtime.Versioning");
            }

            // If have any class in the file, we need selectors due to ctors/disposes
            if (headerInfo.ClassInstances.Count != 0)
            {
                outputFile.AddUsing("SharpMetal.ObjectiveCCore");
            }

            if (headerInfo.IncludeFlags != IncludeFlags.None)
            {
                if ((headerInfo.IncludeFlags & IncludeFlags.Foundation) == IncludeFlags.Foundation)
                {
                    if (outputFile.Directory != "Foundation")
                    {
                        outputFile.AddUsing("SharpMetal.Foundation");
                    }
                }
                if ((headerInfo.IncludeFlags & IncludeFlags.Metal) == IncludeFlags.Metal)
                {
                    if (outputFile.Directory != "Metal")
                    {
                        outputFile.AddUsing("SharpMetal.Metal");
                    }
                }
                if ((headerInfo.IncludeFlags & IncludeFlags.QuartzCore) == IncludeFlags.QuartzCore)
                {
                    if (outputFile.Directory != "QuartzCore")
                    {
                        outputFile.AddUsing("SharpMetal.QuartzCore");
                    }
                }
            }
        }
    }
}
