using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HtHistory.Translation
{
    /// <summary>
    /// Just returns the metaname everytime.
    /// </summary>
    public class NullTranslator : ITranslator
    {
        public string Translate(string metaname)
        {
            return metaname;
        }

        public bool TryTranslate(string metaname, out string translation)
        {
            translation = metaname;
            return true;
        }
    }
}
