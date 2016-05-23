using System.Collections.Generic;

namespace Game.NET
{
    /// <summary>
    /// Manages creation of resources in engine.
    /// </summary>
    public class ResourceManager : IResourceManager
    {
        /// <summary>
        /// Base class for all resource types
        /// </summary>
        private readonly Dictionary<string, Resource> _resources = new Dictionary<string, Resource>();

        public T Get<T>(string name) where T : Resource
        {
            if (Contains<T>(name))
                return _resources[name] as T;
            {
                return null;
            }
        }

        public T GetOrCreate<T>(string name) where T : Resource, new()
        {
            if (Contains<T>(name))
                return _resources[name] as T;
            {
                var resource = new T() as Resource;
                resource.Name = name;
                _resources[name] = resource;
                return (T)resource;
            }
        }

        public T Insert<T>(string name, T resource) where T : Resource
        {
            if (Contains<T>(name))
                return _resources[name] as T;

            resource.Name = name;
            _resources[name] = resource;
            return (T)resource;
        }

        public bool Contains<T>(string name) where T : Resource
        {
            return _resources.ContainsKey(name) && _resources[name] is T;
        }

        public void Remove<T>(T resource) where T : Resource
        {
            if (Contains<T>(resource.Name))
            {
                _resources.Remove(resource.Name);
            }
        }

        public void Remove<T>(string name) where T : Resource
        {
            if (Contains<T>(name))
            {
                _resources.Remove(name);
            }
        }

        public void CleanAll()
        {
            _resources.Clear();
        }
    }
}
