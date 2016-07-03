using System.Collections.Generic;
using OpenTK.Graphics.OpenGL;

namespace Game.NET.Resources
{
    public class MaterialParameter<T>
    {
        public T value;
        public int location;

        public MaterialParameter(int loc, T val)
        {
            location = loc;
            value = val;
        }
    }

    public class Material : Resource
    {
        public readonly ShaderProgram program;
        
        private Dictionary<string, UniformBase> uniforms = new Dictionary<string, UniformBase>();

        public Material(ShaderProgram program)
        {
            this.program = program;
        }

        public void AddUniform<T>(string name, Uniform<T> uniform)
        {
            if (!uniforms.ContainsKey(name))
            {
                uniforms.Add(name, uniform);
            }
        }

        public void Set<T>(string name, T value)
        {
            if(uniforms.ContainsKey(name))
                ((Uniform<T>) uniforms[name]).Set(value, program);
        }
        
        public void Use()
        {
            GL.UseProgram(program.Handle);
            foreach (var uni in uniforms.Values)
            {
                uni.Bind();
            }
        }

        // public void SetTexture(string name, Texture texture)
    }
}
