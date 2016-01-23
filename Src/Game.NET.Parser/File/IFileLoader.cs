using System.Collections.Generic;

namespace Game.NET.Parser.File
{
    internal interface IFileLoader
    {
        IEnumerable<string> LoadFile(string path);
    }
}
