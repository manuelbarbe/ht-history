namespace HtHistory
{
    partial class AuthorizeDialog
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
            this.labelAuthorizeInstructions = new System.Windows.Forms.Label();
            this.labelAuthorizeEnterKey = new System.Windows.Forms.Label();
            this.textBoxPIN = new System.Windows.Forms.TextBox();
            this.noTr_linkLabelRequestUri = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(399, 186);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 0;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(318, 186);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 0;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // labelAuthorizeInstructions
            // 
            this.labelAuthorizeInstructions.Location = new System.Drawing.Point(12, 21);
            this.labelAuthorizeInstructions.Name = "labelAuthorizeInstructions";
            this.labelAuthorizeInstructions.Size = new System.Drawing.Size(462, 30);
            this.labelAuthorizeInstructions.TabIndex = 1;
            this.labelAuthorizeInstructions.Text = "It seems, that you have not authorized this application yet. Please visit the fol" +
                "lowing URI and grant permission to this product.";
            // 
            // labelAuthorizeEnterKey
            // 
            this.labelAuthorizeEnterKey.AutoSize = true;
            this.labelAuthorizeEnterKey.Location = new System.Drawing.Point(12, 108);
            this.labelAuthorizeEnterKey.Name = "labelAuthorizeEnterKey";
            this.labelAuthorizeEnterKey.Size = new System.Drawing.Size(270, 13);
            this.labelAuthorizeEnterKey.TabIndex = 3;
            this.labelAuthorizeEnterKey.Text = "Now enter the received activation key in the box below:";
            // 
            // textBoxPIN
            // 
            this.textBoxPIN.Location = new System.Drawing.Point(12, 138);
            this.textBoxPIN.Name = "textBoxPIN";
            this.textBoxPIN.Size = new System.Drawing.Size(456, 20);
            this.textBoxPIN.TabIndex = 4;
            // 
            // noTr_linkLabelRequestUri
            // 
            this.noTr_linkLabelRequestUri.Location = new System.Drawing.Point(15, 61);
            this.noTr_linkLabelRequestUri.Name = "noTr_linkLabelRequestUri";
            this.noTr_linkLabelRequestUri.Size = new System.Drawing.Size(453, 36);
            this.noTr_linkLabelRequestUri.TabIndex = 5;
            this.noTr_linkLabelRequestUri.TabStop = true;
            this.noTr_linkLabelRequestUri.Text = "request uri";
            this.noTr_linkLabelRequestUri.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelRequestUri_LinkClicked);
            // 
            // AuthorizeDialog
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(486, 221);
            this.Controls.Add(this.noTr_linkLabelRequestUri);
            this.Controls.Add(this.textBoxPIN);
            this.Controls.Add(this.labelAuthorizeEnterKey);
            this.Controls.Add(this.labelAuthorizeInstructions);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.buttonCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = global::HtHistory.Images.ht_history_ball1;
            this.MaximizeBox = false;
            this.Name = "AuthorizeDialog";
            this.Text = "Authorization required";
            this.Load += new System.EventHandler(this.AuthorizeDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Label labelAuthorizeInstructions;
        private System.Windows.Forms.Label labelAuthorizeEnterKey;
        private System.Windows.Forms.TextBox textBoxPIN;
        private System.Windows.Forms.LinkLabel noTr_linkLabelRequestUri;
    }
}