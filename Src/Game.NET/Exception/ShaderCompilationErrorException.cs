using System;
using System.Runtime.Serialization;

namespace Game.NET
{
    [Serializable]
    public class ShaderCompilationErrorException : Exception
    {
        private const string ShaderExceptionText = "Unable to load shader.";

        public ShaderCompilationErrorException() : this(ShaderExceptionText)
        {
        }

        public ShaderCompilationErrorException(string message) : base(message)
        {
        }

        public ShaderCompilationErrorException(Exception ex) : base(ShaderExceptionText, ex)
        {
        }

    }
}
