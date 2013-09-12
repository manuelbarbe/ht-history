using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtHistory.Core.DataContainers;

namespace HtHistory.Core.DataBridges.CacheBridges
{
    public class CacheMatchDetailsBridge : IMatchDetailsBridge
    {
        public CacheMatchDetailsBridge(IMatchDetailsBridge backingBridge)
        {
            if (backingBridge == null) throw new ArgumentNullException("backingBridge");
            _backingBridge = backingBridge;

            _cache = new Dictionary<uint, MatchDetails>();
        }

        private IMatchDetailsBridge _backingBridge;
        private Dictionary<uint, MatchDetails> _cache;

        public MatchDetails GetMatchDetails(uint matchId)
        {
            MatchDetails details;
            if (_cache.TryGetValue(matchId, out details))
            {
                return details;
            }
            else
            {
                details = _backingBridge.GetMatchDetails(matchId);
                _cache.Add(matchId, details);
                return details;
            }
        }
    }
}
