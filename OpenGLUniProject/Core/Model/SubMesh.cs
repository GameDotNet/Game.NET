using System.Collections.Generic;
using OpenTK;

namespace OpenGLUniProject.Core.Model
{
    public class SubMesh
    {
        public List<Vector3> Vertices = new List<Vector3>();
        public List<Vector3> Textures = new List<Vector3>();
        public List<Vector3> Normals = new List<Vector3>();
        public List<Face> Faces = new List<Face>();
    }
}