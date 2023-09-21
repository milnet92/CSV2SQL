using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVS2SQL.Core.Scripting
{
    public class ConsoleCapture : TextWriter, IDisposable
    {
        public delegate void ConsoleWriteEventHandler(object sender, ConsoleWriteEventArgs e);
        public delegate void ConsoleWriteLineEventHandler(object sender, ConsoleWriteEventArgs e);

        public event ConsoleWriteEventHandler ConsoleWrite;
        public event ConsoleWriteLineEventHandler ConsoleWriteLine;

        private TextWriter stdOutWriter;
        public TextWriter Captured { get; private set; }
        public override Encoding Encoding { get { return Encoding.ASCII; } }


        public ConsoleCapture()
        {
            this.stdOutWriter = Console.Out;
            Console.SetOut(this);
            Captured = new StringWriter();
        }

        override public void Write(string output)
        {
            // Capture the output and also send it to StdOut
            Captured.Write(output);
            stdOutWriter.Write(output);

            OnConsoleWrite(output);
        }

        override public void WriteLine(string output)
        {
            // Capture the output and also send it to StdOut
            Captured.WriteLine(output);
            stdOutWriter.WriteLine(output);

            OnConsoleWriteLine(output);
        }

        public void OnConsoleWrite(string text)
        {
            ConsoleWrite?.Invoke(this, new ConsoleWriteEventArgs(text));
        }

        public void OnConsoleWriteLine(string text)
        {
            ConsoleWriteLine?.Invoke(this, new ConsoleWriteEventArgs(text));
        }
    }
}
