using System;
using System.Collections.Generic;
using System.Linq;
using OpenTK.Graphics.OpenGL;

namespace Game.NET
{
    public class ShaderProgram : Resource, IDisposable
    {
        private bool _isDisposed;

        public int Handle { get; private set; }

        public ShaderProgram()
        {
            Handle = GL.CreateProgram();
        }

        ~ShaderProgram()
        {
            Dispose(false);
        }

        internal void Compile(ICollection<Shader> shaders)
        {
            if (shaders.Any(s => !s.IsCompiled))
            {
                throw new ShaderNotCompiledException();
            }

            foreach (var shader in shaders)
            {
                GL.AttachShader(Handle, shader.Handle);
            }

            GL.LinkProgram(Handle);

            foreach (var shader in shaders)
            {
                GL.DetachShader(Handle, shader.Handle);
            }
        }

        public void Use()
        {
            GL.UseProgram(Handle);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_isDisposed)
                return;

            if (disposing)
            {
                GL.DeleteProgram(Handle);
                Handle = -1;
            }

            _isDisposed = true;
        }
    }
}
