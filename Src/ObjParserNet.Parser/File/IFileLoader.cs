using System.Collections.Generic;

namespace ObjParserNet.Parser.File
{
    internal interface IFileLoader
    {
        IEnumerable<string> LoadFile(string path);
    }
}
