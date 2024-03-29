﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtHistory.Data.Types;
using HtHistory.Statistics;
using HtHistory.Statistics.Players;
using System.Windows.Forms;
using System.ComponentModel;
using HtHistory.Core;
using System.Drawing;
using HtHistory.Toolbox;
using HtHistory.Export;
using System.IO;
using System.Collections;
using HtHistory.UserControls;
using System.Globalization;
using HtHistory.Tasks;


namespace HtHistory.Pages
{
    public class OverviewPage : OverviewDetailsPage
    {

        public class ResultData
        {
            public int TeamId { get; set; }
            public IDictionary<Player, IList<MatchAppearance>> Infos { get; set; }
            public IEnumerable<Player> CurrentPlayers { get; set; }
            public IEnumerable<MatchDetails> Matches { get; set; }
        }

        public OverviewPage()
        {
            InitializeComponent();
        }

        private IEnumerable<IPlayerStatisticCalculator<IEnumerable<MatchAppearance>>> _stats;

        private void InitializeComponent()
        {
            //_stats = CalculatorFactory.GetAllCalulators();

            InitializeTabs();
            InitializeOverviewList();
            AttachEventHandlerToOverviewList();
            InitializeSeasonsList();
            InitializeMatchList();
            InitializeGoalsList();
        }

        public IEnumerable<IPlayerStatisticCalculator<IEnumerable<MatchAppearance>>> Stats
        {
            get { return _stats; }
            set
            {
                _stats = value;
                InitializeOverviewList();
                InitializeSeasonsList();
                FillListView(sortableListViewOverview.Tag as ResultData, sortableListViewOverview);
                FillDetailsSeason();
                FillDetailsMatches();
                FillDetailsGoals();
            }
        }

        private void InitializeOverviewList()
        {
            RemoveColumnsAndItems(sortableListViewOverview);
            AddConfiguredColumns(sortableListViewOverview);
        }

        private void InitializeGoalsList()
        {
            this.sortableListViewDetails3.Columns.AddRange(new ColumnHeader[] {
                new ColumnHeader() { Name="columnHeaderPlayerGoalDate", Text = "Date", TextAlign = HorizontalAlignment.Left, Width = 80 },
                new ColumnHeader() { Name="columnHeaderPlayerGoalWeek", Text = "Week", TextAlign = HorizontalAlignment.Left, Width = 50 },
                new ColumnHeader() { Name="columnHeaderPlayerGoalType", Text = "Type", TextAlign = HorizontalAlignment.Left, Width = 150 },  
                new ColumnHeader() { Name="columnHeaderPlayerGoalMatch", Text = "Match", TextAlign = HorizontalAlignment.Left, Width = 220 },
                new ColumnHeader() { Name="columnHeaderPlayerGoalScored", Text = "Scored", TextAlign = HorizontalAlignment.Center, Width = 50 },
                new ColumnHeader() { Name="columnHeaderPlayerGoalMinute", Text = "Minute", TextAlign = HorizontalAlignment.Center, Width = 50 }});

            sortableListViewDetails3
                .SetSorter(0, UserControls.SortableListView.TagSorter<DateTime>())
                .SetSorter(1, UserControls.SortableListView.NullSorter)
                .SetSorter(5, UserControls.SortableListView.TagSorter<uint>());
        }

        private void InitializeMatchList()
        {
            this.sortableListViewDetails2.Columns.AddRange(new ColumnHeader[] {
                new ColumnHeader() { Name = "columnHeaderPlayerMatchDate", Text = "Date", TextAlign = HorizontalAlignment.Left, Width = 80 },
                new ColumnHeader() { Name = "columnHeaderPlayerMatchWeek", Text = "Week", TextAlign = HorizontalAlignment.Left, Width = 50 },
                new ColumnHeader() { Name = "columnHeaderPlayerMatchType", Text = "Type", TextAlign = HorizontalAlignment.Left, Width = 150 },  
                new ColumnHeader() { Name = "columnHeaderPlayerMatchMatch", Text = "Match", TextAlign = HorizontalAlignment.Left, Width = 220 },
                new ColumnHeader() { Name = "columnHeaderPlayerMatchPosition", Text = "Position", TextAlign = HorizontalAlignment.Left, Width = 50 },
                new ColumnHeader() { Name = "columnHeaderPlayerMatchMinutes", Text = "Minutes", TextAlign = HorizontalAlignment.Center, Width = 50 },
                new ColumnHeader() { Name = "columnHeaderPlayerMatchGoals", Text = "Goals", TextAlign = HorizontalAlignment.Center, Width = 50 },
                new ColumnHeader() { Name = "columnHeaderPlayerMatchIn", Text = "In", TextAlign = HorizontalAlignment.Center, Width = 50 },
                new ColumnHeader() { Name = "columnHeaderPlayerMatchOut", Text = "Out", TextAlign = HorizontalAlignment.Center, Width = 50 },
                new ColumnHeader() { Name = "columnHeaderPlayerMatchYellowCard", Text = "YellowCard", TextAlign = HorizontalAlignment.Center, Width = 60 },
                new ColumnHeader() { Name = "columnHeaderPlayerMatchRedCard", Text = "RedCard", TextAlign = HorizontalAlignment.Center, Width = 60 },
                new ColumnHeader() { Name = "columnHeaderPlayerMatchBruised", Text = "Bruised", TextAlign = HorizontalAlignment.Center, Width = 60 },
                new ColumnHeader() { Name = "columnHeaderPlayerMatchInjured", Text = "Injured", TextAlign = HorizontalAlignment.Center, Width = 60 },
                new ColumnHeader() { Name = "columnHeaderPlayerMatchMotM", Text = "MotM", TextAlign = HorizontalAlignment.Center, Width = 60 },
                new ColumnHeader() { Name = "columnHeaderPlayerMatchStars", Text = "Stars", TextAlign = HorizontalAlignment.Center, Width = 60 },
            });

            sortableListViewDetails2
                .SetSorter(0, UserControls.SortableListView.TagSorter<DateTime>())
                .SetSorter(1, UserControls.SortableListView.NullSorter)
                .SetSorter(5, UserControls.SortableListView.TagSorter<uint>())
                .SetSorter(6, UserControls.SortableListView.TagSorter<int>())
                .SetSorter(7, UserControls.SortableListView.TagSorter<uint>())
                .SetSorter(8, UserControls.SortableListView.TagSorter<uint>())
                .SetSorter(9, UserControls.SortableListView.TagSorter<uint>())
                .SetSorter(10, UserControls.SortableListView.TagSorter<uint>())
                .SetSorter(11, UserControls.SortableListView.TagSorter<uint>())
                .SetSorter(12, UserControls.SortableListView.TagSorter<uint>())
                .SetSorter(14, UserControls.SortableListView.TagSorter<double>());
        }

