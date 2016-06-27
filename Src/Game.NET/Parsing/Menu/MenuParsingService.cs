using System;
using System.Collections.Generic;
using System.Linq;

namespace Game.NET.Parsing.Menu
{
    public class MenuParsingService : IParsingService
    {
        private readonly MenuParsingWorker _worker = new MenuParsingWorker();
        internal readonly IDictionary<string, Action<string, Mesh>> ProcessDictionary;

        public MenuParsingService()
        {
            ProcessDictionary = new Dictionary<string, Action<string, Mesh>>
            {

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