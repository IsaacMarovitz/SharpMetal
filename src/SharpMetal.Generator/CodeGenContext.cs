using System.Text;

namespace SharpMetal.Generator
{
    public class CodeGenContext : IDisposable
    {
        private const string Tab = "    ";
        private readonly StreamWriter _sw;
        private int _depth;
        private readonly Stack<StringBuilder> _stringBuilderPool = [];

        public string Indentation { get; private set; }

        public CodeGenContext(StreamWriter sw)
        {
            _sw = sw;
            Indentation = "";
            for (int i = 0; i < 2; i++)
            {
                _stringBuilderPool.Push(new StringBuilder());
            }
        }

        public StringBuilder AcquireTempStringBuilder()
        {
            if (_stringBuilderPool.Count == 0)
            {
                _stringBuilderPool.Push(new StringBuilder());
            }
            return _stringBuilderPool.Pop();
        }

        public void ReleaseTempStringBuilder(StringBuilder sb)
        {
            sb.Clear();
            _stringBuilderPool.Push(sb);
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
            _stringBuilderPool.Clear();
            GC.SuppressFinalize(this);
        }
    }
}
