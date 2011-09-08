using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;

namespace HtHistory.Core.DataBridges.ChppBridges.ChppFileAccessors
{
    public class ChppFilesystemAccessor : IChppAccessor
    {
        public readonly string DataDirectory = "data";

        public ChppFilesystemAccessor() {}
        public ChppFilesystemAccessor(IChppAccessor fallback)
        {
            FallbackAccessor = fallback;
        }

        public IChppAccessor FallbackAccessor { get; private set; }

        public TextReader GetDataReader(string query, DataFlags flags)
        {
            if ((flags & DataFlags.Static) == DataFlags.Static)
            {
                string fullDataDirectoryPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, DataDirectory);
                string filepath = Path.Combine(fullDataDirectoryPath, query.Replace(":", string.Empty)); // TODO use: replace all non filename chars

                if (File.Exists(filepath))
                {
                    return new StreamReader(File.OpenRead(filepath));
                }
                else if (FallbackAccessor != null)
                {
                    if (!Directory.Exists(fullDataDirectoryPath))
                    {
                        Directory.CreateDirectory(fullDataDirectoryPath);
                    }
                    string fileContent = FallbackAccessor.GetDataReader(query, flags).ReadToEnd();
                    File.WriteAllText(filepath, fileContent, Encoding.UTF8); // Todo remove hard encoding
                    return new StringReader(fileContent);
                }
                else
                {
                    throw new Exception("Cannot get requested data for " + query);
                }
            }
            else
            {
                if (FallbackAccessor != null) return FallbackAccessor.GetDataReader(query, flags);
                else throw new Exception("Cannot get requested data for " + query);
            }
            
        }
    }
}
