using Game.NET.Parsing;

namespace Game.NET.Resources
{
    public class MeshFactory
    {
        NET.Mesh LoadMeshFromObj<T>(string path, SubMesh<T>.ParseVertex vertexFormatter) where T : struct
        {
            FileParser parser = new FileParser();
            NET.Mesh result = parser.LoadMesh("Data/mesh.obj", FileType.Obj);

            result.CopyDataFromObj<T>(sizeof(T), vertexFormatter);

            return result;
        }
    }
}
