using System.Collections.Generic;
using System.Numerics;
using OpenTK.Graphics.OpenGL;

namespace Game.NET
{
    public class ObjSubMesh
    {
        public ObjSubMesh()
        {
            Vertices = new List<Vector3>();
            Textures = new List<Vector2>();
            Normals = new List<Vector3>();
            Faces = new List<Face>();
        }

        public List<Vector3> Vertices { get; set; }
        public List<Vector2> Textures { get; set; }
        public List<Vector3> Normals  { get ;set; }
        public List<Face> Faces { get; set; }
    }
}