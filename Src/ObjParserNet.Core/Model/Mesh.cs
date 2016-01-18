using System.Collections.Generic;
using ObjParserNet.Core.Model;

namespace ObjParserNet.Core
{
    public class Mesh : Resource
    {
        public string Filename { get; set; }
        public Vector3D MinVertex;
        public Vector3D MaxVertex;

        public List<SubMesh> SubMeshes { get; set; }
        public uint[] GlVbo { get; set; }

        public Mesh()
        {
            MinVertex = new Vector3D(float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity);
            MaxVertex = new Vector3D(float.NegativeInfinity, float.NegativeInfinity, float.NegativeInfinity);
            SubMeshes = new List<SubMesh>();
        }
    }
}
