﻿using System;
using System.Text;
using System.IO;

namespace HtHistory.Core.DataBridges.ChppBridges.ChppFileAccessors
{
    /// <summary>
    /// CHPP data accessor that reads from filesystem. If not locally available, data may be read from a fallback accessor.
    /// </summary>
    public class ChppFilesystemAccessor : IChppAccessor
    {
        public readonly string DataDirectory;

        /// <summary>
        /// standard ctor
        /// </summary>
        public ChppFilesystemAccessor(string directory)
        {
            DataDirectory = directory;
        }
        
        /// <summary>
        /// ctor with fallback
        /// </summary>
        /// <param name="fallback">Fallback that is used to get data that is not present at filesystem</param>
        public ChppFilesystemAccessor(string directory, IChppAccessor fallback) : this(directory)
        {
            FallbackAccessor = fallback;
        }

        /// <summary>
        /// Fallback that is used to get data that is not present at filesystem
        /// </summary>
        public IChppAccessor FallbackAccessor { get; private set; }

        /// <summary>
        /// Gets data from filesystem or if not available from fallback (e.g. CHPP online connection)
        /// </summary>
        /// <param name="query">data query as defined at chpp API</param>
        /// <param name="flags">flags that give hint about data properties</param>
        /// <returns>TextReader to data</returns>
        public TextReader GetDataReader(string query, DataFlags flags)
        {
            string filepath = Path.Combine(DataDirectory, query.Replace(":", string.Empty)); // TODO use: replace all non filename chars

            if ( (flags & DataFlags.Static) == DataFlags.Static || // if data isn't expected to change
                 FallbackAccessor == null)                         // or if we don't have any fallback (e.g. online)
            {                
                if (File.Exists(filepath))
                {
                    using (FileStream fileStream = File.OpenRead(filepath))
                    {
                        MemoryStream memoryStream = new MemoryStream((int)fileStream.Length);
                        fileStream.CopyTo(memoryStream); // copying file to memory allows Dispose of FileStream here
                                                         // this should definitely be done my clients later, not here (TODO)
                        memoryStream.Position = 0;
                        return new StreamReader(memoryStream);
                    }
                }
            }
            
            return GetAndBackupDataFromFallback(query, flags);
        }

        private TextReader GetAndBackupDataFromFallback(string query, DataFlags flags)
        {
            if (FallbackAccessor == null) throw new Exception("Cannot get requested data for " + query);
            
            if (!Directory.Exists(DataDirectory))
            {
                Directory.CreateDirectory(DataDirectory);
            }

            using (TextReader fallbackReader = FallbackAccessor.GetDataReader(query, flags))
            {
                string fileContent = fallbackReader.ReadToEnd();
                File.WriteAllText(Path.Combine(DataDirectory, query.Replace(":", string.Empty)), fileContent, Encoding.UTF8); // Todo remove hard encoding
                return new StringReader(fileContent);
            }
        }
    }
}
