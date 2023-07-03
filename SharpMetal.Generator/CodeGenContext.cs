namespace SharpMetal.Generator
{
    public class CodeGenContext : IDisposable
    {
        private const string Tab = "    ";
        private readonly StreamWriter _sw;
        private int _depth;

        public string Indentation
        {
            get => _indentation;
        }

        private string _indentation;

        public CodeGenContext(StreamWriter sw)
        {
            _sw = sw;
            _indentation = "";
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
            _sw.WriteLine(_indentation + str);
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
            _indentation = GetIndentation(_depth);
        }

        private static string GetIndentation(int level)
        {
            string indentation = string.Empty;

            for (int index = 0; index < level; index++)
            {
                indentation += Tab;
            }

            return indentation;
        }

        public void Dispose()
        {
            _sw.Dispose();
        }
    }
}