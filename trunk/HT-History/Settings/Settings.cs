using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using System.Xml.Linq;
using System.IO;

namespace HtHistory.Settings
{
    public class Settings : Dictionary<string, string>
    {
        private static readonly string RootName = "HtHistory";
        private static readonly string[] SupportedVersions = new[] { "1.0" };

        public Settings() { }

        public Settings(string filepath) { Load(filepath); }

        public void Load(string filepath)
        {
            XDocument doc = XDocument.Load(filepath);
            
            if ( doc.Root == null || doc.Root.Name == null || doc.Root.Name.LocalName == null )
            {
                throw new Exception("Document has no valid root node");
            }

            if ( ! RootName.Equals(doc.Root.Name.LocalName) )
            {
                throw new Exception(String.Format("Document root is not <{0}>", RootName));
            }

            XAttribute attrVersion = doc.Root.Attribute("version");
            if (attrVersion == null) 
            {
                throw new Exception("Version not specified");
            }

            string version = attrVersion.Value;

            if (!SupportedVersions.Contains(version))
            {
                throw new Exception(String.Format("Version {0} not supported", version));
            }

            foreach (XElement el in doc.Root.Descendants("Setting"))
            {
                XAttribute attrName = el.Attribute("name");
                XAttribute attrValue = el.Attribute("value");

                if (attrName == null || attrValue == null)
                {
                    throw new Exception(String.Format("invalid setting found: {0}", el));
                }

                this[attrName.Value] = attrValue.Value;
            }
        }

        public void Save(string filepath)
        {   
            XDocument doc = new XDocument(
            new XDeclaration("1.0", "utf-8", "yes"),
            new XElement(RootName, new XAttribute("version", "1.0")));

            foreach (var v in this)
            {
                doc.Root.Add(new XElement("Setting", new XAttribute("name", v.Key), new XAttribute("value",  v.Value)));
            }

            string directory = Path.GetDirectoryName(filepath);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            doc.Save(filepath);
        }
    }
}
