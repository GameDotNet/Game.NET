namespace Game.NET
{
    public interface IResourceManager
    {
        T Get<T>(string name) where T : Resource;

        T GetOrCreate<T>(string name) where T : Resource, new();

        T Insert<T>(string name, T resource) where T : Resource;

        bool Contains<T>(string name) where T : Resource;

        void Remove<T>(T resource) where T : Resource;

        void Remove<T>(string name) where T : Resource;

        void CleanAll();
    }
}
