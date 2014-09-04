namespace HtHistory.Dialogs
{
    partial class TeamIdDialog
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.noTr_textBoxTeamId = new System.Windows.Forms.TextBox();
            this.labelInsertTeamId = new System.Windows.Forms.Label();
            this.radioButtonOwner = new System.Windows.Forms.RadioButton();
            this.radioButtonPeriod = new System.Windows.Forms.RadioButton();
            this.noTr_dateTimePickerFrom = new System.Windows.Forms.DateTimePicker();
            this.noTr_dateTimePickerTo = new System.Windows.Forms.DateTimePicker();
            this.labelFrom = new System.Windows.Forms.Label();
            this.labelTo = new System.Windows.Forms.Label();
            this.labelSpecifyPeriodInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(152, 255);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonOk
            // 
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Location = new System.Drawing.Point(71, 255);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 1;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // noTr_textBoxTeamId
            // 
            this.noTr_textBoxTeamId.Location = new System.Drawing.Point(13, 64);
            this.noTr_textBoxTeamId.Name = "noTr_textBoxTeamId";
            this.noTr_textBoxTeamId.Size = new System.Drawing.Size(214, 20);
            this.noTr_textBoxTeamId.TabIndex = 0;
            this.noTr_textBoxTeamId.Text = "0";
            // 
            // labelInsertTeamId
            // 
            this.labelInsertTeamId.Location = new System.Drawing.Point(12, 14);
            this.labelInsertTeamId.Name = "labelInsertTeamId";
            this.labelInsertTeamId.Size = new System.Drawing.Size(215, 46);
            this.labelInsertTeamId.TabIndex = 3;
            this.labelInsertTeamId.Text = "Please enter the ID of the team you are\r\ninterested in. 0 defaults to your team.";
            this.labelInsertTeamId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // radioButtonOwner
            // 
            this.radioButtonOwner.AutoSize = true;
            this.radioButtonOwner.Checked = true;
            this.radioButtonOwner.Location = new System.Drawing.Point(13, 97);
            this.radioButtonOwner.Name = "radioButtonOwner";
            this.radioButtonOwner.Size = new System.Drawing.Size(90, 17);
            this.radioButtonOwner.TabIndex = 4;
            this.radioButtonOwner.TabStop = true;
            this.radioButtonOwner.Text = "current owner";
            this.radioButtonOwner.UseVisualStyleBackColor = true;
            // 
            // radioButtonPeriod
            // 
            this.radioButtonPeriod.AutoSize = true;
            this.radioButtonPeriod.Location = new System.Drawing.Point(13, 121);
            this.radioButtonPeriod.Name = "radioButtonPeriod";
            this.radioButtonPeriod.Size = new System.Drawing.Size(160, 17);
            this.radioButtonPeriod.TabIndex = 5;
            this.radioButtonPeriod.Text = "specifiy time period (HT time)";
            this.radioButtonPeriod.UseVisualStyleBackColor = true;
            this.radioButtonPeriod.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // noTr_dateTimePickerFrom
            // 
            this.noTr_dateTimePickerFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.noTr_dateTimePickerFrom.Location = new System.Drawing.Point(53, 186);
            this.noTr_dateTimePickerFrom.Name = "noTr_dateTimePickerFrom";
            this.noTr_dateTimePickerFrom.Size = new System.Drawing.Size(174, 20);
            this.noTr_dateTimePickerFrom.TabIndex = 6;
            // 
            // noTr_dateTimePickerTo
            // 
            this.noTr_dateTimePickerTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.noTr_dateTimePickerTo.Location = new System.Drawing.Point(53, 212);
            this.noTr_dateTimePickerTo.Name = "noTr_dateTimePickerTo";
            this.noTr_dateTimePickerTo.Size = new System.Drawing.Size(174, 20);
            this.noTr_dateTimePickerTo.TabIndex = 7;
            // 
            // labelFrom
            // 
            this.labelFrom.Location = new System.Drawing.Point(2, 186);
            this.labelFrom.Name = "labelFrom";
            this.labelFrom.Size = new System.Drawing.Size(45, 18);
            this.labelFrom.TabIndex = 8;
            this.labelFrom.Text = "from";
            this.labelFrom.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelTo
            // 
            this.labelTo.Location = new System.Drawing.Point(5, 214);
            this.labelTo.Name = "labelTo";
            this.labelTo.Size = new System.Drawing.Size(42, 13);
            this.labelTo.TabIndex = 8;
            this.labelTo.Text = "to";
            this.labelTo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelSpecifyPeriodInfo
            // 
            this.labelSpecifyPeriodInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSpecifyPeriodInfo.ForeColor = System.Drawing.Color.Red;
            this.labelSpecifyPeriodInfo.Location = new System.Drawing.Point(12, 144);
            this.labelSpecifyPeriodInfo.Name = "labelSpecifyPeriodInfo";
            this.labelSpecifyPeriodInfo.Size = new System.Drawing.Size(215, 39);
            this.labelSpecifyPeriodInfo.TabIndex = 9;
            this.labelSpecifyPeriodInfo.Text = "For bots, second teams and former users!";
            // 
            // TeamIdDialog
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(241, 290);
            this.Controls.Add(this.labelSpecifyPeriodInfo);
            this.Controls.Add(this.labelTo);
            this.Controls.Add(this.labelFrom);
            this.Controls.Add(this.noTr_dateTimePickerTo);
            this.Controls.Add(this.noTr_dateTimePickerFrom);
            this.Controls.Add(this.radioButtonPeriod);
            this.Controls.Add(this.radioButtonOwner);
            this.Controls.Add(this.labelInsertTeamId);
            this.Controls.Add(this.noTr_textBoxTeamId);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.buttonCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = global::HtHistory.Images.ht_history_ball1;
            this.Name = "TeamIdDialog";
            this.Text = "Choose Team";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TeamIdDialog_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.TextBox noTr_textBoxTeamId;
        private System.Windows.Forms.Label labelInsertTeamId;
        private System.Windows.Forms.RadioButton radioButtonOwner;
        private System.Windows.Forms.RadioButton radioButtonPeriod;
        private System.Windows.Forms.DateTimePicker noTr_dateTimePickerFrom;
        private System.Windows.Forms.DateTimePicker noTr_dateTimePickerTo;
        private System.Windows.Forms.Label labelFrom;
        private System.Windows.Forms.Label labelTo;
        private System.Windows.Forms.Label labelSpecifyPeriodInfo;
    }
}