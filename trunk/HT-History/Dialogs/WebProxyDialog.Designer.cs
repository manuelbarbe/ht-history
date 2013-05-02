namespace HtHistory
{
    partial class WebProxyDialog
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
            this.labelEnterProxyUri = new System.Windows.Forms.Label();
            this.noTr_textBoxProxyURI = new System.Windows.Forms.TextBox();
            this.buttonTestProxy = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(295, 117);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 0;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Location = new System.Drawing.Point(214, 117);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 1;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // labelEnterProxyUri
            // 
            this.labelEnterProxyUri.AutoSize = true;
            this.labelEnterProxyUri.Location = new System.Drawing.Point(13, 13);
            this.labelEnterProxyUri.Name = "labelEnterProxyUri";
            this.labelEnterProxyUri.Size = new System.Drawing.Size(85, 13);
            this.labelEnterProxyUri.TabIndex = 2;
            this.labelEnterProxyUri.Text = "Enter proxy URI:";
            // 
            // noTr_textBoxProxyURI
            // 
            this.noTr_textBoxProxyURI.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.noTr_textBoxProxyURI.Location = new System.Drawing.Point(16, 43);
            this.noTr_textBoxProxyURI.Name = "noTr_textBoxProxyURI";
            this.noTr_textBoxProxyURI.Size = new System.Drawing.Size(273, 20);
            this.noTr_textBoxProxyURI.TabIndex = 3;
            // 
            // buttonTestProxy
            // 
            this.buttonTestProxy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonTestProxy.Location = new System.Drawing.Point(295, 43);
            this.buttonTestProxy.Name = "buttonTestProxy";
            this.buttonTestProxy.Size = new System.Drawing.Size(75, 23);
            this.buttonTestProxy.TabIndex = 4;
            this.buttonTestProxy.Text = "Test";
            this.buttonTestProxy.UseVisualStyleBackColor = true;
            this.buttonTestProxy.Click += new System.EventHandler(this.buttonTest_Click);
            // 
            // WebProxyDialog
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(382, 152);
            this.Controls.Add(this.buttonTestProxy);
            this.Controls.Add(this.noTr_textBoxProxyURI);
            this.Controls.Add(this.labelEnterProxyUri);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.buttonCancel);
            this.Icon = global::HtHistory.Images.ht_history_ball1;
            this.Name = "WebProxyDialog";
            this.Text = "WebProxyDialog";
            this.Load += new System.EventHandler(this.WebProxyDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Label labelEnterProxyUri;
        private System.Windows.Forms.TextBox noTr_textBoxProxyURI;
        private System.Windows.Forms.Button buttonTestProxy;
    }
}