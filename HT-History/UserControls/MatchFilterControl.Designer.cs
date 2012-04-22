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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxTeamId = new System.Windows.Forms.TextBox();
            this.textBoxOpponentId = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.listBoxVenue = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.listBoxSeason = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.checkBoxForfait = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.listBoxType = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Team ID:\r\n";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 26);
            this.label2.TabIndex = 1;
            this.label2.Text = "Opponent ID:\r\n( 0 = all )";
            // 
            // textBoxTeamId
            // 
            this.textBoxTeamId.Enabled = false;
            this.textBoxTeamId.Location = new System.Drawing.Point(80, 7);
            this.textBoxTeamId.Name = "textBoxTeamId";
            this.textBoxTeamId.Size = new System.Drawing.Size(104, 20);
            this.textBoxTeamId.TabIndex = 2;
            this.textBoxTeamId.Text = "0";
            // 
            // textBoxOpponentId
            // 
            this.textBoxOpponentId.Enabled = false;
            this.textBoxOpponentId.Location = new System.Drawing.Point(80, 51);
            this.textBoxOpponentId.Name = "textBoxOpponentId";
            this.textBoxOpponentId.Size = new System.Drawing.Size(104, 20);
            this.textBoxOpponentId.TabIndex = 2;
            this.textBoxOpponentId.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(382, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Venue:";
            // 
            // listBoxVenue
            // 
            this.listBoxVenue.Enabled = false;
            this.listBoxVenue.FormattingEnabled = true;
            this.listBoxVenue.Items.AddRange(new object[] {
            "All",
            "Home",
            "Away",
            "Neutral"});
            this.listBoxVenue.Location = new System.Drawing.Point(429, 7);
            this.listBoxVenue.Name = "listBoxVenue";
            this.listBoxVenue.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxVenue.Size = new System.Drawing.Size(120, 56);
            this.listBoxVenue.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(569, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Season:";
            // 
            // listBoxSeason
            // 
            this.listBoxSeason.Enabled = false;
            this.listBoxSeason.FormattingEnabled = true;
            this.listBoxSeason.Location = new System.Drawing.Point(621, 7);
            this.listBoxSeason.Name = "listBoxSeason";
            this.listBoxSeason.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxSeason.Size = new System.Drawing.Size(144, 95);
            this.listBoxSeason.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(382, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Forfaits:";
            // 
            // checkBoxForfait
            // 
            this.checkBoxForfait.AutoSize = true;
            this.checkBoxForfait.Enabled = false;
            this.checkBoxForfait.Location = new System.Drawing.Point(432, 81);
            this.checkBoxForfait.Name = "checkBoxForfait";
            this.checkBoxForfait.Size = new System.Drawing.Size(69, 17);
            this.checkBoxForfait.TabIndex = 8;
            this.checkBoxForfait.Text = "excluded";
            this.checkBoxForfait.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(202, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Type:";
            // 
            // listBoxType
            // 
            this.listBoxType.Enabled = false;
            this.listBoxType.FormattingEnabled = true;
            this.listBoxType.Items.AddRange(new object[] {
            "All",
            "Competitive",
            "League",
            "Cup",
            "Qualifier",
            "Masters / Other",
            "Friendly"});
            this.listBoxType.Location = new System.Drawing.Point(242, 7);
            this.listBoxType.Name = "listBoxType";
            this.listBoxType.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxType.Size = new System.Drawing.Size(120, 95);
            this.listBoxType.TabIndex = 10;
            // 
            // MatchFilterControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listBoxType);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.checkBoxForfait);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.listBoxSeason);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.listBoxVenue);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxOpponentId);
            this.Controls.Add(this.textBoxTeamId);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "MatchFilterControl";
            this.Size = new System.Drawing.Size(777, 113);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxTeamId;
        private System.Windows.Forms.TextBox textBoxOpponentId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox listBoxVenue;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox listBoxSeason;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox checkBoxForfait;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox listBoxType;
    }
}
