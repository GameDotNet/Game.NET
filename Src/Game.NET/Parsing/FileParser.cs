using System.Collections.Generic;
using System.IO;
using Game.NET.Logic;
using Game.NET.Parsing.IO;
using Game.NET.Parsing.Obj;

namespace Game.NET.Parsing
{
    public class FileParser
    {
        private readonly IFileLoader _fileLoader;
        private readonly IDictionary<FileType, IParsingService> _services;

        public FileParser() : this(new FileLoader())
        {
        }

        internal FileParser(IFileLoader loader, Dictionary<FileType, IParsingService> services = null)
        {
            _fileLoader = loader;
            _services = services ?? GetDefaultServices();
        }

        private static IDictionary<FileType, IParsingService> GetDefaultServices()
        {
            return new Dictionary<FileType, IParsingService>()
            {
                [FileType.Obj] = new ObjParsingService()
            };
        }
        
        public Mesh LoadMesh(string path, FileType fileType)
        {
            string fileName = Path.GetFileName(path);
            var mesh = new Mesh(fileName);

            IEnumerable<string> lines = _fileLoader.LoadFile(path);

            IParsingService parsingService = _services[fileType];
            foreach (string line in lines)
            {
                parsingService.ProcessLine(line, mesh);
            }

            return mesh;
        }
    }
}
