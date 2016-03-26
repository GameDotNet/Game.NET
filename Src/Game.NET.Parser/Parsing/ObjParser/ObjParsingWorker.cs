using System;
using System.Globalization;
using System.Linq;
using System.Numerics;

namespace Game.NET.Parser.Parsing
{
    internal class ObjParsingWorker
    {
        internal NumberStyles Style { get; } = NumberStyles.Any;
        internal CultureInfo Info { get; } = CultureInfo.InvariantCulture;

        public void ProcessObject(string line, Mesh mesh)
        {
            mesh.SubMeshes.Add(new SubMesh());
        }

        public void ProcessVertex(string line, Mesh mesh)
        {
            if (!mesh.SubMeshes.Any())
                mesh.SubMeshes.Add(new SubMesh());

            var tokens = line.Split(' ');
            if (tokens.Length != 4) return;

            Vector3 vertex = new Vector3
            {
                X = float.Parse(tokens[1], Style, Info),
                Y = float.Parse(tokens[2], Style, Info),
                Z = float.Parse(tokens[3], Style, Info)
            };

            mesh.SubMeshes.Last().Vertices.Add(vertex);

            //	Bounds
            if (vertex.X < mesh.MinVertex.X) mesh.MinVertex.X = vertex.X;
            if (vertex.Y < mesh.MinVertex.Y) mesh.MinVertex.Y = vertex.Y;
            if (vertex.Z < mesh.MinVertex.Z) mesh.MinVertex.Z = vertex.Z;

            if (vertex.X > mesh.MaxVertex.X) mesh.MaxVertex.X = vertex.X;
            if (vertex.Y > mesh.MaxVertex.Y) mesh.MaxVertex.Y = vertex.Y;
            if (vertex.Z > mesh.MaxVertex.Z) mesh.MaxVertex.Z = vertex.Z;
        }

        public void ProcessTextCoord(string line, Mesh mesh)
        {
            if(!mesh.SubMeshes.Any()) throw new InvalidOperationException("Cannot add texture because submesh collection is empty");

            var tokens = line.Split(' ');
            if (tokens.Length != 3) return;

            Vector3 texture = new Vector3
            {
                X = float.Parse(tokens[1], Style, Info),
                Y = float.Parse(tokens[2], Style, Info)
            };

            mesh.SubMeshes.Last().Textures.Add(texture);
        }

        public void ProcessNormal(string line, Mesh mesh)
        {
            if (!mesh.SubMeshes.Any()) throw new InvalidOperationException("Cannot add normal because submesh collection is empty");

            var tokens = line.Split(' ');
            if (tokens.Length != 4) return;

            Vector3 normal = new Vector3
            {
                X = float.Parse(tokens[1], Style, Info),
                Y = float.Parse(tokens[2], Style, Info),
                Z = float.Parse(tokens[3], Style, Info)
            };

            mesh.SubMeshes.Last().Normals.Add(normal);
        }

        public void ProcessFace(string line, Mesh mesh)
        {
            if (!mesh.SubMeshes.Any()) throw new InvalidOperationException("Cannot add face because submesh collection is empty");

            var tokens = line.Remove(0, 2).Split(' ');

            Face face = new Face();

            foreach (var token in tokens)
            {
                FaceItem item = new FaceItem();

                string[] items = token.Split('/');

                switch (items.Length)
                {
                    case 1:
                        if (!string.IsNullOrWhiteSpace(items[0])) item.Vertex = uint.Parse(items[0], Style, Info);
                        break;
                    case 2:
                        if (!string.IsNullOrWhiteSpace(items[0])) item.Vertex = uint.Parse(items[0], Style, Info);
                        if (!string.IsNullOrWhiteSpace(items[1])) item.Texture = uint.Parse(items[1], Style, Info);
                        break;
                    case 3:
                        if (!string.IsNullOrWhiteSpace(items[0])) item.Vertex = uint.Parse(items[0], Style, Info);
                        if (!string.IsNullOrWhiteSpace(items[1])) item.Texture = uint.Parse(items[1], Style, Info);
                        if (!string.IsNullOrWhiteSpace(items[2])) item.Normal = uint.Parse(items[2], Style, Info);
                        break;
                }
                face.Items.Add(item);
            }

            mesh.SubMeshes.Last().Faces.Add(face);
        }
    }
}
