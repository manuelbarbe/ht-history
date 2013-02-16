using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HtHistory.Core.DataBridges.ProxyBridges
{
    public class FallthroughBridge<T> : IDataBridge<T>
    {
        private IDataBridge<T> _first;
        private IDataBridge<T> _second;

        /// <summary>
        /// Creates a chain of data bridges
        /// </summary>
        /// <param name="first">First part of chain. It is queried first.
        /// If this fails it updated with the result from 'second'</param>
        /// <param name="second">Second part of chain. Is queried if 'first' fails.</param>
        public FallthroughBridge(IDataBridge<T> first, IDataBridge<T> second)
        {
            if (first == null || second == null) throw new ArgumentNullException("first or second");
            _first = first;
            _second = second;
        }

        /// <summary>
        /// Gets value from chain.
        /// </summary>
        /// <param name="id">identifier of queried value</param>
        /// <returns>the value</returns>
        public T Get(uint id)
        {
            T t = SafeGet(_second, id);

            if (!EqualityComparer<T>.Default.Equals(t, default(T)))
            {
                _first.Set(id, t);
            }

            return t;
        }

        /// <summary>
        /// Gets value from specified bridge without throwing anything
        /// </summary>
        /// <param name="b">bridge to query</param>
        /// <param name="id">identifier to query</param>
        /// <returns>value or default(T) on failure</returns>
        private T SafeGet(IDataBridge<T> b, uint id)
        {
            try
            {
                return b.Get(id);
            }
            catch (Exception)
            {
                return default(T);
            }
        }

        /// <summary>
        /// Sets value to first element of chain
        /// </summary>
        /// <param name="id">identifier</param>
        /// <param name="t">value</param>
        public void Set(uint id, T t)
        {
            _first.Set(id, t);
        }
    }
}
