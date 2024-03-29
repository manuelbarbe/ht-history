﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using HtHistory.Toolbox;
using HtHistory.Core;

namespace HtHistory.Translation
{
    public class TranslatorFactory
    {
        public static IEnumerable<ITranslator> Translators { get; private set; }
        
        static TranslatorFactory()
        {
            Translators = CreateTranslators();
        }

        public static ITranslator FindTranslator(string name)
        {
            return Translators.SafeEnum().FirstOrDefault(t => t.ToString().Equals(name));
        }

        public static ITranslator GetDefaultTranslator()
        {
            // "English" is default
            ITranslator defaultTranslator = FindTranslator("English");
            if (defaultTranslator == null)
            { // if "English is not found, choose the first one
                defaultTranslator = Translators.SafeEnum().FirstOrDefault();
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
                    // TODO: english should be fallback!!
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