        private void InitializeSeasonsList()
        {
            RemoveColumnsAndItems(sortableListViewDetails1);
            sortableListViewDetails1.Columns.Add(new ColumnHeader() { Text = "Season", TextAlign = HorizontalAlignment.Left, Width = 80 });
            AddConfiguredColumns(sortableListViewDetails1);
        }

        private static void RemoveColumnsAndItems(SortableListView listView)
        {
            for (int i = 0; i < listView.Columns.Count; ++i)
            {
                listView.SetSorter(i, null);
            }

            listView.Items.Clear();
            listView.Columns.Clear();
        }

        private void AddConfiguredColumns(SortableListView listview)
        {
            bool first = true;
            foreach (var s in _stats.SafeEnum())
            {
                var ch = new ColumnHeader() {
                    Name = string.Format("playerStatShort_{0}", s.Identifier),
                    Text = s.Abbreviation,
                    TextAlign = HorizontalAlignment.Left,
                    Width = first ? 150 : 60,
                    Tag = s };
                listview.Columns.Add(ch);
                listview.SetSorter(ch.Index, SortableListView.TagSorter(s.GetComparer()));
                first = false;
            }
        }

        private void AttachEventHandlerToOverviewList()
        {
            this.sortableListViewOverview.SelectedIndexChanged += OverviewSelectedIndexChanged;
        }

        private void InitializeTabs()
        {
            tabPagePlayerSeasons.Text = "Seasons";
            tabPagePlayerMatches.Text = "Matches";
            tabPagePlayerGoals.Text = "Goals";
        }

        
        public void OverviewSelectedIndexChanged(object sender, EventArgs e)
        {
            FillDetailsSeason();
            FillDetailsMatches();
            FillDetailsGoals();
        }

        private void FillDetailsGoals()
        {
            try
            {
                sortableListViewDetails3.Items.Clear();

                sortableListViewDetails3.SuspendLayout();

                if (sortableListViewOverview.SelectedItems.Count == 0) return;
                KeyValuePair<Player, IList<MatchAppearance>> sitem;

                if (sortableListViewOverview.SelectedItems[0].Tag is KeyValuePair<Player, IList<MatchAppearance>>)
                {
                    sitem = (KeyValuePair<Player, IList<MatchAppearance>>)sortableListViewOverview.SelectedItems[0].Tag;
                }
                else return;

                foreach (var v in sitem.Value.SafeEnum())
                {
                    foreach (Goal g in v.Goals.SafeEnum())
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

                        sortableListViewDetails3.Items.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                sortableListViewDetails3.ResumeLayout();
            }
        }

        private void FillDetailsMatches()
        {
            try
            {
                sortableListViewDetails2.Items.Clear();

                sortableListViewDetails2.SuspendLayout();

                if (sortableListViewOverview.SelectedItems.Count == 0) return;

                KeyValuePair<Player, IList<MatchAppearance>> sitem;

                if (sortableListViewOverview.SelectedItems[0].Tag is KeyValuePair<Player, IList<MatchAppearance>>)
                {
                    sitem = (KeyValuePair<Player, IList<MatchAppearance>>)sortableListViewOverview.SelectedItems[0].Tag;
                }
                else return;

                foreach (MatchAppearance d in sitem.Value.SafeEnum())
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

                    value = d.Minutes;
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, value.ToString()) { Tag = value });

                    value = d.Goals.Count;
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, value.ToString()) { Tag = value });

