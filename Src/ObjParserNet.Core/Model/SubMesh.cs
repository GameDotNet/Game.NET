using System.Collections.Generic;

namespace ObjParserNet.Core
{
    public class SubMesh
    {
        public SubMesh()
        {
            Vertices = new List<Vector3D>();
            Textures = new List<Vector3D>();
            Normals = new List<Vector3D>();
            Faces = new List<Face>();
        }

        public List<Vector3D> Vertices { get; set; }
        public List<Vector3D> Textures { get; set; }
        public List<Vector3D> Normals  {get ;set;}
        public List<Face> Faces { get; set; }
    }
}