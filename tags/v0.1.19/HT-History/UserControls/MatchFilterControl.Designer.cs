namespace HtHistory.UserControls
{
    partial class MatchFilterControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelTeamId = new System.Windows.Forms.Label();
            this.labelOppId = new System.Windows.Forms.Label();
            this.noTr_textBoxTeamId = new System.Windows.Forms.TextBox();
            this.noTr_textBoxOpponentId = new System.Windows.Forms.TextBox();
            this.labelVenue = new System.Windows.Forms.Label();
            this.listBoxVenue = new System.Windows.Forms.ListBox();
            this.labelSeason = new System.Windows.Forms.Label();
            this.listBoxSeason = new System.Windows.Forms.ListBox();
            this.labelForfaits = new System.Windows.Forms.Label();
            this.checkBoxForfaitsExcluded = new System.Windows.Forms.CheckBox();
            this.labelMatchType = new System.Windows.Forms.Label();
            this.listBoxType = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // labelTeamId
            // 
            this.labelTeamId.AutoSize = true;
            this.labelTeamId.Location = new System.Drawing.Point(3, 10);
            this.labelTeamId.Name = "labelTeamId";
            this.labelTeamId.Size = new System.Drawing.Size(51, 13);
            this.labelTeamId.TabIndex = 0;
            this.labelTeamId.Text = "Team ID:\r\n";
            // 
            // labelOppId
            // 
            this.labelOppId.AutoSize = true;
            this.labelOppId.Location = new System.Drawing.Point(3, 45);
            this.labelOppId.Name = "labelOppId";
            this.labelOppId.Size = new System.Drawing.Size(71, 26);
            this.labelOppId.TabIndex = 1;
            this.labelOppId.Text = "Opponent ID:\r\n( 0 = all )";
            // 
            // noTr_textBoxTeamId
            // 
            this.noTr_textBoxTeamId.Enabled = false;
            this.noTr_textBoxTeamId.Location = new System.Drawing.Point(80, 7);
            this.noTr_textBoxTeamId.Name = "noTr_textBoxTeamId";
            this.noTr_textBoxTeamId.Size = new System.Drawing.Size(104, 20);
            this.noTr_textBoxTeamId.TabIndex = 2;
            this.noTr_textBoxTeamId.Text = "0";
            // 
            // noTr_textBoxOpponentId
            // 
            this.noTr_textBoxOpponentId.Enabled = false;
            this.noTr_textBoxOpponentId.Location = new System.Drawing.Point(80, 51);
            this.noTr_textBoxOpponentId.Name = "noTr_textBoxOpponentId";
            this.noTr_textBoxOpponentId.Size = new System.Drawing.Size(104, 20);
            this.noTr_textBoxOpponentId.TabIndex = 2;
            this.noTr_textBoxOpponentId.Text = "0";
            this.noTr_textBoxOpponentId.TextChanged += new System.EventHandler(this.RaiseFilterChanged);
            // 
            // labelVenue
            // 
            this.labelVenue.AutoSize = true;
            this.labelVenue.Location = new System.Drawing.Point(369, 10);
            this.labelVenue.Name = "labelVenue";
            this.labelVenue.Size = new System.Drawing.Size(41, 13);
            this.labelVenue.TabIndex = 3;
            this.labelVenue.Text = "Venue:";
            // 
            // listBoxVenue
            // 
            this.listBoxVenue.BackColor = System.Drawing.Color.White;
            this.listBoxVenue.Enabled = false;
            this.listBoxVenue.ForeColor = System.Drawing.Color.Black;
            this.listBoxVenue.FormattingEnabled = true;
            this.listBoxVenue.Items.AddRange(new object[] {
            "All",
            "Home",
            "Away",
            "Neutral"});
            this.listBoxVenue.Location = new System.Drawing.Point(372, 26);
            this.listBoxVenue.Name = "listBoxVenue";
            this.listBoxVenue.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxVenue.Size = new System.Drawing.Size(120, 56);
            this.listBoxVenue.TabIndex = 4;
            this.listBoxVenue.SelectedIndexChanged += new System.EventHandler(this.RaiseFilterChanged);
            // 
            // labelSeason
            // 
            this.labelSeason.AutoSize = true;
            this.labelSeason.Location = new System.Drawing.Point(532, 10);
            this.labelSeason.Name = "labelSeason";
            this.labelSeason.Size = new System.Drawing.Size(46, 13);
            this.labelSeason.TabIndex = 5;
            this.labelSeason.Text = "Season:";
            // 
            // listBoxSeason
            // 
            this.listBoxSeason.BackColor = System.Drawing.Color.White;
            this.listBoxSeason.Enabled = false;
            this.listBoxSeason.ForeColor = System.Drawing.Color.Black;
            this.listBoxSeason.FormattingEnabled = true;
            this.listBoxSeason.Location = new System.Drawing.Point(535, 26);
            this.listBoxSeason.Name = "listBoxSeason";
            this.listBoxSeason.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxSeason.Size = new System.Drawing.Size(144, 95);
            this.listBoxSeason.TabIndex = 6;
            this.listBoxSeason.SelectedIndexChanged += new System.EventHandler(this.RaiseFilterChanged);
            // 
            // labelForfaits
            // 
            this.labelForfaits.AutoSize = true;
            this.labelForfaits.Location = new System.Drawing.Point(369, 89);
            this.labelForfaits.Name = "labelForfaits";
            this.labelForfaits.Size = new System.Drawing.Size(44, 13);
            this.labelForfaits.TabIndex = 7;
            this.labelForfaits.Text = "Forfaits:";
            // 
            // checkBoxForfaitsExcluded
            // 
            this.checkBoxForfaitsExcluded.AutoSize = true;
            this.checkBoxForfaitsExcluded.Enabled = false;
            this.checkBoxForfaitsExcluded.Location = new System.Drawing.Point(372, 104);
            this.checkBoxForfaitsExcluded.Name = "checkBoxForfaitsExcluded";
            this.checkBoxForfaitsExcluded.Size = new System.Drawing.Size(69, 17);
            this.checkBoxForfaitsExcluded.TabIndex = 8;
            this.checkBoxForfaitsExcluded.Text = "excluded";
            this.checkBoxForfaitsExcluded.UseVisualStyleBackColor = true;
            this.checkBoxForfaitsExcluded.CheckedChanged += new System.EventHandler(this.RaiseFilterChanged);
            // 
            // labelMatchType
            // 
            this.labelMatchType.AutoSize = true;
            this.labelMatchType.Location = new System.Drawing.Point(202, 10);
            this.labelMatchType.Name = "labelMatchType";
            this.labelMatchType.Size = new System.Drawing.Size(34, 13);
            this.labelMatchType.TabIndex = 9;
            this.labelMatchType.Text = "Type:";
            // 
            // listBoxType
            // 
            this.listBoxType.BackColor = System.Drawing.Color.White;
            this.listBoxType.Enabled = false;
            this.listBoxType.ForeColor = System.Drawing.Color.Black;
            this.listBoxType.FormattingEnabled = true;
            this.listBoxType.Items.AddRange(new object[] {
            "All",
            "Competitive",
            "League",
            "Cup",
            "Qualifier",
            "Masters / Other",
            "Friendly"});
            this.listBoxType.Location = new System.Drawing.Point(205, 26);
            this.listBoxType.Name = "listBoxType";
            this.listBoxType.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxType.Size = new System.Drawing.Size(120, 95);
            this.listBoxType.TabIndex = 10;
            this.listBoxType.SelectedIndexChanged += new System.EventHandler(this.RaiseFilterChanged);
            // 
            // MatchFilterControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listBoxType);
            this.Controls.Add(this.labelMatchType);
            this.Controls.Add(this.checkBoxForfaitsExcluded);
            this.Controls.Add(this.labelForfaits);
            this.Controls.Add(this.listBoxSeason);
            this.Controls.Add(this.labelSeason);
            this.Controls.Add(this.listBoxVenue);
            this.Controls.Add(this.labelVenue);
            this.Controls.Add(this.noTr_textBoxOpponentId);
            this.Controls.Add(this.noTr_textBoxTeamId);
            this.Controls.Add(this.labelOppId);
            this.Controls.Add(this.labelTeamId);
            this.Name = "MatchFilterControl";
            this.Size = new System.Drawing.Size(693, 129);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTeamId;
        private System.Windows.Forms.Label labelOppId;
        private System.Windows.Forms.TextBox noTr_textBoxTeamId;
        private System.Windows.Forms.TextBox noTr_textBoxOpponentId;
        private System.Windows.Forms.Label labelVenue;
        private System.Windows.Forms.ListBox listBoxVenue;
        private System.Windows.Forms.Label labelSeason;
        private System.Windows.Forms.ListBox listBoxSeason;
        private System.Windows.Forms.Label labelForfaits;
        private System.Windows.Forms.CheckBox checkBoxForfaitsExcluded;
        private System.Windows.Forms.Label labelMatchType;
        private System.Windows.Forms.ListBox listBoxType;
    }
}
