using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace Game.NET.Resources
{
    public abstract class BaseSubMesh : IDisposable
    {
        public abstract void Create();
        public abstract void Upload(BufferUsageHint usage);
        public abstract void Use();
        public abstract void Dispose();
    }

    public class SubMesh<Vertex> : BaseSubMesh where Vertex : struct
    {
        public int Handle;
        public int Index;

        private readonly int vertexSize;

        private Vertex[] vertices;
        private uint[] indicies;
        private bool _disposed;

        public delegate Vertex ParseVertex(Vector3? pos, Vector3? norm, Vector2? tex);

        public SubMesh(int vertexSize)
        {
            this.vertexSize = vertexSize;
        }

        public override void Create()
        {
            if (Handle != 0)
                return;

            Handle = GL.GenBuffer();
            Index = GL.GenBuffer();
        }
        
        internal void CopyDataFromObj(ObjSubMesh obj, ParseVertex parser)
        {
            List<Vertex> vertList = new List<Vertex>();
            List<uint> indList = new List<uint>();
            
            foreach (var face in obj.Faces.SelectMany(face => face.Items))
            {
                Vertex vertex = parser
                (
                    obj.Vertices.Any() ? new Vector3?(obj.Vertices[(int) face.Vertex]) : null,
                    obj.Normals.Any() ? new Vector3?(obj.Normals [(int) face.Normal]) : null,
                    obj.Textures.Any() ? new Vector2?(obj.Textures[(int) face.Texture]) : null
                );

                if (!vertList.Contains(vertex))
                {
                    vertList.Add(vertex);
                }

                indList.Add((uint) vertList.IndexOf(vertex));
            }

            indicies = indList.ToArray();
            vertices = vertList.ToArray();
        }

        public override void Upload(BufferUsageHint usage)
        {
            Use();
            GL.BufferData(BufferTarget.ArrayBuffer, (IntPtr)(vertices.Length * vertexSize), vertices, usage);
            GL.BufferData(BufferTarget.ElementArrayBuffer, (IntPtr)(indicies.Length * sizeof(uint)), indicies, usage);
        }

        public override void Use()
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, Handle);
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, Index);
        }

        public override void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;

            if (GraphicsContext.CurrentContext == null || GraphicsContext.CurrentContext.IsDisposed)
                return;
            
            GL.DeleteBuffer(Handle);
            GL.DeleteBuffer(Index);
            
            _disposed = true;
        }

        ~SubMesh()
        {
            Dispose(false);
        }
    }
}
