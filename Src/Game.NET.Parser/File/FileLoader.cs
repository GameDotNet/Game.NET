using System.Collections.Generic;

namespace Game.NET.Parser.File
{
    public class FileLoader : IFileLoader
    {
        public IEnumerable<string> LoadFile(string path)
        {
            return System.IO.File.ReadLines(path);
        }
    }
}
