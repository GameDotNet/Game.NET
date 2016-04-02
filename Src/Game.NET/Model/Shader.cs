using System;
using OpenTK.Graphics.OpenGL;

namespace Game.NET
{
    internal partial class Shader : Resource
    {
        private bool _isDisposed;

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

                CleanUp();

                throw new ShaderCompilationErrorException(info);
            }
            else
            {
                IsCompiled = true;
            }
        }

        public override void Dispose()
        {
            CleanUp();
            GC.SuppressFinalize(this);
        }

        private void CleanUp()
        {
            if (_isDisposed)
                return;

            IsCompiled = false;
            GL.DeleteShader(Handle);

            _isDisposed = true;
        }

        ~Shader()
        {
            CleanUp();
        }
    }
}
