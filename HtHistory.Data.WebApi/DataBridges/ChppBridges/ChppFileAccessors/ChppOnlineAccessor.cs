using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OAuth;
using System.IO;
using System.Xml.Linq;
using System.Linq;
using System.Net;
using System.Web;

namespace HtHistory.Core.DataBridges.ChppBridges.ChppFileAccessors
{
    public class ChppOnlineAccessor : IChppAccessor
    {
        public struct TToken
        {
            public string Token;
            public string TokenSecret;
        }

        private const string OAuthConsumerKey = "F5HcynlPU6EUkBr7Sl7BOU";
        private const string OAuthConsumerSecret = "FnHwc2wYj5j9vddHAxmdOp9PIGD4DdP5WQbA4hWufC6";
        private const string OAuthRequestTokenUrl = "https://chpp.hattrick.org/oauth/request_token.ashx";
        private const string OAuthAuthorizeUrl = "https://chpp.hattrick.org/oauth/authorize.aspx";
        private const string OAuthAccessTokenUrl = "https://chpp.hattrick.org/oauth/access_token.ashx";
        private const string OAuthProtectedResourceUrl = "http://chpp.hattrick.org/chppxml.ashx";

        private TToken _requestToken;
        private TToken _accessToken;

        public ChppOnlineAccessor(string proxy = null)
        {
            if (!string.IsNullOrEmpty(proxy))
            {
                // TODO
                //_oAuthSession.ProxyServerUri = new Uri(proxy);
            }
        }

        public ChppOnlineAccessor(string accessToken, string accessTokenSecret, string proxy = null) : this(proxy)
        {
            _accessToken.Token = accessToken;
            _accessToken.TokenSecret = accessTokenSecret;
        }

        public bool   IsValid() { return false; }

        public string GetAuthorizeUrl()
        {
            var client = OAuthRequest.ForRequestToken(OAuthConsumerKey, OAuthConsumerSecret, OAuthSignatureMethod.HmacSha1);
            client.RequestUrl = OAuthRequestTokenUrl;
            client.CallbackUrl = "oob";

            var url = client.RequestUrl + "?" + client.GetAuthorizationQuery();
            _requestToken = GetTokenFromUrl(url);

            return OAuthAuthorizeUrl + "?oauth_token=" + _requestToken.Token + "&oauth_callback=oob";
        }

        public string[] Authorize(string PIN)
        {
            var client = OAuthRequest.ForAccessToken(OAuthConsumerKey, OAuthConsumerSecret,
                                                     _requestToken.Token, _requestToken.TokenSecret,
                                                     PIN,
                                                     OAuthSignatureMethod.HmacSha1);

            client.RequestUrl = OAuthAccessTokenUrl;
            var url = client.RequestUrl + "?" + client.GetAuthorizationQuery();

            _accessToken = GetTokenFromUrl(url);
            return new string[2] {_accessToken.Token, _accessToken.TokenSecret};
        }

        public string GetResource(string parameters)
        {
            System.Console.Out.WriteLine("Requesting: {0}", parameters);

            var client = OAuthRequest.ForProtectedResource("GET", OAuthConsumerKey, OAuthConsumerSecret, _accessToken.Token, _accessToken.TokenSecret, OAuthSignatureMethod.HmacSha1);
            client.RequestUrl = OAuthProtectedResourceUrl + "?" + parameters;

            string url = client.RequestUrl + "&" + client.GetAuthorizationQuery();

            //var dictParam = ParseParameters(parameters);
            //string url = client.RequestUrl + "?" + parameters + "&" + client.GetAuthorizationQuery(dictParam);

            string result = GetStringFromUrl(url);

            if (result.Contains(@"chpperror.xml")) // <FileName>chpperror.xml</FileName>
            {
                int errorCode = -1;
                string errorDescription = "unknown CHPP error";

                try
                {
                    XDocument doc = XDocument.Load(new StringReader(result));
                    XElement elRoot = doc.Root;

                    if (elRoot != null)
                    {
                        XElement elErrorCode = elRoot.Element("ErrorCode");
                        if (elErrorCode != null)
                        {
                            int.TryParse(elErrorCode.Value, out errorCode);
                        }

                        XElement elErrorDescription = elRoot.Element("Error");
                        if (elErrorDescription != null && !string.IsNullOrEmpty(elErrorDescription.Value))
                        {
                            errorDescription = elErrorDescription.Value;
                        }
                    }
                }
                finally
                {
                    throw new ChppException(errorCode, errorDescription);
                }
            }

            return result;
        }


        public System.IO.TextReader GetDataReader(string query, DataFlags flags)
        {
            return new StringReader(GetResource(query));
        }

        private string GetStringFromUrl(string url)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            var response = (HttpWebResponse)request.GetResponse();

            if (response.StatusCode == HttpStatusCode.OK)
            {

                string returnedString;
                using (var reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                {
                    //example: "oauth_token=blablabla&oauth_token_secret=blubblubblub&oauth_callback_confirmed=true"
                    returnedString = reader.ReadToEnd();
                }
                return returnedString;
            }
            else
            {
                throw new Exception("Unexected response from " + response.ResponseUri + ": " + response.StatusCode);
            }
        }

        private TToken GetTokenFromUrl(string url)
        {
            return ParseTokenResponse(GetStringFromUrl(url));
        }

        private TToken ParseTokenResponse(string response)
        {
            var pars = ParseParameters(response);

            TToken token = new TToken();
            token.Token = pars.ContainsKey("oauth_token") ? pars["oauth_token"] : string.Empty;
            token.TokenSecret = pars.ContainsKey("oauth_token_secret") ? pars["oauth_token_secret"] : string.Empty;

            /*
            foreach (var s in response.Split('&'))
            {
                var kvp = s.Split('=');
                if (kvp.Length >= 2 && !string.IsNullOrWhiteSpace(kvp[0]))
                {
                    switch (kvp[0])
                    {
                        case "oauth_token": token.Token = kvp[1]; break;
                        case "oauth_token_secret": token.TokenSecret = kvp[1]; break;
                        default: break;
                    }
                }
            }
            */
            return token;
        }

        private IDictionary<string, string> ParseParameters(string par)
        {
            IDictionary<string, string> result = new Dictionary<string, string>();

            foreach (var s in par.Split('&'))
            {
                var kvp = s.Split('=');
                if (kvp.Length >= 2 && !string.IsNullOrWhiteSpace(kvp[0]))
                {
                    result.Add(kvp[0], kvp[1]);
                }
            }
            return result;
        }
    }
}
