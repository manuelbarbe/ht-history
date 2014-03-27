using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HtHistory.Translation
{
    public interface ITranslator
    {
        /// <summary>
        /// Translates specified metaname to some text
        /// </summary>
        /// <param name="metaname">the metaname defining the text</param>
        /// <returns>(translated) text, never null (throws on failure)</returns>
        /// <exception cref="Exception">on error</exception>
        string Translate(string metaname);

        /// <summary>
        /// Tries to translate the specified metaname to some text
        /// </summary>
        /// <param name="metaname">the metaname defining the text</param>
        /// <param name="translation">out param for text</param>
        /// <returns>true if translation succeeded, otherwise false (out param translation is undefined in that case)</returns>
        bool TryTranslate(string metaname, out string translation);
    }
}
