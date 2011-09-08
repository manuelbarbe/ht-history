using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtHistory.Core.DataContainers;
using HtHistory.Statistics;
using System.Windows.Forms;
using HtHistory.Statistics.Appearance;
using HtHistory.Core;
using System.ComponentModel;
using System.Drawing;

namespace HtHistory.Pages
{
    public class AppearancePage : OverviewDetailsPage
    {
        private class ResultData
        {
            public IDictionary<Player, PlayerStatisticItem<TotalMatches.AppearanceInfo> > Infos { get; set; }
            public IEnumerable<Player> CurrentPlayers { get; set; }
        }

        public AppearancePage()
        {
            InitializeComponent();

        }

        private void InitializeComponent()
        {
            this.sortableListViewOverview.Columns.AddRange(new ColumnHeader[] {
                new ColumnHeader() { Text = "Name", TextAlign = HorizontalAlignment.Left, Width = 225 },
                new ColumnHeader() { Text = "Total", TextAlign = HorizontalAlignment.Center, Width = 50 },
                new ColumnHeader() { Text = "League", TextAlign = HorizontalAlignment.Center, Width = 50 },
                new ColumnHeader() { Text = "Cup", TextAlign = HorizontalAlignment.Center, Width = 50 },
                new ColumnHeader() { Text = "Qualifier", TextAlign = HorizontalAlignment.Center, Width = 50 },
                new ColumnHeader() { Text = "Friendly", TextAlign = HorizontalAlignment.Center, Width = 50 },
                new ColumnHeader() { Text = "Other", TextAlign = HorizontalAlignment.Center, Width = 50 },
                new ColumnHeader() { Text = "First", TextAlign = HorizontalAlignment.Left, Width = 80 },
                new ColumnHeader() { Text = "Last", TextAlign = HorizontalAlignment.Left, Width = 80 } });

            sortableListViewOverview.SetSorter(1, UserControls.SortableListView.TagSorter<int>());
            sortableListViewOverview.SetSorter(2, UserControls.SortableListView.TagSorter<int>());
            sortableListViewOverview.SetSorter(3, UserControls.SortableListView.TagSorter<int>());
            sortableListViewOverview.SetSorter(4, UserControls.SortableListView.TagSorter<int>());
            sortableListViewOverview.SetSorter(5, UserControls.SortableListView.TagSorter<int>());
            sortableListViewOverview.SetSorter(6, UserControls.SortableListView.TagSorter<int>());
            sortableListViewOverview.SetSorter(7, UserControls.SortableListView.TagSorter<DateTime>());
            sortableListViewOverview.SetSorter(8, UserControls.SortableListView.TagSorter<DateTime>());

            this.sortableListViewOverview.SelectedIndexChanged += OverviewSelectedIndexChanged;


            this.sortableListViewDetails.Columns.AddRange(new ColumnHeader[] {
                new ColumnHeader() { Text = "Date", TextAlign = HorizontalAlignment.Left, Width = 80 },
                new ColumnHeader() { Text = "Week", TextAlign = HorizontalAlignment.Left, Width = 50 },
                new ColumnHeader() { Text = "Type", TextAlign = HorizontalAlignment.Left, Width = 150 },  
                new ColumnHeader() { Text = "Match", TextAlign = HorizontalAlignment.Left, Width = 220 },
                new ColumnHeader() { Text = "Position", TextAlign = HorizontalAlignment.Left, Width = 50 },
                new ColumnHeader() { Text = "Minutes", TextAlign = HorizontalAlignment.Center, Width = 50 }});

            sortableListViewDetails.SetSorter(0, UserControls.SortableListView.TagSorter<DateTime>());
            sortableListViewDetails.SetSorter(1, UserControls.SortableListView.NullSorter);
            sortableListViewDetails.SetSorter(5, UserControls.SortableListView.TagSorter<int>());            
        }

        public void OverviewSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                sortableListViewDetails.Items.Clear();

                if (sortableListViewOverview.SelectedItems.Count == 0) return;

                PlayerStatisticItem<TotalMatches.AppearanceInfo> sitem = sortableListViewOverview.SelectedItems[0].Tag as PlayerStatisticItem<TotalMatches.AppearanceInfo>;

                if (sitem == null) return;

                foreach (TotalMatches.AppearanceInfo d in sitem.TotalItems)
                {
                    ListViewItem item = new ListViewItem(d.Match.Date.ToShortDateString());
                    item.Tag = d.Match.Date;
                    item.SubItems[0].Tag = item.Tag;

                    object value = 0;

                    value = new HtTime(d.Match.Date);
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, value.ToString()) { Tag = value });

                    value = d.Match.Type;
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, value.ToString()) { Tag = value });

                    value = d.Match;
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, value.ToString()) { Tag = value });

                    value = d.Role;
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, value.ToString()) { Tag = value });

                    value = -1;
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, value.ToString()) { Tag = value });
                    
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
            TotalMatches ts = new TotalMatches(
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
                Infos = ts.GetTotalMatches(Environment.Team == null ? 0 : Environment.Team.ID, true),
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
            
            foreach (PlayerStatisticItem<TotalMatches.AppearanceInfo> m in data.Infos.Values)
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

                value = m.LeagueItems.Count;
                item.SubItems.Add(new ListViewItem.ListViewSubItem(item, value.ToString()) { Tag = value });

                value = m.CupItems.Count;
                item.SubItems.Add(new ListViewItem.ListViewSubItem(item, value.ToString()) { Tag = value });

                value = m.QualifierItems.Count;
                item.SubItems.Add(new ListViewItem.ListViewSubItem(item, value.ToString()) { Tag = value });

                value = m.FriendlyItems.Count;
                item.SubItems.Add(new ListViewItem.ListViewSubItem(item, value.ToString()) { Tag = value });

                value = m.OtherItems.Count;
                item.SubItems.Add(new ListViewItem.ListViewSubItem(item, value.ToString()) { Tag = value });

                value = m.First;
                item.SubItems.Add(new ListViewItem.ListViewSubItem(item, ((DateTime)value).ToShortDateString()) { Tag = value });

                value = m.Last;
                item.SubItems.Add(new ListViewItem.ListViewSubItem(item, ((DateTime)value).ToShortDateString()) { Tag = value });

                sortableListViewOverview.Items.Add(item);
            }   
        }
    }
}
