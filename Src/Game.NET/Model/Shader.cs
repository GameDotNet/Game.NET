using System;
using OpenTK.Graphics.OpenGL;

namespace Game.NET
{
    internal class Shader : Resource, IDisposable
    {
        private bool _disposed;

        public bool IsCompiled { get; private set; }
        public string Filename { get; set; }
        public int Handle { get; private set; }
        public string Source { get; set; }
        public ShaderType Type { get; private set; }

        internal Shader(ShaderType type, string filename)
        {
            Type = type;
            Filename = filename;

            Handle = GL.CreateShader(Type);
        }

        ~Shader()
        {
            Dispose(false);
        }

        public void Compile()
        {
            GL.ShaderSource(Handle, Source);
            GL.CompileShader(Handle);

            CheckForErrors();
        }

        private void CheckForErrors()
        {
            int compileResult;

            GL.GetShader(Handle, ShaderParameter.CompileStatus, out compileResult);

            if (compileResult == 0)
            {
                string info = GL.GetShaderInfoLog(Handle);

                Dispose();

                throw new ShaderCompilationErrorException(info);
            }

            IsCompiled = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;

            if (disposing)
            {
                GL.DeleteShader(Handle);
                IsCompiled = false;
            }

            _disposed = true;
        }
    }
}
