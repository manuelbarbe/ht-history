using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtHistory.Core.DataContainers;
using HtHistory.Statistics;
using HtHistory.Statistics.Players;
using System.Windows.Forms;
using System.ComponentModel;
using HtHistory.Core;
using System.Drawing;

namespace HtHistory.Pages
{
    public class OverviewPage : OverviewDetailsPage
    {

        private class ResultData
        {
            public IDictionary<Player, PlayerStatisticItem<MatchAppearance>> Infos { get; set; }
            public IEnumerable<Player> CurrentPlayers { get; set; }
        }

        public OverviewPage()
        {
            InitializeComponent();
        }

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem copyToClipboardToolStripMenuItem;

        private void InitializeComponent()
        {
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip();
            this.copyToClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToClipboardToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(170, 48);
            // 
            // copyToClipboardToolStripMenuItem
            // 
            this.copyToClipboardToolStripMenuItem.Name = "copyToClipboardToolStripMenuItem";
            this.copyToClipboardToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.copyToClipboardToolStripMenuItem.Text = "Copy to clipboard";
            this.copyToClipboardToolStripMenuItem.Click += new System.EventHandler(this.copyToClipboardToolStripMenuItem_Click);

            this.sortableListViewOverview.Columns.AddRange(new ColumnHeader[] {
                new ColumnHeader() { Text = "Name", TextAlign = HorizontalAlignment.Left, Width = 225 },
                new ColumnHeader() { Text = "TM", TextAlign = HorizontalAlignment.Center, Width = 40 },
                new ColumnHeader() { Text = "TG", TextAlign = HorizontalAlignment.Center, Width = 40 },
                new ColumnHeader() { Text = "LM", TextAlign = HorizontalAlignment.Center, Width = 40 },
                new ColumnHeader() { Text = "LG", TextAlign = HorizontalAlignment.Center, Width = 40 },
                new ColumnHeader() { Text = "CM", TextAlign = HorizontalAlignment.Center, Width = 40 },
                new ColumnHeader() { Text = "CG", TextAlign = HorizontalAlignment.Center, Width = 40 },
                new ColumnHeader() { Text = "QM", TextAlign = HorizontalAlignment.Center, Width = 40 },
                new ColumnHeader() { Text = "QG", TextAlign = HorizontalAlignment.Center, Width = 40 },
                new ColumnHeader() { Text = "FM", TextAlign = HorizontalAlignment.Center, Width = 40 },
                new ColumnHeader() { Text = "FG", TextAlign = HorizontalAlignment.Center, Width = 40 },
                new ColumnHeader() { Text = "OM", TextAlign = HorizontalAlignment.Center, Width = 40 },
                new ColumnHeader() { Text = "OG", TextAlign = HorizontalAlignment.Center, Width = 40 },
                new ColumnHeader() { Text = "First", TextAlign = HorizontalAlignment.Left, Width = 80 },
                new ColumnHeader() { Text = "Last", TextAlign = HorizontalAlignment.Left, Width = 80 } });

            sortableListViewOverview
                .SetSorter(1, UserControls.SortableListView.TagSorter<int>())
                .SetSorter(2, UserControls.SortableListView.TagSorter<int>())
                .SetSorter(3, UserControls.SortableListView.TagSorter<int>())
                .SetSorter(4, UserControls.SortableListView.TagSorter<int>())
                .SetSorter(5, UserControls.SortableListView.TagSorter<int>())
                .SetSorter(6, UserControls.SortableListView.TagSorter<int>())
                .SetSorter(7, UserControls.SortableListView.TagSorter<int>())
                .SetSorter(8, UserControls.SortableListView.TagSorter<int>())
                .SetSorter(9, UserControls.SortableListView.TagSorter<int>())
                .SetSorter(10, UserControls.SortableListView.TagSorter<int>())
                .SetSorter(11, UserControls.SortableListView.TagSorter<int>())
                .SetSorter(12, UserControls.SortableListView.TagSorter<int>())
                .SetSorter(13, UserControls.SortableListView.TagSorter<DateTime>())
                .SetSorter(14, UserControls.SortableListView.TagSorter<DateTime>());

            this.sortableListViewOverview.SelectedIndexChanged += OverviewSelectedIndexChanged;
            this.sortableListViewOverview.ContextMenuStrip = contextMenuStrip1;

            this.sortableListViewDetails.Columns.AddRange(new ColumnHeader[] {
                new ColumnHeader() { Text = "Name", TextAlign = HorizontalAlignment.Left, Width = 225 },
                new ColumnHeader() { Text = "TM", TextAlign = HorizontalAlignment.Center, Width = 40 },
                new ColumnHeader() { Text = "TG", TextAlign = HorizontalAlignment.Center, Width = 40 },
                new ColumnHeader() { Text = "LM", TextAlign = HorizontalAlignment.Center, Width = 40 },
                new ColumnHeader() { Text = "LG", TextAlign = HorizontalAlignment.Center, Width = 40 },
                new ColumnHeader() { Text = "CM", TextAlign = HorizontalAlignment.Center, Width = 40 },
                new ColumnHeader() { Text = "CG", TextAlign = HorizontalAlignment.Center, Width = 40 },
                new ColumnHeader() { Text = "QM", TextAlign = HorizontalAlignment.Center, Width = 40 },
                new ColumnHeader() { Text = "QG", TextAlign = HorizontalAlignment.Center, Width = 40 },
                new ColumnHeader() { Text = "FM", TextAlign = HorizontalAlignment.Center, Width = 40 },
                new ColumnHeader() { Text = "FG", TextAlign = HorizontalAlignment.Center, Width = 40 },
                new ColumnHeader() { Text = "OM", TextAlign = HorizontalAlignment.Center, Width = 40 },
                new ColumnHeader() { Text = "OG", TextAlign = HorizontalAlignment.Center, Width = 40 },
                new ColumnHeader() { Text = "First", TextAlign = HorizontalAlignment.Left, Width = 80 },
                new ColumnHeader() { Text = "Last", TextAlign = HorizontalAlignment.Left, Width = 80 } });

            sortableListViewDetails
                .SetSorter(1, UserControls.SortableListView.TagSorter<int>())
                .SetSorter(2, UserControls.SortableListView.TagSorter<int>())
                .SetSorter(3, UserControls.SortableListView.TagSorter<int>())
                .SetSorter(4, UserControls.SortableListView.TagSorter<int>())
                .SetSorter(5, UserControls.SortableListView.TagSorter<int>())
                .SetSorter(6, UserControls.SortableListView.TagSorter<int>())
                .SetSorter(7, UserControls.SortableListView.TagSorter<int>())
                .SetSorter(8, UserControls.SortableListView.TagSorter<int>())
                .SetSorter(9, UserControls.SortableListView.TagSorter<int>())
                .SetSorter(10, UserControls.SortableListView.TagSorter<int>())
                .SetSorter(11, UserControls.SortableListView.TagSorter<int>())
                .SetSorter(12, UserControls.SortableListView.TagSorter<int>())
                .SetSorter(13, UserControls.SortableListView.TagSorter<DateTime>())
                .SetSorter(14, UserControls.SortableListView.TagSorter<DateTime>());

            this.contextMenuStrip1.ResumeLayout(false);
        }