                    value = d.SubstituteIn;
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, (value != null) ? value.ToString() : "-" ) { Tag = value });

                    value = d.SubstituteOut;
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, (value != null) ? value.ToString() : "-") { Tag = value });

                    value = d.YellowCarded;
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, (value != null) ? value.ToString() : "-") { Tag = value });

                    value = d.RedCarded;
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, (value != null) ? value.ToString() : "-") { Tag = value });

                    value = d.Bruised;
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, (value != null) ? value.ToString() : "-") { Tag = value });

                    value = d.Injured;
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, (value != null) ? value.ToString() : "-") { Tag = value });

                    value = d.BestPlayer;
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, ((bool)value == true) ? "yes" : "-") { Tag = value });

                    value = d.RatingStars;
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, (value != null) ? value.ToString() : "-") { Tag = value });

                    sortableListViewDetails2.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                sortableListViewDetails2.ResumeLayout();
            }
        }

        private void FillDetailsSeason()
        {
            try
            {
                sortableListViewDetails1.Items.Clear();

                if (sortableListViewOverview.SelectedItems.Count == 0) return;
                
                KeyValuePair<Player, IList<MatchAppearance>> sitem;

                if (sortableListViewOverview.SelectedItems[0].Tag is KeyValuePair<Player, IList<MatchAppearance>>)
                {
                    sitem = (KeyValuePair<Player, IList<MatchAppearance>>)sortableListViewOverview.SelectedItems[0].Tag;
                }
                else return;

                IDictionary<int, IEnumerable<MatchAppearance>> appearancesBySeason = sitem.Value.Split(m => new HtTime(m.Match.Date).Season);
               
                foreach (var v in appearancesBySeason)
                {
                    var m = v.Value;

                    ListViewItem item = new ListViewItem(string.Format("Season {0,02}", v.Key));
                    item.Tag = m;
                    item.SubItems[0].Tag = item.Tag;

                    bool firstCol = true;
                    foreach (ColumnHeader ch in sortableListViewDetails1.Columns)
                    {
                        IPlayerStatisticCalculator<IEnumerable<MatchAppearance>> psc = ch.Tag as IPlayerStatisticCalculator<IEnumerable<MatchAppearance>>;
                        object value = (psc == null) ? "(invalid)" : psc.Calculate(v.Value);
                        IPrinter fp = (psc == null) ? new ToStringPrinter<object>() : psc.GetPrinter();
                        //if (value == null) value = "-";

                        if (firstCol)
                        {
                            firstCol = false;
                            continue; //skip
                        }
                        else
                        {
                            item.SubItems.Add(new ListViewItem.ListViewSubItem(item, fp.Print(value)) { Tag = value });
                        }
                    }
                    
                    sortableListViewDetails1.Items.Add(item);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        IDictionary<Player, IList<MatchAppearance>> GetForMatches(int teamId, IEnumerable<MatchDetails> matches)
        {
            StandardPlayerStatistics ts = new StandardPlayerStatistics(matches);
            return ts.GetMatchesOfPlayers(teamId, true);
        }

        public void ShowResult(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.ToString());
                return;
            }

            sortableListViewDetails1.Items.Clear();
            sortableListViewDetails2.Items.Clear();
            sortableListViewDetails3.Items.Clear();

            FillListView((ResultData)e.Result, sortableListViewOverview);  
        }

        private void FillListView(ResultData data, ListView listView)
        {
            if (data == null || listView == null) return;

            if (data.Infos == null) data.Infos = GetForMatches(data.TeamId, data.Matches);

            listView.Tag = data;
            listView.Items.Clear();

            foreach (var pmd in data.Infos.SafeEnum())
            {
                Player player = pmd.Key;
                if (player == null) continue;

                ListViewItem item = new ListViewItem("(invalid)") { Tag = pmd };
                item.ToolTipText = pmd.Key.ToString();

                // highlight current players
                if (data.CurrentPlayers != null &&
                    data.CurrentPlayers.FirstOrDefault(p => (p.ID == player.ID)) != null)
                {
                    item.Font = new Font(item.Font, FontStyle.Bold);
                }

                // team dummy player
                if (player.ID == 0)
                {
                    item.BackColor = Color.Gray;
                }

                bool firstCol = true;
                foreach (ColumnHeader ch in listView.Columns)
                {
                    IPlayerStatisticCalculator<IEnumerable<MatchAppearance>> psc = ch.Tag as IPlayerStatisticCalculator<IEnumerable<MatchAppearance>>;
                    object value = (psc == null) ? "(invalid)" : psc.Calculate(pmd.Value);
                    IPrinter fp = (psc == null) ? new ToStringPrinter<object>() : psc.GetPrinter();
                    //if (value == null) value = "-";

                    if (firstCol)
                    {
                        item.Text = fp.Print(value);
                        item.SubItems[0].Tag = value;
                        firstCol = false;
                    }
                    else
                    {
                        item.SubItems.Add(new ListViewItem.ListViewSubItem(item, fp.Print(value)) { Tag = value });
                    }
                }

                listView.Items.Add(item);
            }
        }


   }
}
