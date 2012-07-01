using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HtHistory.Core.ExtensionMethods;

namespace HtHistory.Dialogs
{
    public partial class TeamIdDialog : Form
    {
        public TeamIdDialog(uint teamId = 0)
        {
            InitializeComponent();
            textBoxTeamId.Text = teamId.ToString();
            dateTimePickerFrom.MaxDate =
            dateTimePickerTo.MaxDate =
            dateTimePickerTo.Value =
            dateTimePickerTo.Value = DateTime.Now.ToHtTime();
            ShowHideDates(radioButtonPeriod.Checked);
        }

        private uint _teamId = 0;

        public uint TeamId
        {
            get
            {
                return _teamId;
            }
        }
 
        public DateTime? StartDate
        {
            get
            {
                if (radioButtonPeriod.Checked)
                {
                    DateTime dt = dateTimePickerFrom.Value;
                    return new DateTime(dt.Year, dt.Month, dt.Day, 0, 0, 0);
                }
                return null;
            }
        }

        public DateTime? EndDate
        {
            get
            {
                if (radioButtonPeriod.Checked)
                {
                    DateTime dt = dateTimePickerTo.Value;
                    DateTime dt2 = new DateTime(dt.Year, dt.Month, dt.Day, 23, 59, 59);
                    if (dt2 > dateTimePickerTo.MaxDate) return dateTimePickerTo.MaxDate;
                    else return dt2;
                }
                return null;
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            try
            {
                _teamId = uint.Parse(textBoxTeamId.Text);
            }
            catch
            {
                MessageBox.Show("Cannot parse value. Defaulting to 0.");
                _teamId = 0;
            }
        }

        private void ShowHideDates(bool show)
        {
            dateTimePickerFrom.Enabled =
            dateTimePickerTo.Enabled = show;
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            ShowHideDates(radioButtonPeriod.Checked);
        }

    }
}
