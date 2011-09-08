using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HtHistory.Core.ExtensionMethods
{
    public static class EnumExtensions
    {
        public static IEnumerable<T> SafeEnum<T>(this IEnumerable<T> e) where T : class
        {
            if (e != null)
            {
                foreach (T t in e)
                {
                    if (t != null) yield return t;
                }
            }
        }
    }
}