using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Text;
using System.IO;
using HtHistory.Core.ExtensionMethods;
using HtHistory.Core.DataContainers;
using HtHistory.Core.DataBridges.ChppBridges.ChppFileAccessors;
using System.Globalization;

namespace HtHistory.Core.DataBridges.ChppBridges
{
    public class ChppMatchArchiveBridge : ChppBridgeBase, IMatchArchiveBridge
    {
        public ChppMatchArchiveBridge(IChppAccessor chppSession)
            : base(chppSession)
        {
        }

        public MatchArchive GetMatches(uint teamId, DateTime startDate, DateTime endDate)
        {
            List<Match> matches = new List<Match>();
            DateTime curMonthStart = startDate;
            Team team = null;

            // 15 minute grid
            endDate = endDate.AddSeconds(-endDate.Second);
            endDate = endDate.AddMinutes(-(endDate.Minute % 15));

            while (curMonthStart < endDate)
            {
                DateTime curMonthEnd = new DateTime(curMonthStart.Year, curMonthStart.Month, 1).AddMonths(1).AddSeconds(-1);
                if (curMonthEnd > endDate) curMonthEnd = endDate;

                string url = new StringBuilder("file=matchesarchive&version=1.1")
                                        .Append("&teamID=").Append(teamId)
                                        .Append("&firstmatchdate=").Append(curMonthStart.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture))
                                        .Append("&lastmatchdate=").Append(curMonthEnd.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)).ToString();
                                       

                XDocument doc = XDocument.Load(ChppAccessor.GetDataReader(url, DataFlags.Static));

                XElement elTeam = doc.Root.AssertElement("Team");

                Team compTeam = MatchParserHelper.GetTeam(elTeam, string.Empty);
                if (teamId != compTeam.ID) throw new Exception("received wrong team info");
                team = compTeam;
                // assert dates

                foreach (XElement el in doc.Descendants("Match"))
                {
                    matches.Add(MatchParserHelper.GetMatch(el));
                }

                curMonthStart = curMonthEnd.AddSeconds(1);
            }

            // TODO: team may be null here (if endDate < startDate)
            MatchArchive ar = new MatchArchive(team, startDate, endDate);
            ar.Matches = matches;

            return ar;
        }

    }


}