        public void OverviewSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                sortableListViewDetails.Items.Clear();

                if (sortableListViewOverview.SelectedItems.Count == 0) return;

                PlayerStatisticItem<MatchAppearance> sitem = sortableListViewOverview.SelectedItems[0].Tag as PlayerStatisticItem<MatchAppearance>;

                if (sitem == null) return;

                IDictionary<int, PlayerStatisticItem<MatchAppearance>> appearancesBySeason = new Dictionary<int, PlayerStatisticItem<MatchAppearance>>();

                foreach (MatchAppearance d in sitem.TotalItems)
                {
                    int season = new HtTime(d.Match.Date).Season;

                    if (!appearancesBySeason.ContainsKey(season))
                    {
                        appearancesBySeason.Add(season, new PlayerStatisticItem<MatchAppearance>(d.Player));
                    }

                    appearancesBySeason[season].Add(d, d.Match.Date, d.Match.Type);
                }


                foreach(var v in appearancesBySeason)
                {
                    var m = v.Value;

                    ListViewItem item = new ListViewItem(string.Format("Season {0,02}", v.Key));
                    item.Tag = m;
                    item.SubItems[0].Tag = item.Tag;

                    object value = 0;

                    value = m.TotalItems.Count;
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, value.ToString()) { Tag = value });
                    value = m.TotalItems.Sum(ma => ma.Goals.Count);
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, value.ToString()) { Tag = value });

                    value = m.LeagueItems.Count;
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, value.ToString()) { Tag = value });
                    value = m.LeagueItems.Sum(ma => ma.Goals.Count);
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, value.ToString()) { Tag = value });

                    value = m.CupItems.Count;
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, value.ToString()) { Tag = value });
                    value = m.CupItems.Sum(ma => ma.Goals.Count);
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, value.ToString()) { Tag = value });

                    value = m.QualifierItems.Count;
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, value.ToString()) { Tag = value });
                    value = m.QualifierItems.Sum(ma => ma.Goals.Count);
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, value.ToString()) { Tag = value });

                    value = m.FriendlyItems.Count;
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, value.ToString()) { Tag = value });
                    value = m.FriendlyItems.Sum(ma => ma.Goals.Count);
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, value.ToString()) { Tag = value });

                    value = m.OtherItems.Count;
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, value.ToString()) { Tag = value });
                    value = m.OtherItems.Sum(ma => ma.Goals.Count);
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, value.ToString()) { Tag = value });

                    value = m.First;
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, ((DateTime)value).ToShortDateString()) { Tag = value });

                    value = m.Last;
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, ((DateTime)value).ToShortDateString()) { Tag = value });

                    sortableListViewDetails.Items.Add(item);
                }
            
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        protected override void DoWork(object sender, DoWorkEventArgs e)
        {
            StandardPlayerStatistics ts = new StandardPlayerStatistics(
                new MatchGetter(Environment.Team == null ? 0 : Environment.Team.ID,
                                Environment.Opponent == null ? 0 : Environment.Opponent.ID,
                                Environment.DataBridgeFactory.TeamDetailsBridge,
                                Environment.DataBridgeFactory.MatchArchiveBridge,
                                Environment.DataBridgeFactory.MatchDetailsBridge));
       
            IEnumerable<Player> currentPlayers = new List<Player>();
            try
            {
                currentPlayers = Environment.DataBridgeFactory.PlayersBridge.GetPlayers(Environment.Team.ID);
            }
            catch (Exception ex)
            {
                HtLog.Warn("Cannot get current players ({0})", ex.ToString());
            }

            e.Result = new ResultData() {
                Infos = ts.GetFor(Environment.Team == null ? 0 : Environment.Team.ID, true),
                CurrentPlayers = currentPlayers };
        }

        protected override void ShowResult(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.ToString());
                return;
            }

            sortableListViewOverview.Items.Clear();
            sortableListViewDetails.Items.Clear();

            ResultData data = (ResultData)e.Result;
            
            foreach (PlayerStatisticItem<MatchAppearance> m in data.Infos.Values)
            {
                string name = (m.Player != null && m.Player.Name != null) ? m.Player.Name : Player.UnknownName; 
                ListViewItem item = new ListViewItem(name);
                item.Tag = m;
                item.SubItems[0].Tag = item.Tag;

                if (m.Player != null && data.CurrentPlayers.FirstOrDefault( p => (p.ID == m.Player.ID) ) != null)
                {
                    item.Font = new Font(item.Font, FontStyle.Bold);
                }

                if (m.Player != null && m.Player.ID == 0)
                {
                    item.BackColor = Color.Gray;
                }

                object value = 0;

                value = m.TotalItems.Count;
                item.SubItems.Add(new ListViewItem.ListViewSubItem(item, value.ToString()) { Tag = value });
                value = m.TotalItems.Sum(ma => ma.Goals.Count);
                item.SubItems.Add(new ListViewItem.ListViewSubItem(item, value.ToString()) { Tag = value });

                value = m.LeagueItems.Count;
                item.SubItems.Add(new ListViewItem.ListViewSubItem(item, value.ToString()) { Tag = value });
                value = m.LeagueItems.Sum(ma => ma.Goals.Count);
                item.SubItems.Add(new ListViewItem.ListViewSubItem(item, value.ToString()) { Tag = value });

                value = m.CupItems.Count;
                item.SubItems.Add(new ListViewItem.ListViewSubItem(item, value.ToString()) { Tag = value });
                value = m.CupItems.Sum(ma => ma.Goals.Count);
                item.SubItems.Add(new ListViewItem.ListViewSubItem(item, value.ToString()) { Tag = value });

                value = m.QualifierItems.Count;
                item.SubItems.Add(new ListViewItem.ListViewSubItem(item, value.ToString()) { Tag = value });
                value = m.QualifierItems.Sum(ma => ma.Goals.Count);
                item.SubItems.Add(new ListViewItem.ListViewSubItem(item, value.ToString()) { Tag = value });

                value = m.FriendlyItems.Count;
                item.SubItems.Add(new ListViewItem.ListViewSubItem(item, value.ToString()) { Tag = value });
                value = m.FriendlyItems.Sum(ma => ma.Goals.Count);
                item.SubItems.Add(new ListViewItem.ListViewSubItem(item, value.ToString()) { Tag = value });

                value = m.OtherItems.Count;
                item.SubItems.Add(new ListViewItem.ListViewSubItem(item, value.ToString()) { Tag = value });
                value = m.OtherItems.Sum(ma => ma.Goals.Count);
                item.SubItems.Add(new ListViewItem.ListViewSubItem(item, value.ToString()) { Tag = value });

                value = m.First;
                item.SubItems.Add(new ListViewItem.ListViewSubItem(item, ((DateTime)value).ToShortDateString()) { Tag = value });

                value = m.Last;
                item.SubItems.Add(new ListViewItem.ListViewSubItem(item, ((DateTime)value).ToShortDateString()) { Tag = value });

                sortableListViewOverview.Items.Add(item);
            }   
        }

        private void copyToClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StringBuilder b = new StringBuilder("[table][tr]");
            foreach (ColumnHeader ch in sortableListViewOverview.Columns)
            {
                b.Append("[td]").Append(ch.Text).Append("[/td]");
            }
            b.Append("[/tr]").AppendLine();

            foreach (ListViewItem lvi in sortableListViewOverview.Items)
            {
                b.Append("[tr]");
                foreach (ListViewItem.ListViewSubItem lvsi in lvi.SubItems)
                {
                    b.Append("[td]").Append(lvsi.Text).Append("[/td]");
                }
                b.Append("[/tr]").AppendLine();
            }

            b.Append("[/table]");

            Clipboard.SetText(b.ToString());
        }
   }
}
