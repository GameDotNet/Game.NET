using System.Collections.Generic;

namespace ObjParserNet.Core
{
    /// <summary>
    /// Manages creation of resources in engine.
    /// </summary>
    public class ResourceManager
    {
        /// <summary>
        /// Base class for all resource types
        /// </summary>
        private static readonly Dictionary<string, Resource> Resources = new Dictionary<string, Resource>();

        public static T Get<T>(string name) where T : Resource
        {
            if (Contains<T>(name))
                return Resources[name] as T;
            {
                return null;
            }
        }

        public static T GetOrCreate<T>(string name) where T : Resource, new()
        {
            if (Contains<T>(name))
                return Resources[name] as T;
            {
                var resource = new T() as Resource;
                resource.Name = name;
                Resources[name] = resource;
                return (T)resource;
            }
        }

        public static T Insert<T>(string name, T resource) where T : Resource
        {
            if (Contains<T>(name))
                return Resources[name] as T;

            resource.Name = name;
            Resources[name] = resource;
            return (T)resource;
        }

        public static bool Contains<T>(string name) where T : Resource
        {
            return Resources.ContainsKey(name) && Resources[name] is T;
        }

        public static void Remove<T>(T resource) where T : Resource
        {
            if (Contains<T>(resource.Name))
            {
                Resources.Remove(resource.Name);
            }
        }

        public static void Remove<T>(string name) where T : Resource
        {
            if (Contains<T>(name))
            {
                Resources.Remove(name);
            }
        }

        public static void CleanAll()
        {
            Resources.Clear();
        }
    }
}
