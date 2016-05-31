using System.Collections.Generic;
using System.IO;

namespace Game.NET.Parsing.IO
{
    internal interface IFileLoader
    {
        IEnumerable<string> LoadFile(string path);
        FileStream OpenRead(string path);
        byte[] ReadBytes(string path);
    }
}
