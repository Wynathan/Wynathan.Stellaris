using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Wynathan.Stellaris.Common.Attributes;

namespace Wynathan.Stellaris.Common.Parsing
{
    internal static class ParserCache
    {
        private static readonly Dictionary<Type, List<PropertyInfo>> propertiesCache = new Dictionary<Type, List<PropertyInfo>>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        /// <remarks>
        /// We'll use <see cref="Enumerable.ToArray{TSource}(IEnumerable{TSource})"/> 
        /// to create a copy of the cache.
        /// </remarks>
        public static PropertyInfo[] GetTypeCache(Type type)
        {
            if (type == null)
                return null;

            if (propertiesCache.ContainsKey(type))
                return propertiesCache[type].ToArray();

            var properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public);
            propertiesCache[type] = properties.ToList();
            return GetTypeCache(type);
        }

        public static PropertyInfo GetTypeCacheByName(Type type, string propertyName)
        {
            var cache = GetTypeCache(type);
            if (cache == null)
                return null;

            var propertyInfo = cache.Where(x => x.Name.Equals(propertyName, StringComparison.InvariantCultureIgnoreCase))
                .FirstOrDefault();

            if (propertyInfo != null)
                return propertyInfo;

            foreach (var entry in cache)
            {
                var bindingName = CommonBindingAttribute.GetBindingName(entry);
                if (propertyName.Equals(bindingName, StringComparison.InvariantCultureIgnoreCase))
                    return entry;
            }

            return null;
        }
    }
}
