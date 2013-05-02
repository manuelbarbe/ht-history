namespace HtHistory.Dialogs
{
    partial class AboutBox
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.noTr_labelProductName = new System.Windows.Forms.Label();
            this.noTr_labelVersion = new System.Windows.Forms.Label();
            this.noTr_labelCreators = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(366, 237);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::HtHistory.Images.HtHistory_withtext3;
            this.pictureBox1.Location = new System.Drawing.Point(12, 16);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(191, 212);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // noTr_labelProductName
            // 
            this.noTr_labelProductName.AutoSize = true;
            this.noTr_labelProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noTr_labelProductName.Location = new System.Drawing.Point(223, 16);
            this.noTr_labelProductName.Name = "noTr_labelProductName";
            this.noTr_labelProductName.Size = new System.Drawing.Size(146, 31);
            this.noTr_labelProductName.TabIndex = 2;
            this.noTr_labelProductName.Text = "HT-History";
            // 
            // noTr_labelVersion
            // 
            this.noTr_labelVersion.AutoSize = true;
            this.noTr_labelVersion.Location = new System.Drawing.Point(229, 51);
            this.noTr_labelVersion.Name = "noTr_labelVersion";
            this.noTr_labelVersion.Size = new System.Drawing.Size(41, 13);
            this.noTr_labelVersion.TabIndex = 3;
            this.noTr_labelVersion.Text = "version";
            // 
            // noTr_labelCreators
            // 
            this.noTr_labelCreators.AutoSize = true;
            this.noTr_labelCreators.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noTr_labelCreators.Location = new System.Drawing.Point(226, 107);
            this.noTr_labelCreators.Name = "noTr_labelCreators";
            this.noTr_labelCreators.Size = new System.Drawing.Size(191, 48);
            this.noTr_labelCreators.TabIndex = 4;
            this.noTr_labelCreators.Text = "Software by manuhell\r\n\r\nLogo by harrymoon (from flickr)";
            // 
            // AboutBox
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 272);
            this.Controls.Add(this.noTr_labelCreators);
            this.Controls.Add(this.noTr_labelVersion);
            this.Controls.Add(this.noTr_labelProductName);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutBox";
            this.Padding = new System.Windows.Forms.Padding(9);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AboutBox";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label noTr_labelProductName;
        private System.Windows.Forms.Label noTr_labelVersion;
        private System.Windows.Forms.Label noTr_labelCreators;

    }
}
