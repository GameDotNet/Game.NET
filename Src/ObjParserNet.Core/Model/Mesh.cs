using System.Collections.Generic;
using OpenTK;

namespace ObjParserNet.Core
{
    public class Mesh : Resource
    {
        public string Filename { get; set; }
        public Vector3 MinVertex { get; internal set; }
        public Vector3 MaxVertex { get; internal set; }

        public List<SubMesh> SubMeshes { get; set; }

        public Mesh()
        {
            MinVertex = new Vector3(float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity);
            MaxVertex = new Vector3(float.NegativeInfinity, float.NegativeInfinity, float.NegativeInfinity);
            SubMeshes = new List<SubMesh>();
        }

        public Mesh(string filename, List<SubMesh> subMeshes)
        {
            Filename = filename;
            SubMeshes = subMeshes;
        }
    }
}
