using OpenTK.Graphics.OpenGL;

namespace Game.NET.Resources
{
    public class VertexAttribute
    {
        public readonly string Name;
        public readonly VertexAttribPointerType Type;
        public readonly int Size;
        public readonly bool Normalize;
        public readonly int Stride;
        public readonly int Offset;
        private bool _disposed;

        public VertexAttribute(string name, VertexAttribPointerType type, int size, bool normalize, int stride, int offset)
        {
            Name = name;
            Type = type;
            Size = size;
            Normalize = normalize;
            Stride = stride;
            Offset = offset;
        }

        public void Use(ShaderProgram program)
        {
            int index = GL.GetAttribLocation(program.Handle, Name);
            
            GL.EnableVertexAttribArray(index);
            GL.VertexAttribPointer(index, Size, Type, Normalize, Stride, Offset);
        }
    }
}
