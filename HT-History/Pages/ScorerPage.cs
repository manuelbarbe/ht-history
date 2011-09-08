using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using HtHistory.Statistics.Scoring;
using HtHistory.Core.DataContainers;
using HtHistory.Core;
using System.Drawing;

namespace HtHistory.Pages
{
    public class ScorerPage : OverviewDetailsPage
    {
        private class ResultData
        {
            public TopScorers.TopScorersInfo Info { get; set; }
            public IEnumerable<Player> CurrentPlayers { get; set; }
        }

        public ScorerPage()
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
                new ColumnHeader() { Text = "Scored", TextAlign = HorizontalAlignment.Center, Width = 50 },
                new ColumnHeader() { Text = "Minute", TextAlign = HorizontalAlignment.Center, Width = 50 }});

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

                TopScorers.ScorerItem sitem = sortableListViewOverview.SelectedItems[0].Tag as TopScorers.ScorerItem;

                if (sitem == null) return;

                foreach (Goal g in sitem.Goals)
                {
                    ListViewItem item = new ListViewItem(g.Match.Date.ToShortDateString());
                    item.Tag = g.Match.Date;
                    item.SubItems[0].Tag = item.Tag;

                    object value = 0;

                    value = new HtTime(g.Match.Date);
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, value.ToString()) { Tag = value });

                    value = g.Match.Type;
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, value.ToString()) { Tag = value });

                    value = g.Match;
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, value.ToString()) { Tag = value });

                    value = g.Score;
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, value.ToString()) { Tag = value });

                    value = g.Minute;
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
            TopScorers ts = new TopScorers(Environment.DataBridgeFactory.TeamDetailsBridge,
                                            Environment.DataBridgeFactory.MatchArchiveBridge,
                                            Environment.DataBridgeFactory.MatchDetailsBridge);

            uint teamId = Environment.Team == null ? 0 : Environment.Team.ID;
            uint opponentId = Environment.Opponent == null ? 0 : Environment.Opponent.ID;

            TopScorers.TopScorersInfo info = ts.GetScorers(teamId, opponentId);

            IEnumerable<Player> currentPlayers = new List<Player>();
            try
            {
                currentPlayers = Environment.DataBridgeFactory.PlayersBridge.GetPlayers(Environment.Team.ID);
            }
            catch (Exception ex)
            {
                HtLog.Warn("Cannot get current players ({0})", ex.ToString());
            }

            e.Result = new ResultData() { Info = info, CurrentPlayers = currentPlayers };
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
            TopScorers.TopScorersInfo info = data.Info;

            foreach (TopScorers.ScorerItem m in info.Scorers)
            {
                ListViewItem item = new ListViewItem(m.Scorer.Name);
                item.Tag = m;
                item.SubItems[0].Tag = item.Tag;

                if (data.CurrentPlayers.FirstOrDefault( p => (p.ID == m.Scorer.ID) ) != null)
                {
                    item.Font = new Font(item.Font, FontStyle.Bold);
                }

                object value = 0;

                value = m.Goals.Count;
                item.SubItems.Add(new ListViewItem.ListViewSubItem(item, value.ToString()) { Tag = value });

                value = m.LeagueGoals.Count;
                item.SubItems.Add(new ListViewItem.ListViewSubItem(item, value.ToString()) { Tag = value });

                value = m.CupGoals.Count;
                item.SubItems.Add(new ListViewItem.ListViewSubItem(item, value.ToString()) { Tag = value });

                value = m.QualifierGoals.Count;
                item.SubItems.Add(new ListViewItem.ListViewSubItem(item, value.ToString()) { Tag = value });

                value = m.FriendlyGoals.Count;
                item.SubItems.Add(new ListViewItem.ListViewSubItem(item, value.ToString()) { Tag = value });

                value = m.OtherGoals.Count;
                item.SubItems.Add(new ListViewItem.ListViewSubItem(item, value.ToString()) { Tag = value });

                value = m.FirstGoal;
                item.SubItems.Add(new ListViewItem.ListViewSubItem(item, ((DateTime)value).ToShortDateString()) { Tag = value });

                value = m.LastGoal;
                item.SubItems.Add(new ListViewItem.ListViewSubItem(item, ((DateTime)value).ToShortDateString()) { Tag = value });

                sortableListViewOverview.Items.Add(item);
            }   
        }
    }
}
