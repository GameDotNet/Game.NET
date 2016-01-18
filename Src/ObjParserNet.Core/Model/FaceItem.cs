namespace ObjParserNet.Core
{
    public class FaceItem
    {
        public FaceItem() : this(default(uint), default(uint), default(uint))
        {
        }

        public FaceItem(uint vertex, uint texture, uint normal)
        {
            Vertex = vertex;
            Texture = texture;
            Normal = normal;
        }

        public uint Vertex { get; set; }
        public uint Texture { get; set; }
        public uint Normal { get; set; }
    }
}