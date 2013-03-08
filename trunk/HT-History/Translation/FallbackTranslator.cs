using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HtHistory.Translation
{
    /// <summary>
    /// Uses specified default translator to do the actual translation. If this fails, it uses a specified fallback translator.
    /// </summary>
    public class FallbackTranslator : ITranslator
    {
        private ITranslator _defaultTranslator;
        private ITranslator _fallback;

        public FallbackTranslator(ITranslator defaultTranslator, ITranslator fallback)
        {
            if (_defaultTranslator == null) throw new ArgumentNullException("defaultTranslator");
            _defaultTranslator = defaultTranslator;
            _fallback = fallback;
        }

        public string Translate(string metaname)
        {
            try
            {
                return _defaultTranslator.Translate(metaname);
            }
            catch
            {
                if (_fallback != null) return _fallback.Translate(metaname);
                else throw;
            }
        }

        public bool TryTranslate(string metaname, out string translation)
        {
            bool res = _defaultTranslator.TryTranslate(metaname, out translation);
            if (!res && _fallback != null)
            {
                res = _fallback.TryTranslate(metaname, out translation);
            }
            return res;
        }
    }
}
