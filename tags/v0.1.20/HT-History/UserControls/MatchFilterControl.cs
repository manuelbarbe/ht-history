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
using HtHistory.Translation;

namespace HtHistory.UserControls
{
    public partial class MatchFilterControl : UserControl
    {
        public MatchFilterControl()
        {
            InitializeComponent();
        }

        #region PREPARE LAYOUT

        private void InitializeSeasons(int seasonFrom, int seasonTo, ITranslator translator)
        {
            listBoxSeason.SuspendLayout();
            listBoxSeason.Items.Clear();
            listBoxSeason.Items.Add(new TaggedObject(translator.Translate("itemSeasonAll"), new MatchFilterNull()));
            for (int i = seasonFrom; i <= seasonTo; ++i)
            {
                listBoxSeason.Items.Add(new TaggedObject(String.Format(translator.Translate("itemSeason"), i), new MatchFilterSeason(i)));
            }
            listBoxSeason.SelectedIndex = 0;
            listBoxSeason.ResumeLayout();
        }

        private void InitializeVenue(uint teamId, ITranslator translator)
        {
            listBoxVenue.SuspendLayout();
            listBoxVenue.Items.Clear();
            listBoxVenue.Items.Add(new TaggedObject(translator.Translate("itemVenueAll"), new MatchFilterNull()));
            listBoxVenue.Items.Add(new TaggedObject(translator.Translate("itemVenueHome"), new MatchFilterHome(teamId)));
            listBoxVenue.Items.Add(new TaggedObject(translator.Translate("itemVenueAway"), new MatchFilterAway(teamId)));
            //listBoxVenue.Items.Add(new TaggedObject("Neutral", new MatchFilterNeutral()));
            listBoxVenue.SelectedIndex = 0;
            listBoxVenue.ResumeLayout();
        }

        private void InitializeType(ITranslator translator)
        {
            listBoxType.SuspendLayout();
            listBoxType.Items.Clear();
            listBoxType.Items.Add(new TaggedObject(translator.Translate("itemMatchTypeAll"), new MatchFilterNull()));
            listBoxType.Items.Add(new TaggedObject(translator.Translate("itemMatchTypeCompetitive"), new MatchFilterCompetitive()));
            listBoxType.Items.Add(new TaggedObject(translator.Translate("itemMatchTypeLeague"), new MatchFilterLeague()));
            listBoxType.Items.Add(new TaggedObject(translator.Translate("itemMatchTypeCup"), new MatchFilterCup()));
            listBoxType.Items.Add(new TaggedObject(translator.Translate("itemMatchTypeQualifier"), new MatchFilterQualifier()));
            listBoxType.Items.Add(new TaggedObject(translator.Translate("itemMatchTypeOther"), new MatchFilterMastersOther()));
            listBoxType.Items.Add(new TaggedObject(translator.Translate("itemMatchTypeFriendly"), new MatchFilterFriendly()));
            listBoxType.SelectedIndex = 0;
            listBoxType.ResumeLayout();
        }

        public void Prepare(uint teamId, DateTime from, DateTime to, ITranslator translator)
        {
            noTr_textBoxTeamId.Text = teamId.ToString();
            InitializeVenue(teamId, translator);
            InitializeSeasons(new HtTime(from).Season, new HtTime(to).Season, translator);
            InitializeType(translator);

            listBoxSeason.Enabled = true;
            listBoxType.Enabled = true;
            listBoxVenue.Enabled = true;
            noTr_textBoxOpponentId.Enabled = true;
            checkBoxForfaitsExcluded.Enabled = true;
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
            if (uint.TryParse(noTr_textBoxOpponentId.Text, out opponentId))
            {
                intersectionFilters.Add(new MatchFilterTeam(opponentId));
            }

            intersectionFilters.Add(GetFilterFromTaggedObjects(listBoxVenue.SelectedItems));
            intersectionFilters.Add(GetFilterFromTaggedObjects(listBoxType.SelectedItems));
            intersectionFilters.Add(GetFilterFromTaggedObjects(listBoxSeason.SelectedItems));

            if (checkBoxForfaitsExcluded.Checked) intersectionFilters.Add(new MatchFilterNoForfaits());

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
