using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HtHistory.Core.DataBridges.CacheBridges
{
    public class CacheBridge<T> : IDataBridge<T>
    {
        private IDictionary<uint, T> _cache = new Dictionary<uint, T>();

        public T Get(uint id)
        {
            T t;
            if (_cache.TryGetValue(id, out t))
            {
               // cache hit   
            }
            else
            {
                // cache miss, t is default(T)
            }
            return t;

        }

        public void Set(uint id, T t)
        {
            _cache[id] = t;
        }
    }
}
