using System;

namespace Game.NET
{
    public abstract class Resource : IDisposable
    {
        public string Name { get; internal set; }
        public virtual void Dispose() { }
    }
}
