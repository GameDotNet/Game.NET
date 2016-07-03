using System.Numerics;
using System.Runtime.InteropServices;

namespace Game.NET.Resources.Mesh
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Vertex
    {
        public Vector3 Position;
        public Vector2 Texture;
        public Vector3 Normal;
        // public Color4? Color;

        public Vertex(Vector3 pos, Vector3 norm, Vector2 tex)
        {
            Position = pos;
            Normal = norm;
            Texture = tex;
        }
    }
}
