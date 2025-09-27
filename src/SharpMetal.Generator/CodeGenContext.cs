namespace SharpMetal.Generator
{
    public class CodeGenContext : IDisposable
    {
        private const string Tab = "    ";
        private readonly StreamWriter _sw;
        private int _depth;

        public string Indentation { get; private set; }

        public CodeGenContext(StreamWriter sw)
        {
            _sw = sw;
            Indentation = "";
        }

        public void WriteLine()
        {
            _sw.WriteLine();
        }

        public void Write(string str)
        {
            _sw.Write(str);
        }

        public void WriteLine(string str)
        {
            _sw.WriteLine(Indentation + str);
        }

        public void EnterScope()
        {
            WriteLine("{");

            _depth++;

            UpdateIndentation();
        }

        public void LeaveScope(string suffix = "")
        {
            if (_depth == 0)
            {
                return;
            }

            _depth--;

            UpdateIndentation();

            WriteLine("}" + suffix);
        }

        private void UpdateIndentation()
        {
            Indentation = GetIndentation(_depth);
        }

        private static string GetIndentation(int level)
        {
            var indentation = string.Empty;

            for (var index = 0; index < level; index++)
            {
                indentation += Tab;
            }

            return indentation;
        }

        public void Dispose()
        {
            _sw.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
