using System.Collections.Generic;
using OpenTK;

namespace OpenGLUniProject.Core.Model
{
    public class Mesh : Resource
    {
        public string Filename { get; set; }
        public Vector3 MinVertex;
        public Vector3 MaxVertex;

        public List<SubMesh> SubMeshes { get; set; }
        public uint[] GlVbo { get; set; }

        //protected Gfx.Material.SubMaterial lastMaterial;
        //protected Gfx.Material lastMatLib;

        public Mesh()
        {
            MinVertex = new Vector3(float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity);
            MaxVertex = new Vector3(float.NegativeInfinity, float.NegativeInfinity, float.NegativeInfinity);
            SubMeshes = new List<SubMesh>();
        }
    }
}
