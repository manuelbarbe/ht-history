namespace HtHistory.Dialogs
{
    partial class ChooseColumnsDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChooseColumnsDialog));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.listBoxLeft = new System.Windows.Forms.ListBox();
            this.buttonDown = new System.Windows.Forms.Button();
            this.buttonUp = new System.Windows.Forms.Button();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.listBoxRight = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.labelName = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
#if !MONO
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
#endif            
			this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.buttonAdd);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.listBoxLeft);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.buttonDown);
            this.splitContainer1.Panel2.Controls.Add(this.buttonUp);
            this.splitContainer1.Panel2.Controls.Add(this.buttonRemove);
            this.splitContainer1.Panel2.Controls.Add(this.listBoxRight);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Size = new System.Drawing.Size(627, 271);
            this.splitContainer1.SplitterDistance = 317;
            this.splitContainer1.TabIndex = 0;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAdd.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAdd.Location = new System.Drawing.Point(278, 39);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(27, 23);
            this.buttonAdd.TabIndex = 2;
            this.buttonAdd.Text = "→";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Available columns:";
            // 
            // listBoxLeft
            // 
            this.listBoxLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxLeft.FormattingEnabled = true;
            this.listBoxLeft.Location = new System.Drawing.Point(13, 39);
            this.listBoxLeft.Name = "listBoxLeft";
            this.listBoxLeft.Size = new System.Drawing.Size(259, 225);
            this.listBoxLeft.TabIndex = 0;
            this.listBoxLeft.DoubleClick += new System.EventHandler(this.listBoxLeft_DoubleClick);
            // 
            // buttonDown
            // 
            this.buttonDown.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDown.Location = new System.Drawing.Point(13, 153);
            this.buttonDown.Name = "buttonDown";
            this.buttonDown.Size = new System.Drawing.Size(26, 23);
            this.buttonDown.TabIndex = 4;
            this.buttonDown.Text = "↓";
            this.buttonDown.UseVisualStyleBackColor = true;
            this.buttonDown.Click += new System.EventHandler(this.buttonDown_Click);
            // 
            // buttonUp
            // 
            this.buttonUp.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonUp.Location = new System.Drawing.Point(13, 123);
            this.buttonUp.Name = "buttonUp";
            this.buttonUp.Size = new System.Drawing.Size(26, 23);
            this.buttonUp.TabIndex = 3;
            this.buttonUp.Text = "↑";
            this.buttonUp.UseVisualStyleBackColor = true;
            this.buttonUp.Click += new System.EventHandler(this.buttonUp_Click);
            // 
            // buttonRemove
            // 
            this.buttonRemove.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRemove.Location = new System.Drawing.Point(13, 67);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(26, 23);
            this.buttonRemove.TabIndex = 2;
            this.buttonRemove.Text = "←";
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // listBoxRight
            // 
            this.listBoxRight.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxRight.FormattingEnabled = true;
            this.listBoxRight.Location = new System.Drawing.Point(45, 39);
            this.listBoxRight.Name = "listBoxRight";
            this.listBoxRight.Size = new System.Drawing.Size(249, 225);
            this.listBoxRight.TabIndex = 1;
            this.listBoxRight.DoubleClick += new System.EventHandler(this.listBoxRight_DoubleClick);
            this.listBoxRight.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listBoxRight_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Selected columns:";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Location = new System.Drawing.Point(540, 277);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button2.Location = new System.Drawing.Point(446, 277);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "OK";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // labelName
            // 
            this.labelName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(13, 281);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(38, 13);
            this.labelName.TabIndex = 3;
            this.labelName.Text = "Name:";
            // 
            // textBoxName
            // 
            this.textBoxName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxName.Location = new System.Drawing.Point(57, 278);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(215, 20);
            this.textBoxName.TabIndex = 4;
            // 
            // ChooseColumnsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 306);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.splitContainer1);
            this.Icon = Images.ht_history_ball1;
            this.Name = "ChooseColumnsDialog";
            this.Text = "Select colums";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
#if !MONO
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
#endif
			this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBoxLeft;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBoxRight;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonDown;
        private System.Windows.Forms.Button buttonUp;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox textBoxName;
    }
}