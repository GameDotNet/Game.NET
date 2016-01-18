using System;

namespace ObjParserNet.Core.Exception
{
    [System.Serializable()]
    class ShaderCompilationErrorException : System.Exception
    {
        private static readonly string ShaderExceptionText = "Unable to load shader.";

        public ShaderCompilationErrorException() : base() { }
        public ShaderCompilationErrorException(string message) : base(message) { }

        public ShaderCompilationErrorException(System.Exception inner) : base(ShaderExceptionText, inner) { }
        public ShaderCompilationErrorException(string message, System.Exception inner) : base(message, inner) { }
 
        protected ShaderCompilationErrorException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
        { }
    }
}
