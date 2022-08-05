using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtHistory.Toolbox;
using HtHistory.Data.Types;

namespace HtHistory.Statistics.Players
{
    public class MatchFilterOther : MatchFilterBase
    {
        public MatchFilterOther(IPlayerStatisticCalculator<IEnumerable<MatchAppearance>> calc) : base(calc) { }

        protected override string FilterName
        {
            get { return "Other"; }
        }

        protected override string FilterAbbreviation
        {
            get { return "Oth"; }
        }

        protected override IEnumerable<MatchAppearance> Filter(IEnumerable<MatchAppearance> matches)
        {
            return matches.Where(m => m.Match.Type.IsOtherSeniorMatch());
        }
    }
}
