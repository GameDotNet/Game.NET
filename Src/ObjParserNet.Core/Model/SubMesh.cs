using System.Collections.Generic;
using ObjParserNet.Core.Model;

namespace ObjParserNet.Core
{
    public class SubMesh
    {
        public List<Vector3D> Vertices = new List<Vector3D>();
        public List<Vector3D> Textures = new List<Vector3D>();
        public List<Vector3D> Normals = new List<Vector3D>();
        public List<Face> Faces = new List<Face>();
    }
}