using System.Collections.Generic;

namespace ObjParserNet.Core
{
    public class Face
    {
        public Face() : this(new List<FaceItem>())
        {
        }

        public Face(ICollection<FaceItem> items)
        {
            Items = items;
        }

        public ICollection<FaceItem> Items { get; set; }
    }
}