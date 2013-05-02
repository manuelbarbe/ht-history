using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using HtHistory.Core.ExtensionMethods;
using System.IO;

namespace HtHistory.Translation
{
    public class XmlTranslator : ITranslator
    {
        private Dictionary<string, string> _translations = new Dictionary<string,string>();
        private string _language;

        public XmlTranslator(Stream stream)
        {
            if (stream == null) throw new ArgumentNullException("stream");
            Load(stream);
        }

        void Load(Stream stream)
        {
            _translations.Clear();
            _language = string.Empty;

            XDocument doc = XDocument.Load(stream);
            XElement elLanguage = doc.Root.AssertElement("Language");
            _language = elLanguage.Value;
            XElement elTranslations = doc.Root.AssertElement("Translations");
            foreach(XElement elTranslation in elTranslations.Elements("Translation").SafeEnum())
            {
                XAttribute attrId = elTranslation.Attribute("id");
                if (attrId != null)
                {
                    _translations.Add(attrId.Value, elTranslation.Value);
                }
            }
        }

        public string Translate(string metaname)
        {
            return _translations[metaname];
        }

        public bool TryTranslate(string metaname, out string translation)
        {
            return _translations.TryGetValue(metaname, out translation);
        }

        public override string ToString()
        {
            return _language;
        }
    }
}
