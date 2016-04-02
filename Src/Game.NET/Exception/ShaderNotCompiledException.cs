using System;

namespace Game.NET
{
    [Serializable]
    public class ShaderNotCompiledException : System.Exception
    {
        private static readonly string ShaderExceptionText = "Unable to use not compiled shader.";

        public ShaderNotCompiledException()
        {
        }

        public ShaderNotCompiledException(string message) : base(message)
        {
        }

        public ShaderNotCompiledException(System.Exception inner) : base(ShaderExceptionText, inner)
        {
        }

        public ShaderNotCompiledException(string message, System.Exception inner) : base(message, inner)
        {
        }

        protected ShaderNotCompiledException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
        {
        }
    }
}
