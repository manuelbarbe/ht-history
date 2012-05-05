using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HtHistory.Core.DataContainers;
using HtHistory.Core.ExtensionMethods;
using System.Windows.Forms.DataVisualization.Charting;

namespace HtHistory.Pages
{
    public partial class TransfersPage : UserControl
    {
        public TransfersPage()
        {
            InitializeComponent();
            InitializeList();
        }


        private void InitializeList()
        {
            this.sortableListViewTransfers.Columns.AddRange(new ColumnHeader[] {
                new ColumnHeader() { Text = "Date", TextAlign = HorizontalAlignment.Left, Width = 90 },
                new ColumnHeader() { Text = "Week", TextAlign = HorizontalAlignment.Left, Width = 50 },
                new ColumnHeader() { Text = "B/S", TextAlign = HorizontalAlignment.Left, Width = 50 },
                new ColumnHeader() { Text = "Player", TextAlign = HorizontalAlignment.Left, Width = 220 },
                new ColumnHeader() { Text = "Team", TextAlign = HorizontalAlignment.Left, Width = 220 },  
                new ColumnHeader() { Text = "Price", TextAlign = HorizontalAlignment.Left, Width = 100 },
            });

            sortableListViewTransfers
                .SetSorter(0, UserControls.SortableListView.TagSorter<DateTime>())
                .SetSorter(1, UserControls.SortableListView.NullSorter)
                .SetSorter(5, UserControls.SortableListView.TagSorter<Money>());
        }

        public void ShowTransfers(TransferHistory th)
        {
            FillList(th);
            FillChart(th);
        }

        private void FillChart(TransferHistory th)
        {

            chartBySeason.Series.Clear();
            if (th == null || th.Team == null) return;

            chartBySeason.SuspendLayout();

            Series boughtSeries = new Series("Bought") { ChartType = SeriesChartType.Column };
            Series soldSeries = new Series("Sold") { ChartType = SeriesChartType.Column };

            int startSeason = new HtTime(th.From).Season;
            int endSeason = new HtTime(th.To).Season;

            for (int season = startSeason; season <= endSeason; ++season)
            {
                IEnumerable<Transfer> transfersOfSeason = th.Transfers.SafeEnum().Where(t => new HtTime(t.Date).Season == season);
                IEnumerable<Transfer> buys = transfersOfSeason.Where(t => t.Buyer != null && t.Buyer.ID == th.Team.ID);
                IEnumerable<Transfer> sales = transfersOfSeason.Where(t => t.Seller != null && t.Seller.ID == th.Team.ID);

                int noBuys = buys.Count();
                int noSales = sales.Count();

                // TODO: do some Money calculation (not double)
                double amountBuys = buys.Sum(t => t.Price.Amount);
                double amountSales = sales.Sum(t => t.Price.Amount);

                StringBuilder toolBuilder = new StringBuilder("Season ").Append(season).AppendLine()
                    .Append("Number of buys: ").Append(noBuys).AppendLine()
                    .Append("Amount of buys: ").AppendLine(string.Format("{0:0,0.}", amountBuys))
                    .Append("Number of sales: ").Append(noSales).AppendLine()
                    .Append("Amount of sales: ").AppendLine(string.Format("{0:0,0.}", amountSales));

                boughtSeries.Points.Add(new DataPoint(season, amountBuys) { ToolTip = toolBuilder.ToString() });
                soldSeries.Points.Add(new DataPoint(season, amountSales) { ToolTip = toolBuilder.ToString() });
            }

            chartBySeason.Series.Add(boughtSeries);
            chartBySeason.Series.Add(soldSeries);

            chartBySeason.ResumeLayout();
        }

        private void FillList(TransferHistory th)
        {
            sortableListViewTransfers.Items.Clear();
            if (th == null || th.Team == null) return;

            sortableListViewTransfers.SuspendLayout();

            uint teamId = th.Team.ID;

            foreach (Transfer t in th.Transfers.SafeEnum())
            {
                ListViewItem item = new ListViewItem(t.Date.ToShortDateString());
                item.Tag = t.Date;
                item.SubItems[0].Tag = item.Tag;

                object value = 0;

                value = new HtTime(t.Date);
                item.SubItems.Add(new ListViewItem.ListViewSubItem(item, (value != null) ? value.ToString() : "-") { Tag = value });

                value = (teamId == t.Buyer.ID) ? "bought" : "sold";
                item.SubItems.Add(new ListViewItem.ListViewSubItem(item, value.ToString()) { Tag = value });

                value = t.Player;
                item.SubItems.Add(new ListViewItem.ListViewSubItem(item, (value != null) ? value.ToString() : "-") { Tag = value });

                value = (teamId == t.Buyer.ID) ? t.Seller : t.Buyer;
                item.SubItems.Add(new ListViewItem.ListViewSubItem(item, (value != null) ? value.ToString() : "-") { Tag = value });

                value = t.Price;
                item.SubItems.Add(new ListViewItem.ListViewSubItem(item, (value != null) ? value.ToString() : "-") { Tag = value });

                sortableListViewTransfers.Items.Add(item);
            }

            sortableListViewTransfers.ResumeLayout();
        }
    }
}
