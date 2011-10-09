using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevDefined.OAuth.Consumer;
using DevDefined.OAuth.Framework;
using System.IO;

namespace HtHistory.Core.DataBridges.ChppBridges.ChppFileAccessors
{
    public class ChppOnlineAccessor : IChppAccessor
    {
        private const string OAuthConsumerKey = "F5HcynlPU6EUkBr7Sl7BOU";
        private const string OAuthConsumerSecret = "FnHwc2wYj5j9vddHAxmdOp9PIGD4DdP5WQbA4hWufC6";
        private const string OAuthRequestTokenUrl = "https://chpp.hattrick.org/oauth/request_token.ashx";
        private const string OAuthAuthorizeUrl = "https://chpp.hattrick.org/oauth/authorize.aspx";
        private const string OAuthAccessTokenUrl = "https://chpp.hattrick.org/oauth/access_token.ashx";
        private const string OAuthProtectedResourceUrl = "http://chpp.hattrick.org/chppxml.ashx";

        public ChppOnlineAccessor(string proxy = null)
        {
            OAuthConsumerContext context = new OAuthConsumerContext()
            { 
                                            ConsumerKey = OAuthConsumerKey,
                                            ConsumerSecret = OAuthConsumerSecret,
                                            SignatureMethod = SignatureMethod.HmacSha1
            };

            _oAuthSession = new OAuthSession(context, OAuthRequestTokenUrl, OAuthAuthorizeUrl, OAuthAccessTokenUrl);
            
            if (!string.IsNullOrEmpty(proxy))
            {
                _oAuthSession.ProxyServerUri = new Uri(proxy);
            }
        }

        public ChppOnlineAccessor(string accessToken, string accessTokenSecret, string proxy = null) : this(proxy)
        {
            _oAuthSession.AccessToken = new TokenBase(){ ConsumerKey = OAuthConsumerKey, Token = accessToken, TokenSecret = accessTokenSecret };
        }

        private IToken _requestToken;
        protected OAuthSession _oAuthSession;

        public bool   IsValid() { return false; }

        public string GetAuthorizeUrl()
        {
             _requestToken = _oAuthSession.GetRequestToken();
             return _oAuthSession.GetUserAuthorizationUrlForToken(_requestToken, "oob");
        }

        public string[] Authorize(string PIN)
        {
            _oAuthSession.AccessToken = _oAuthSession.ExchangeRequestTokenForAccessToken(_requestToken, PIN);
            return new [] { _oAuthSession.AccessToken.Token, _oAuthSession.AccessToken.TokenSecret };
        }

        public string GetResource(string parameters)
        {
            System.Console.Out.WriteLine("Requesting: {0}", parameters);

            string url = OAuthProtectedResourceUrl + "?" + parameters;
            IConsumerRequest request = _oAuthSession.Request().Get().ForUrl(url);
            
            return request.ToString();
        }


        public System.IO.TextReader GetDataReader(string query, DataFlags flags)
        {
            return new StringReader(GetResource(query));
        }
    }
}
