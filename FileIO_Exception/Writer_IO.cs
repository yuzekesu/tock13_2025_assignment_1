using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileIO_proj
{
    public interface Writer_IO
    {
        void WriteLine(string text);
        void FlushAndClose();
    }

    public sealed class ConsoleWriter_IO : Writer_IO
    {
        public void WriteLine(string text) => Console.WriteLine(text);
        public void FlushAndClose() { }
    }

    public sealed class FileWriter_IO : Writer_IO
    {
        private readonly StreamWriter _writer;

        public FileWriter_IO(string destinationPath)
        {
            _writer = new StreamWriter(destinationPath, append : false);
        }

        public void WriteLine(string text) => _writer.WriteLine(text);

        public void FlushAndClose()
        {
            _writer.Flush();
            _writer.Dispose();
        }
    }
}
