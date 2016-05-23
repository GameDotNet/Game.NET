using System.Collections.Generic;
using System.IO;

namespace Game.NET.Parsing.IO
{
    internal class FileLoader : IFileLoader
    {
        public IEnumerable<string> LoadFile(string path)
        {
            return File.ReadLines(path);
        }

        public FileStream OpenRead(string path)
        {
            return File.OpenRead(path);
        }
    }
}
