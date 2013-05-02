using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using HtHistory.Core.ExtensionMethods;
using HtHistory.Core;

namespace HtHistory.Translation
{
    public class TranslatorFactory
    {
        public static IEnumerable<ITranslator> CreateTranslators()
        {
            yield return new DecoratingTranslator(new NullTranslator(), "%%");

            string transDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Locales");
            foreach (string file in Directory.GetFiles(transDir, "*.xml"))
            {
                ITranslator t = null;
                try
                {
                     t = new FallbackTranslator(new XmlTranslator(File.OpenRead(file)), new NullTranslator());
                }
                catch (Exception ex)
                {
                    HtLog.Warn(string.Format("Cannot parse file {0} ({1})", file, ex.ToString()));
                }

                if (t != null) yield return t;
            }

        }
    }
}
