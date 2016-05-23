using System;

namespace Game.NET
{
    [Serializable]
    public class ShaderCompilationErrorException : GameException
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
