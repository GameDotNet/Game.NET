using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using OpenGLUniProject.Core.Model;
using OpenTK;

namespace OpenGLUniProject.Core
{
    public class MeshParser
    {
        public static NumberStyles Style { get; } = NumberStyles.Any;
        public static CultureInfo Info { get; } = CultureInfo.InvariantCulture;

        public Mesh Parse(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentNullException(nameof(path));
            }

            var mesh = new Mesh { Filename = path };

            using (StreamReader sr = new StreamReader(path))
            {
                while (!sr.EndOfStream)
                {
                    ProcessMeshLine(sr.ReadLine(), mesh);
                }
            }

            return mesh;
        }

        protected void ProcessMeshLine(string line, Mesh mesh)
        {
            //	Comment
            if (string.IsNullOrWhiteSpace(line) || line.StartsWith("#"))
                return;

            //	Vertex
            if (line.StartsWith("o "))
            {
                mesh.SubMeshes.Add(new SubMesh());
            }
            else if (line.StartsWith("v "))
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
            //	TexCoord
            else if (line.StartsWith("vt "))
            {
                var tokens = line.Split(' ');
                if (tokens.Length != 3) return;

                Vector3 texture = new Vector3
                {
                    X = float.Parse(tokens[1], Style, Info),
                    Y = float.Parse(tokens[2], Style, Info)
                };

                mesh.SubMeshes.Last().Textures.Add(texture);
            }
            //	Normal
            else if (line.StartsWith("vn "))
            {
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
            //	Face
            else if (line.StartsWith("f "))
            {
                var tokens = line.Remove(0, 2).Split(' ');

                Face face = new Face
                {
                    Items = new List<FaceItem>()
                };
                //face.Material = lastMaterial;

                foreach (var token in tokens)
                {
                    //	*.obj counts from 1
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

            // MATERIALS
            //else if (line.StartsWith("mtllib "))
            //{
            //    string[] tokens = line.Split(' ');
            //    if (string.IsNullOrWhiteSpace(tokens[1]))
            //        return;

            //    var path = Path.GetDirectoryName(Filename) + Path.DirectorySeparatorChar + tokens[1];
            //    var items = tokens[1].Split('.');

            //    lastMatLib = ResourceManager.Get<Material>(items[0]);
            //    lastMatLib.Load(path);
            //}
            //else if (line.StartsWith("usemtl "))
            //{
            //    var tokens = line.Split(' ');
            //    if (string.IsNullOrWhiteSpace(tokens[1]))
            //        return;

            //    if (!lastMatLib.subMaterials.ContainsKey(tokens[1]))
            //        Logger.Warning("Referencing unexisting material '" + tokens[1] + "' from matlib '" + lastMatLib.Name + "' in mesh '" + Filename + "'!");
            //    else
            //    {
            //        lastMaterial = lastMatLib.subMaterials[tokens[1]];
            //    }
            //}
        }
    }
}
