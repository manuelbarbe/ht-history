using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtHistory.Core.ExtensionMethods;

namespace HtHistory.Statistics.Players
{
    public class MatchFilterQualifier : MatchFilterBase
    {
        public MatchFilterQualifier(IPlayerStatisticCalculator<IEnumerable<MatchAppearance>> calc) : base(calc) { }

        protected override string FilterName
        {
            get { return "Qualifier"; }
        }

        protected override string FilterAbbreviation
        {
            get { return "Qua"; }
        }

        protected override IEnumerable<MatchAppearance> Filter(IEnumerable<MatchAppearance> matches)
        {
            return matches.Where(m => m.Match.Type.IsQualifierMatch());
        }
    }
}
