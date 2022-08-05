using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HtHistory.Toolbox;

namespace HtHistory.Dialogs
{
    public partial class TeamIdDialog : Form
    {
        public TeamIdDialog(int teamId = 0)
        {
            InitializeComponent();
            noTr_textBoxTeamId.Text = teamId.ToString();
            noTr_dateTimePickerFrom.MaxDate =
            noTr_dateTimePickerTo.MaxDate =
            noTr_dateTimePickerTo.Value =
            noTr_dateTimePickerTo.Value = DateTime.Now.ToHtTime();
            ShowHideDates(radioButtonPeriod.Checked);
        }

        private int _teamId = 0;

        public int TeamId
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
                    DateTime dt = noTr_dateTimePickerFrom.Value;
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
                    DateTime dt = noTr_dateTimePickerTo.Value;
                    DateTime dt2 = new DateTime(dt.Year, dt.Month, dt.Day, 23, 59, 59);
                    if (dt2 > noTr_dateTimePickerTo.MaxDate) return noTr_dateTimePickerTo.MaxDate;
                    else return dt2;
                }
                return null;
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (radioButtonPeriod.Checked && StartDate > EndDate)
            {
                MessageBox.Show("Typically the start date is not after the end date. Please try again.");
                DialogResult = DialogResult.None;
                return;
            }

            try
            {
                _teamId = int.Parse(noTr_textBoxTeamId.Text);
            }
            catch
            {
                MessageBox.Show("Cannot parse value. Defaulting to 0.");
                _teamId = 0;
            }
        }

        private void ShowHideDates(bool show)
        {
            noTr_dateTimePickerFrom.Enabled =
            noTr_dateTimePickerTo.Enabled = show;
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            ShowHideDates(radioButtonPeriod.Checked);
        }

        private void TeamIdDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.None) e.Cancel = true;
        }

    }
}
