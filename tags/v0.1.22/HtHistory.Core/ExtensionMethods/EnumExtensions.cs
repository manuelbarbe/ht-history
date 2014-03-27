using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

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

        public static IEnumerable SafeEnum(this IEnumerable e) //where T : class
        {
            if (e != null)
            {
                foreach (object t in e)
                {
                    if (t != null) yield return t;
                }
            }
        }

        public static void ForEach<T>(this IEnumerable<T> e, Action<T> action)
        {
            foreach (T t in e) action(t);
        }

        #endregion



        #region Split

        public static IDictionary<TKey, IEnumerable<TValue>> Split<TKey, TValue>(this IEnumerable<TValue> me, Func<TValue, TKey> keyFromValue) where TKey : IComparable<TKey>
        {
            IDictionary<TKey, IEnumerable<TValue>> ret = new Dictionary<TKey, IEnumerable<TValue>>();

            foreach (TValue v in me.SafeEnum())
            {
                TKey key = keyFromValue(v);

                if (!ret.ContainsKey(key))
                {
                    ret.Add(key, new List<TValue>());
                }

                ((List<TValue>)ret[key]).Add(v);
            }

            return ret;
        }

        #endregion



    }
}