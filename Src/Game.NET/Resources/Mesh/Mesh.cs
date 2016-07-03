using System.Collections.Generic;
using System.Numerics;
using Game.NET.Resources;

namespace Game.NET
{
    public class Mesh : Resource
    {
        public string Filename { get; set; }
        public Vector3 MinVertex;
        public Vector3 MaxVertex;

        public List<ObjSubMesh> ObjSubMeshes { get; set; }
        private List<BaseSubMesh> SubMeshes { get; set; }

        public Mesh(string fileName = null)
        {
            Filename = fileName;
            MinVertex = new Vector3(float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity);
            MaxVertex = new Vector3(float.NegativeInfinity, float.NegativeInfinity, float.NegativeInfinity);
            ObjSubMeshes = new List<ObjSubMesh>();
            SubMeshes = new List<BaseSubMesh>();
        }

        public Mesh(string filename, List<ObjSubMesh> objSubMeshes)
        {
            Filename = filename;
            MinVertex = new Vector3(float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity);
            MaxVertex = new Vector3(float.NegativeInfinity, float.NegativeInfinity, float.NegativeInfinity);
            ObjSubMeshes = objSubMeshes;
            SubMeshes = new List<BaseSubMesh>();
        }

        public void CopyDataFromObj<T>(int vertexSize, SubMesh<T>.ParseVertex parser, bool clearAfter = false) where T : struct
        {
            SubMeshes.Clear();

            foreach (var objSubMesh in ObjSubMeshes)
            {
                SubMesh<T> submesh = new SubMesh<T>(vertexSize);
                submesh.CopyDataFromObj(objSubMesh, parser);
                SubMeshes.Add(submesh);
            }

            if (clearAfter)
            {
                ObjSubMeshes.Clear();
            }
        }
    }
}
