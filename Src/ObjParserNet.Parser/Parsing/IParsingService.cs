using System.Globalization;
using ObjParserNet.Core;

namespace ObjParserNet.Parser.Parsing
{
    internal interface IParsingService
    {
        NumberStyles Style { get; }
        CultureInfo Info { get; }
        void ProcessLine(string line, Mesh mesh);
    }
}
