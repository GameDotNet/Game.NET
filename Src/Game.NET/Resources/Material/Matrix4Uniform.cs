using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Game.NET.Resources
{
    public class Matrix4Uniform : Uniform<Matrix4>
    {
        public Matrix4Uniform(string name, Matrix4 value, ShaderProgram program) : base(name)
        {
            Set(value, program);
        }

        public override void Bind()
        {
            GL.UniformMatrix4(location, false, ref stored);
        }
    }
}
