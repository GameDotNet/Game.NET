using System;
using System.Collections.Generic;
using System.Linq;
using ObjParserNet.Core;

namespace ObjParserNet.Parser.Parsing
{
    internal class ParsingService : IParsingService
    {
        private readonly ParsingWorker _worker = new ParsingWorker();
        public readonly IDictionary<string, Action<string, Mesh>> ProcessDictionary;

        public ParsingService()
        {
            ProcessDictionary = new Dictionary<string, Action<string, Mesh>>
            {
                ["o"] = _worker.ProcessObject,
                ["v"] = _worker.ProcessVertex,
                ["vt"] = _worker.ProcessTextCoord,
                ["vn"] = _worker.ProcessNormal,
                ["f"] = _worker.ProcessFace,
                ["mtllib"] = (process, mesh) => { },
                ["usemtl"] = (process, mesh) => { },
                ["s"] = (process, mesh) => { }
            };
        }

        public void ProcessLine(string line, Mesh mesh)
        {
            //	comment
            if (string.IsNullOrWhiteSpace(line) || line.StartsWith("#")) return;

            string action = line.Split(' ').FirstOrDefault();
            if (action != null && ProcessDictionary.ContainsKey(action))
            {
                ProcessDictionary[action].Invoke(line, mesh);
            }
            else
            {
                throw new InvalidOperationException($"Cannot find a correct parsing process for line {line}");
            }
        }
    }
}
