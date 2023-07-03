namespace SharpMetal.Generator.Instances
{
    public class MethodInstance
    {
        public string ReturnType;
        public string Name;
        public string Selector;
        public bool IsStatic;
        public List<PropertyInstance> InputInstances;

        public MethodInstance(string returnType, string name, string selector, bool isStatic, List<PropertyInstance> inputInstances)
        {
            ReturnType = returnType;
            Name = name;
            IsStatic = isStatic;
            InputInstances = inputInstances;
        }

        public void Generate(CodeGenContext context, bool prependSpace = true)
        {
            var staticString = IsStatic ? "static " : "";

            if (prependSpace)
            {
                context.WriteLine();
            }
            context.Write(context.Indentation + $"public {staticString}{ReturnType} {Name}(");

            for (var i = 0; i < InputInstances.Count; i++)
            {
                var input = InputInstances[i];

                context.Write($"{input.Type} {input.Name}");

                if (i != InputInstances.Count - 1)
                {
                    context.Write(", ");
                }
            }

            context.Write(")\n");
            context.EnterScope();
            if (ReturnType == "void")
            {
                context.Write($"{context.Indentation}objc_msgSend(NativePtr, {Selector}, ");
                for (var index = 0; index < InputInstances.Count; index++)
                {
                    context.Write($"{InputInstances[index].Name}");
                    if (index != InputInstances.Count - 1)
                    {
                        context.Write(", ");
                    }
                }
                context.Write(");\n");
            }
            else
            {
                context.WriteLine("throw new NotImplementedException();");
            }
            context.LeaveScope();
        }
    }
}