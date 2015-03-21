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
            InitializeCurrencies();
            InitializeList();
        }

        private void InitializeCurrencies()
        {
            comboBoxCurrency.Items.Clear();
            foreach (Currency c in Currency.GetAll().SafeEnum())
            {
                comboBoxCurrency.Items.Add(c);
            }
            if (comboBoxCurrency.Items.Count > 0) comboBoxCurrency.SelectedIndex = 0;
        }

        private void InitializeList()
        {
            this.sortableListViewTransfers.Columns.AddRange(new ColumnHeader[] {
                new ColumnHeader() { Name ="columnHeaderTransferDate", Text = "Date", TextAlign = HorizontalAlignment.Left, Width = 90 },
                new ColumnHeader() { Name ="columnHeaderTransferWeek", Text = "Week", TextAlign = HorizontalAlignment.Left, Width = 50 },
                new ColumnHeader() { Name ="columnHeaderTransferBoughtSold", Text = "B/S", TextAlign = HorizontalAlignment.Left, Width = 80 },
                new ColumnHeader() { Name ="columnHeaderTransferPlayer", Text = "Player", TextAlign = HorizontalAlignment.Left, Width = 220 },
                new ColumnHeader() { Name ="columnHeaderTransferTeam", Text = "Team", TextAlign = HorizontalAlignment.Left, Width = 220 },  
                new ColumnHeader() { Name ="columnHeaderTransferPrice", Text = "Price", TextAlign = HorizontalAlignment.Left, Width = 100 },
            });

            sortableListViewTransfers
                .SetSorter(0, UserControls.SortableListView.TagSorter<DateTime>())
                .SetSorter(1, UserControls.SortableListView.NullSorter)
                .SetSorter(5, UserControls.SortableListView.TagSorter<Money>());
        }

        public void ShowTransfers(TransferHistory th)
        {
            AdjustCurrency(th);
            FillList(th);
            FillChart(th);
        }

        private void AdjustCurrency(TransferHistory th)
        {
            Currency newCurrency = comboBoxCurrency.SelectedItem as Currency;
            if (newCurrency != null)
            {
                foreach (Transfer t in th.SafeEnum())
                {
                    t.Price.ConvertTo(newCurrency);
                }
            }
        }

        private void FillChart(TransferHistory th)
        {
#if !MONO
            chartBySeason.Series.Clear();
            chartBySeason.ResetAutoValues();
            if (th == null || th.Team == null) return;

            chartBySeason.SuspendLayout();
            
            // attach the shown data to the chart
            chartBySeason.Tag = th;

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

                Money amountBuys = new Money(0);
                Money amountSales = new Money(0);

                // ORIGINAL IMPLEMENTATION:
                //buys.ForEach(t => amountBuys += t.Price);
                //sales.ForEach(t => amountSales += t.Price);
                // REASON FOR CHANGE:
                // The transfer price should be right-hand-side to avoid showing the initial currency of amountBuys/Sales
                buys.ForEach(t => amountBuys = t.Price + amountBuys);   
                sales.ForEach(t => amountSales = t.Price + amountSales);

                StringBuilder toolBuilder = new StringBuilder("Season ").Append(season).AppendLine()
                    .Append("Number of buys: ").Append(noBuys).AppendLine()
                    .Append("Amount of buys: ").AppendLine(amountBuys.ToString())
                    .Append("Number of sales: ").Append(noSales).AppendLine()
                    .Append("Amount of sales: ").AppendLine(amountSales.ToString());

                boughtSeries.Points.Add(new DataPoint(season, amountBuys.Amount) { ToolTip = toolBuilder.ToString() });
                soldSeries.Points.Add(new DataPoint(season, amountSales.Amount) { ToolTip = toolBuilder.ToString() });
            }

            chartBySeason.Series.Add(boughtSeries);
            chartBySeason.Series.Add(soldSeries);

            chartBySeason.ResumeLayout();
#endif
		}

        private void FillList(TransferHistory th)
        {
            sortableListViewTransfers.Items.Clear();
            if (th == null || th.Team == null) return;

            sortableListViewTransfers.SuspendLayout();

            //attach the shown data to the list
            sortableListViewTransfers.Tag = th;

            int teamId = th.Team.ID;

            foreach (Transfer t in th.Transfers.SafeEnum())
            {
                // TODO: handle players which are "bought" and "sold" correctly
                if (t.Seller.ID == t.Buyer.ID) continue;

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

        private void comboBoxCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {            
            //Update Transfers
            TransferHistory th = sortableListViewTransfers.Tag as TransferHistory;
            if (null != th)
            {
                ShowTransfers(th);
            }
        }
    }
}
