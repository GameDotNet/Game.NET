using System.Collections.Generic;
using OpenTK;

namespace ObjParserNet.Core
{
    public class Mesh : Resource
    {
        public string Filename { get; set; }
        public Vector3 MinVertex;
        public Vector3 MaxVertex;

        public List<SubMesh> SubMeshes { get; set; }
        public uint[] GlVbo { get; set; }

        public Mesh()
        {
            MinVertex = new Vector3(float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity);
            MaxVertex = new Vector3(float.NegativeInfinity, float.NegativeInfinity, float.NegativeInfinity);
            SubMeshes = new List<SubMesh>();
        }
    }
}
