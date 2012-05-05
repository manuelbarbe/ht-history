using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtHistory.Core.DataBridges.ChppBridges.ChppFileAccessors;
using HtHistory.Core.DataContainers;
using System.Xml.Linq;
using HtHistory.Core.ExtensionMethods;

namespace HtHistory.Core.DataBridges.ChppBridges
{
    public class ChppTransferHistoryBridge : ChppBridgeBase, ITransferHistoryBridge
    {
        public ChppTransferHistoryBridge(IChppAccessor accessor)
            : base(accessor)
        {

        }

        public TransferHistory GetTransfers(uint teamId)
        {
            Team team = null;
            DateTime from = DateTime.MaxValue;
            DateTime to = DateTime.MinValue;
            List<Transfer> transfers = new List<Transfer>();

            uint numberOfPages = 0; 
            uint curPage = 1;

            do
            {
                string url = new StringBuilder("file=transfersteam&version=1.2")
                                .Append("&teamID=").Append(teamId)
                                .Append("&pageIndex=")
                                .Append(curPage).ToString();

                XDocument doc = XDocument.Load(ChppAccessor.GetDataReader(url, DataFlags.Dynamic));

                team = MatchParserHelper.GetTeam(doc.Root.AssertElement("Team"), string.Empty);

                XElement elStats = doc.Root.AssertElement("Stats");
                uint numberOfBuys = uint.Parse(elStats.AssertElement("NumberOfBuys").Value);
                uint numberOfSales = uint.Parse(elStats.AssertElement("NumberOfSales").Value);

                numberOfPages = (numberOfBuys + numberOfSales + 24) / 25;

                XElement elTransfers = doc.Root.AssertElement("Transfers");
                DateTime startDate = DateTime.Parse(elTransfers.AssertElement("StartDate").Value);
                DateTime endDate = DateTime.Parse(elTransfers.AssertElement("EndDate").Value);
                if (startDate < from) from = startDate;
                if (endDate > to) to = endDate;

                foreach (XElement elTransfer in elTransfers.Elements("Transfer"))
                {
                    uint id = uint.Parse(elTransfer.AssertElement("TransferID").Value);
                    DateTime date = DateTime.Parse(elTransfer.AssertElement("Deadline").Value);
                    Player player = MatchParserHelper.GetPlayer(elTransfer.AssertElement("Player"));
                    Team buyer = MatchParserHelper.GetTeam(elTransfer.AssertElement("Buyer"), "Buyer");
                    Team seller = MatchParserHelper.GetTeam(elTransfer.AssertElement("Seller"), "Seller");
                    Money price = new Money(double.Parse(elTransfer.AssertElement("Price").Value), Currency.SEK);

                    transfers.Add( new Transfer(id, date, player, buyer, seller, price) );
                }

            } while (curPage++ < numberOfPages);

            return new TransferHistory(team, from, to) { Transfers = transfers };
        }
    }
}
