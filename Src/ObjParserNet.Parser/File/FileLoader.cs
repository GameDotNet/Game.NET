using System.Collections.Generic;

namespace ObjParserNet.Parser.File
{
    public class FileLoader : IFileLoader
    {
        public IEnumerable<string> LoadFile(string path)
        {
            return System.IO.File.ReadLines(path);
        }
    }
}
