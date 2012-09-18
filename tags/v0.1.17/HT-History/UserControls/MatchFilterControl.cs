using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HtHistory.Statistics.Filters.Matches;
using System.Collections;
using HtHistory.Core.DataContainers;

namespace HtHistory.UserControls
{
    public partial class MatchFilterControl : UserControl
    {
        public MatchFilterControl()
        {
            InitializeComponent();
        }

        #region PREPARE LAYOUT

        private void InitializeSeasons(int seasonFrom, int seasonTo)
        {
            listBoxSeason.SuspendLayout();
            listBoxSeason.Items.Clear();
            listBoxSeason.Items.Add(new TaggedObject("All seasons", new MatchFilterNull()));
            for (int i = seasonFrom; i <= seasonTo; ++i)
            {
                listBoxSeason.Items.Add(new TaggedObject(String.Format("Season {0}", i), new MatchFilterSeason(i)));
            }
            listBoxSeason.SelectedIndex = 0;
            listBoxSeason.ResumeLayout();
        }

        private void InitializeVenue(uint teamId)
        {
            listBoxVenue.SuspendLayout();
            listBoxVenue.Items.Clear();
            listBoxVenue.Items.Add(new TaggedObject("All", new MatchFilterNull()));
            listBoxVenue.Items.Add(new TaggedObject("Home", new MatchFilterHome(teamId)));
            listBoxVenue.Items.Add(new TaggedObject("Away", new MatchFilterAway(teamId)));
            //listBoxVenue.Items.Add(new TaggedObject("Neutral", new MatchFilterNeutral()));
            listBoxVenue.SelectedIndex = 0;
            listBoxVenue.ResumeLayout();
        }

        private void InitializeType()
        {
            listBoxType.SuspendLayout();
            listBoxType.Items.Clear();
            listBoxType.Items.Add(new TaggedObject("All", new MatchFilterNull()));
            listBoxType.Items.Add(new TaggedObject("Competitive", new MatchFilterCompetitive()));
            listBoxType.Items.Add(new TaggedObject("League", new MatchFilterLeague()));
            listBoxType.Items.Add(new TaggedObject("Cup", new MatchFilterCup()));
            listBoxType.Items.Add(new TaggedObject("Qualifier", new MatchFilterQualifier()));
            listBoxType.Items.Add(new TaggedObject("Masters / Other", new MatchFilterMastersOther()));
            listBoxType.Items.Add(new TaggedObject("Friendly", new MatchFilterFriendly()));
            listBoxType.SelectedIndex = 0;
            listBoxType.ResumeLayout();
        }

        public void Prepare(uint teamId, DateTime from, DateTime to)
        {
            textBoxTeamId.Text = teamId.ToString();
            InitializeVenue(teamId);
            InitializeSeasons(new HtTime(from).Season, new HtTime(to).Season);
            InitializeType();

            listBoxSeason.Enabled = true;
            listBoxType.Enabled = true;
            listBoxVenue.Enabled = true;
            textBoxOpponentId.Enabled = true;
            checkBoxForfait.Enabled = true;
        }

        #endregion

        #region BUILD FILTER

        private IMatchFilter GetFilterFromTaggedObjects(IEnumerable objects)
        {
            IList<IMatchFilter> filters = new List<IMatchFilter>();
            if (objects != null)
            {
                foreach (var v in objects)
                {
                    TaggedObject to = v as TaggedObject;
                    if (to != null)
                    {
                        IMatchFilter filter = to.Tag as IMatchFilter;
                        if (filter != null)
                        {
                            filters.Add(filter);
                        }
                    }
                }
            }

            return new MatchFilterUnionSet(filters);
        }

        public IMatchFilter GetFilter()
        {
            IList<IMatchFilter> intersectionFilters = new List<IMatchFilter>();

            uint opponentId;
            if (uint.TryParse(textBoxOpponentId.Text, out opponentId))
            {
                intersectionFilters.Add(new MatchFilterTeam(opponentId));
            }

            intersectionFilters.Add(GetFilterFromTaggedObjects(listBoxVenue.SelectedItems));
            intersectionFilters.Add(GetFilterFromTaggedObjects(listBoxType.SelectedItems));
            intersectionFilters.Add(GetFilterFromTaggedObjects(listBoxSeason.SelectedItems));

            if (checkBoxForfait.Checked) intersectionFilters.Add(new MatchFilterNoForfaits());

            return new MatchFilterIntersectionSet(intersectionFilters);
        }

        #endregion

        #region FILTER CHANGED EVENTS

        public event EventHandler FilterChanged;

        private void RaiseFilterChanged(object sender, EventArgs e)
        {
            if (FilterChanged != null)
            {
                FilterChanged(this, new EventArgs());
            }
        }

        #endregion

    }
}
