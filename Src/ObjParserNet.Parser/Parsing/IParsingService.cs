using ObjParserNet.Core;

namespace ObjParserNet.Parser.Parsing
{
    internal interface IParsingService
    {
        void ProcessLine(string line, Mesh mesh);
    }
}
