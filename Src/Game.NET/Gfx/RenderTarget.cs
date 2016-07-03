namespace Game.NET.Gfx
{
    public abstract class RenderTarget
    {
        public abstract void Use();

        public abstract void Clear();

        public abstract void Swap();
    }
}
