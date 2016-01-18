using System.Collections.Generic;
using System.IO;

namespace ObjParserNet.Parser.File
{
    public interface IFileLoader
    {
        IEnumerable<string> LoadFile(string path);
    }
}
