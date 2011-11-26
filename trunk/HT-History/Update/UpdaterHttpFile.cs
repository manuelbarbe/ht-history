using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace HtHistory.Update
{
    class UpdaterHttpFile : IUpdater
    {
        // this file contains something like "0.1.6.0;http://ht-history.googlecode.com/files/HtHistory%200.1.6.msi"
        private readonly string INFO_ADDRESS = "http://ht-history.googlecode.com/files/latest";

        private string _updateDirectory = null;
        private string _updateUri = null;

        public UpdaterHttpFile(string updateDirectory)
        {
            if (updateDirectory == null) throw new ArgumentNullException("updateDirectory");
            
            _updateDirectory = updateDirectory;
        }

        public Version GetAvailableUpdateVersion(Version currentVersion)
        {
            Version ret = null;

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(INFO_ADDRESS);
                //request.Proxy = proxy;
                request.Timeout = 10000; // 10 sec.
                request.UserAgent = "HT-History";
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    string[] tokens = new StreamReader(response.GetResponseStream()).ReadLine().Split(';');
                    if (tokens.Length > 1)
                    {
                        Version v = Version.Parse(tokens[0]);
                        //if (v > currentVersion)
                        {
                            _updateUri = tokens[1];
                            return v;
                        }
                    }
                }

                response.Close(); // should we do this in case of an exception, too?
            }
            catch
            {
                // suppress
            }

            return ret;
        }

        public void ApplyUpdate()
        {
            if (_updateUri == null) throw new Exception("update uri was not read by previous GetAvailableUpdate() call");

            if (!Directory.Exists(_updateDirectory))
            {
                Directory.CreateDirectory(_updateDirectory);
            }

            string updateFile = Path.Combine(_updateDirectory, "update.msi");

            // Create a new WebClient instance.
			WebClient myWebClient = new WebClient();
			myWebClient.DownloadFile(_updateUri, updateFile);

            System.Diagnostics.Process.Start(updateFile);
            System.Environment.Exit(0);
        }
    }
}
