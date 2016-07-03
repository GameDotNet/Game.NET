using Game.NET.Parsing;
using Game.NET.Resources.Mesh;
using OpenTK.Graphics.OpenGL;

namespace Game.NET.Resources
{
    public class MeshFactory
    {
        private readonly IResourceManager _resourceManager;
        
        public MeshFactory(IResourceManager resourceManager)
        {
            _resourceManager = resourceManager;
        }
        
        public NET.Mesh LoadMeshFromObj<T>(string path, int sizeOfT, SubMesh<T>.ParseVertex vertexFormatter, BufferUsageHint usage = BufferUsageHint.StaticDraw, bool clearAfter = false) where T : struct
        {
            FileParser parser = new FileParser();
            NET.Mesh result = parser.LoadMesh(path, FileType.Obj);

            result.CopyDataFromObj<T>(sizeOfT, vertexFormatter, clearAfter);
            result.Upload(usage);

            _resourceManager.Insert(path, result);

            return result;
        }

        public unsafe NET.Mesh LoadMeshFromObj(string path, BufferUsageHint usage = BufferUsageHint.StaticDraw, bool clearAfter = false)
        {
            return LoadMeshFromObj<Vertex>
            (
                path,
                sizeof(Vertex),
                (pos, norm, tex) => new Vertex(pos.Value, norm.Value, tex.Value), 
                usage, 
                clearAfter
            );
        }
    }
}
