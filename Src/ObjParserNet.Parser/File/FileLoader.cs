using System.IO;

namespace ObjParserNet.Parser.File
{
    public class FileLoader : IFileLoader
    {
        public Stream LoadFile(string path)
        {
            return System.IO.File.OpenRead(path);
        }
    }
}
