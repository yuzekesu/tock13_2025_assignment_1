using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileIO_proj
{
    public interface Reader_IO
    {
        string? ReadLine();
    }

    public sealed class ConsoleReader_IO : Reader_IO
    {
        public string? ReadLine() => Console.ReadLine();
    }

    public sealed class FileReader_IO : Reader_IO
    {
        private readonly IEnumerator<string> _lines;

        public FileReader_IO(string sourcePath)
        {
            _lines = File.ReadLines(sourcePath).GetEnumerator();
        }

        public string? ReadLine() => _lines.MoveNext() ? _lines.Current : null;
    }
}
