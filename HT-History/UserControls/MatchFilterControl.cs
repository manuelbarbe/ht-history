using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HtHistory.Statistics.Filters.Matches;

namespace HtHistory.UserControls
{
    public partial class MatchFilterControl : UserControl
    {
        public MatchFilterControl()
        {
            InitializeComponent();
        }

        public uint TeamId
        {
            get
            {
                try
                {
                    return uint.Parse(textBoxTeamId.Text);
                }
                catch
                {
                    return 0;
                }
            }
            set
            {
                textBoxTeamId.Text = value.ToString();
            }
        }

        public IMatchFilter Filter
        {
            get
            {
                return new MatchFilterNull();
            }
        }

    }
}
