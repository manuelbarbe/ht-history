using System;
using System.Text;
using System.IO;

namespace HtHistory.Core.DataBridges.ChppBridges.ChppFileAccessors
{
    /// <summary>
    /// CHPP data accessor that reads from filesystem. If not locally available, data may be read from a fallback accessor.
    /// </summary>
    public class ChppFilesystemAccessor : IChppAccessor
    {
        public readonly string DataDirectory = "data";

        /// <summary>
        /// standard ctor
        /// </summary>
        public ChppFilesystemAccessor() {}
        
        /// <summary>
        /// ctor with fallback
        /// </summary>
        /// <param name="fallback">Fallback that is used to get data that is not present at filesystem</param>
        public ChppFilesystemAccessor(IChppAccessor fallback)
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
            string fullDataDirectoryPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, DataDirectory);
            string filepath = Path.Combine(fullDataDirectoryPath, query.Replace(":", string.Empty)); // TODO use: replace all non filename chars

            if ( (flags & DataFlags.Static) == DataFlags.Static || // if data isn't expected to change
                 FallbackAccessor == null)                         // or if we don't have any fallback (e.g. online)
            {                
                if (File.Exists(filepath))
                {
                    return new StreamReader(File.OpenRead(filepath));
                }
            }
            
            return GetAndBackupDataFromFallback(query, flags, fullDataDirectoryPath, filepath);
        }

        private TextReader GetAndBackupDataFromFallback(string query, DataFlags flags, string fullDataDirectoryPath, string filepath)
        {
            if (FallbackAccessor == null) throw new Exception("Cannot get requested data for " + query);
            
            if (!Directory.Exists(fullDataDirectoryPath))
            {
                Directory.CreateDirectory(fullDataDirectoryPath);
            }

            string fileContent = FallbackAccessor.GetDataReader(query, flags).ReadToEnd();
            File.WriteAllText(filepath, fileContent, Encoding.UTF8); // Todo remove hard encoding
            return new StringReader(fileContent);
        }
    }
}
