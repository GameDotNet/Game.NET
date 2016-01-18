using System;

namespace ObjParserNet.Core
{
    public abstract class Resource : IDisposable
    {
        public string Name { get; internal set; }
        public virtual void Dispose() { }
    }
}
