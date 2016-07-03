using OpenTK.Graphics.OpenGL;

namespace Game.NET.Resources
{
    public abstract class UniformBase
    {
        public readonly string Name;
        protected int location;

        public abstract void Bind();

        protected UniformBase(string name)
        {
            Name = name;
        }
    }

    public abstract class Uniform<T> : UniformBase
    {
        protected T stored;

        protected Uniform(string name)
            : base(name) { }

        public void Set(T value, ShaderProgram program)
        {
            stored = value;
            location = GL.GetUniformLocation(program.Handle, Name);
        }
    }
}
