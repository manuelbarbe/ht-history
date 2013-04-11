using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HtHistory.Translation
{
    /// <summary>
    /// Decorates text returned by specified translator with some string as pre- and postfix
    /// </summary>
    public class DecoratingTranslator : ITranslator
    {
        private ITranslator _decoratee;
        private string _decoration;

        public DecoratingTranslator(ITranslator decoratee, string decoration)
        {
            if (decoratee == null) throw new ArgumentNullException("decoratee");
            _decoratee = decoratee;
            _decoration = decoration; // null is ok here
        }

        public string Translate(string metaname)
        {
            string translation = _decoratee.Translate(metaname);
            return string.Format("{0}{1}{0}", _decoration, translation);
        }

        public bool TryTranslate(string metaname, out string translation)
        {
            bool result = _decoratee.TryTranslate(metaname, out translation);
            if (result) translation = string.Format("{0}{1}{0}", _decoration, translation);
            return result;
        }
    }
}
