using System.Collections.Generic;
using System.IO;
using Game.NET.Parser.File;
using Game.NET.Parser.Parsing;

namespace Game.NET.Parser
{
    public class FileParser
    {
        private readonly IFileLoader _fileLoader;
        private readonly IParsingService _parsingService;
        
        public FileParser(IFileLoader fileLoader, IParsingService parsingService)
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
