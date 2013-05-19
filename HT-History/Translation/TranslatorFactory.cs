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
        public static IEnumerable<ITranslator> Translators { get; private set; }
        public static ITranslator DefaultTranslator { get; private set; }

        static TranslatorFactory()
        {
            Translators = CreateTranslators();
            DefaultTranslator = ChooseDefaultTranslator(Translators);
        }

        private static ITranslator ChooseDefaultTranslator(IEnumerable<ITranslator> translators)
        {
            // "English" is default
            ITranslator defaultTranslator = translators.FirstOrDefault(t => t.ToString().Equals("English"));
            if (defaultTranslator == null)
            { // if "English is not found, choose the first one
                defaultTranslator = translators.FirstOrDefault();
                if (defaultTranslator == null)
                { //if no translator is present, do not translate at all
                    defaultTranslator = new NullTranslator();
                }
            }
            return defaultTranslator;
        }

        private static IEnumerable<ITranslator> CreateTranslators()
        {
            //yield return new DecoratingTranslator(new NullTranslator(), "%%");

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
