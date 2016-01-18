using System.Collections.Generic;

namespace ObjParserNet.Core
{
    public class Face
    {
        public Face()
        {
            Items = new List<FaceItem>();
        }

        public List<FaceItem> Items { get; set; }
    }
}