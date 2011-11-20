using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HtHistory.Core.ExtensionMethods
{
    public static class EnumExtensions
    {

        #region SafeEnum

        public static IEnumerable<T> SafeEnum<T>(this IEnumerable<T> e) //where T : class
        {
            if (e != null)
            {
                foreach (T t in e)
                {
                    if (t != null) yield return t;
                }
            }
        }

        #endregion


        #region Split


        public static IDictionary<TKey, IEnumerable<TValue>> Split<TKey, TValue>(this IEnumerable<TValue> me, Func<TValue, TKey> keyFromValue) where TKey : IComparable<TKey>
        {
            IDictionary<TKey, IList<TValue>> ret = new Dictionary<TKey, IList<TValue>>();

            foreach (TValue v in me.SafeEnum())
            {
                TKey key = keyFromValue(v);

                if (!ret.ContainsKey(key))
                {
                    ret.Add(key, new List<TValue>());
                }

                ret[key].Add(v);
            }

            return (IDictionary<TKey, IEnumerable<TValue>>) ret;
        }

        #endregion



    }
}