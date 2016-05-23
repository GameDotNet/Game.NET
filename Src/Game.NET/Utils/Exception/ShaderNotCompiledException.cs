using System;

namespace Game.NET
{
    [Serializable]
    public class ShaderNotCompiledException : GameException
    {
        private const string ShaderExceptionText = "Unable to use not compiled shader.";

        public ShaderNotCompiledException() : this(ShaderExceptionText)
        {
        }

        public ShaderNotCompiledException(string message) : base(message)
        {
        }
    }
}
