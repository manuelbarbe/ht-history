﻿namespace HtHistory
{
    partial class Form1
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
            this.textBoxTeamId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxOppId = new System.Windows.Forms.TextBox();
            this.labelTeamInfo = new System.Windows.Forms.Label();
            this.labelOpponentInfo = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearCacheToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.scorerPage1 = new HtHistory.Pages.ScorerPage();
            this.appearancePage1 = new HtHistory.Pages.AppearancePage();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxTeamId
            // 
            this.textBoxTeamId.Location = new System.Drawing.Point(146, 37);
            this.textBoxTeamId.Name = "textBoxTeamId";
            this.textBoxTeamId.Size = new System.Drawing.Size(100, 20);
            this.textBoxTeamId.TabIndex = 1;
            this.textBoxTeamId.Text = "332944";
            this.textBoxTeamId.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxTeamId_KeyDown);
            this.textBoxTeamId.Leave += new System.EventHandler(this.textBoxTeamId_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Enter your team ID:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 33);
            this.label2.TabIndex = 3;
            this.label2.Text = "Enter opponent team ID (0 = all opponents)";
            // 
            // textBoxOppId
            // 
            this.textBoxOppId.Location = new System.Drawing.Point(146, 65);
            this.textBoxOppId.Name = "textBoxOppId";
            this.textBoxOppId.Size = new System.Drawing.Size(100, 20);
            this.textBoxOppId.TabIndex = 2;
            this.textBoxOppId.Text = "0";
            this.textBoxOppId.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxOppId_KeyDown);
            this.textBoxOppId.Leave += new System.EventHandler(this.textBoxOppId_Leave);
            // 
            // labelTeamInfo
            // 
            this.labelTeamInfo.AutoSize = true;
            this.labelTeamInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTeamInfo.Location = new System.Drawing.Point(273, 40);
            this.labelTeamInfo.Name = "labelTeamInfo";
            this.labelTeamInfo.Size = new System.Drawing.Size(88, 13);
            this.labelTeamInfo.TabIndex = 6;
            this.labelTeamInfo.Text = "__TeamInfo__";
            // 
            // labelOpponentInfo
            // 
            this.labelOpponentInfo.AutoSize = true;
            this.labelOpponentInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOpponentInfo.Location = new System.Drawing.Point(273, 68);
            this.labelOpponentInfo.Name = "labelOpponentInfo";
            this.labelOpponentInfo.Size = new System.Drawing.Size(96, 13);
            this.labelOpponentInfo.TabIndex = 6;
            this.labelOpponentInfo.Text = "__OpponentInfo__";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(825, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "- under development -";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(944, 24);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearCacheToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // clearCacheToolStripMenuItem
            // 
            this.clearCacheToolStripMenuItem.Enabled = false;
            this.clearCacheToolStripMenuItem.Name = "clearCacheToolStripMenuItem";
            this.clearCacheToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.clearCacheToolStripMenuItem.Text = "Clear cache";
            this.clearCacheToolStripMenuItem.Click += new System.EventHandler(this.clearCacheToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(132, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::HtHistory.Images.chpp;
            this.pictureBox1.Location = new System.Drawing.Point(832, 37);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(93, 58);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(171, 96);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "refresh";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(15, 136);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(917, 499);
            this.tabControl1.TabIndex = 14;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.scorerPage1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(909, 473);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Scorers";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.appearancePage1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(909, 473);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Appearance";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // scorerPage1
            // 
            this.scorerPage1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scorerPage1.Location = new System.Drawing.Point(3, 3);
            this.scorerPage1.Name = "scorerPage1";
            this.scorerPage1.Size = new System.Drawing.Size(903, 467);
            this.scorerPage1.TabIndex = 0;
            // 
            // appearancePage1
            // 
            this.appearancePage1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.appearancePage1.Location = new System.Drawing.Point(3, 3);
            this.appearancePage1.Name = "appearancePage1";
            this.appearancePage1.Size = new System.Drawing.Size(903, 467);
            this.appearancePage1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 647);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.labelOpponentInfo);
            this.Controls.Add(this.labelTeamInfo);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxOppId);
            this.Controls.Add(this.textBoxTeamId);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxTeamId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxOppId;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelTeamInfo;
        private System.Windows.Forms.Label labelOpponentInfo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearCacheToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private Pages.ScorerPage scorerPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private Pages.AppearancePage appearancePage1;
    }
}
