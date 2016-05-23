using System.Collections.Generic;

namespace Game.NET.Parser.File
{
    public interface IFileLoader
    {
        IEnumerable<string> LoadFile(string path);

    }
}
