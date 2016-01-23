using System.Collections.Generic;
using System.IO;
using Game.NET.Parser.File;
using Game.NET.Parser.Parsing;

namespace Game.NET.Parser
{
    public class ObjFileParser
    {
        private readonly IFileLoader _fileLoader;
        private readonly IParsingService _parsingService;

        public ObjFileParser()
        {
            _fileLoader = new FileLoader();
            _parsingService = new ParsingService();
        }

        internal ObjFileParser(IFileLoader fileLoader, IParsingService parsingService)
        {
            _fileLoader = fileLoader;
            _parsingService = parsingService;
        }

        public Mesh LoadMesh(string path)
        {
            string fileName = Path.GetFileName(path);
            var mesh = new Mesh(fileName);

            IEnumerable<string> lines = _fileLoader.LoadFile(path);

            foreach (string line in lines)
            {
                _parsingService.ProcessLine(line, mesh);
            }

            return mesh;
        }
    }
}
