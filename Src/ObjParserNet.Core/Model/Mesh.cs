using System.Collections.Generic;

namespace ObjParserNet.Core
{
    public class Mesh : Resource
    {
        public string Filename { get; set; }
        public Vector3D MinVertex { get; set; }
        public Vector3D MaxVertex { get; set; }
        public List<SubMesh> SubMeshes { get; set; }
        
        public Mesh()
        {
            SubMeshes = new List<SubMesh>();
        }

        public Mesh(string filename, Vector3D minVertex, Vector3D maxVertex, List<SubMesh> subMeshes)
        {
            Filename = filename;
            MinVertex = minVertex;
            MaxVertex = maxVertex;
            SubMeshes = subMeshes;
        }
    }
}
