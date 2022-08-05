using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HtHistory.Core.DataBridges.RestBridges
{
    public class RestBridgeBase
    {

        public string BaseUrl { get; protected set; }

        // HttpClient is intended to be instantiated once per application, rather than per-use. See Remarks.
        private readonly HttpClient client = new HttpClient();

        public RestBridgeBase(string base_url)
        {
            if (string.IsNullOrWhiteSpace(base_url)) throw new ArgumentException("base_url");

            if (base_url.EndsWith("/"))
            {
                base_url = base_url.Remove(base_url.Length-1);
            }

            BaseUrl = base_url;
        }

        protected string ReadFromUrl(string url)
        {
                HttpResponseMessage response = client.GetAsync(BaseUrl + url).Result;
                response.EnsureSuccessStatusCode();
                string responseBody = response.Content.ReadAsStringAsync().Result;

                return responseBody;
        }
    }
}
