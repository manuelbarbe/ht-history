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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.noTr_buttonAdd = new System.Windows.Forms.Button();
            this.labelAvailableColumns = new System.Windows.Forms.Label();
            this.listBoxLeft = new System.Windows.Forms.ListBox();
            this.noTr_buttonDown = new System.Windows.Forms.Button();
            this.noTr_buttonUp = new System.Windows.Forms.Button();
            this.noTr_buttonRemove = new System.Windows.Forms.Button();
            this.listBoxRight = new System.Windows.Forms.ListBox();
            this.labelSelectedColumns = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.labelName = new System.Windows.Forms.Label();
            this.noTr_textBoxName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
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
            this.splitContainer1.Panel1.Controls.Add(this.noTr_buttonAdd);
            this.splitContainer1.Panel1.Controls.Add(this.labelAvailableColumns);
            this.splitContainer1.Panel1.Controls.Add(this.listBoxLeft);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.noTr_buttonDown);
            this.splitContainer1.Panel2.Controls.Add(this.noTr_buttonUp);
            this.splitContainer1.Panel2.Controls.Add(this.noTr_buttonRemove);
            this.splitContainer1.Panel2.Controls.Add(this.listBoxRight);
            this.splitContainer1.Panel2.Controls.Add(this.labelSelectedColumns);
            this.splitContainer1.Size = new System.Drawing.Size(627, 271);
            this.splitContainer1.SplitterDistance = 317;
            this.splitContainer1.TabIndex = 0;
            // 
            // noTr_buttonAdd
            // 
            this.noTr_buttonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.noTr_buttonAdd.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noTr_buttonAdd.Location = new System.Drawing.Point(278, 39);
            this.noTr_buttonAdd.Name = "noTr_buttonAdd";
            this.noTr_buttonAdd.Size = new System.Drawing.Size(27, 23);
            this.noTr_buttonAdd.TabIndex = 2;
            this.noTr_buttonAdd.Text = "→";
            this.noTr_buttonAdd.UseVisualStyleBackColor = true;
            this.noTr_buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // labelAvailableColumns
            // 
            this.labelAvailableColumns.AutoSize = true;
            this.labelAvailableColumns.Location = new System.Drawing.Point(13, 13);
            this.labelAvailableColumns.Name = "labelAvailableColumns";
            this.labelAvailableColumns.Size = new System.Drawing.Size(95, 13);
            this.labelAvailableColumns.TabIndex = 1;
            this.labelAvailableColumns.Text = "Available columns:";
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
            // noTr_buttonDown
            // 
            this.noTr_buttonDown.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noTr_buttonDown.Location = new System.Drawing.Point(13, 153);
            this.noTr_buttonDown.Name = "noTr_buttonDown";
            this.noTr_buttonDown.Size = new System.Drawing.Size(26, 23);
            this.noTr_buttonDown.TabIndex = 4;
            this.noTr_buttonDown.Text = "↓";
            this.noTr_buttonDown.UseVisualStyleBackColor = true;
            this.noTr_buttonDown.Click += new System.EventHandler(this.buttonDown_Click);
            // 
            // noTr_buttonUp
            // 
            this.noTr_buttonUp.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noTr_buttonUp.Location = new System.Drawing.Point(13, 123);
            this.noTr_buttonUp.Name = "noTr_buttonUp";
            this.noTr_buttonUp.Size = new System.Drawing.Size(26, 23);
            this.noTr_buttonUp.TabIndex = 3;
            this.noTr_buttonUp.Text = "↑";
            this.noTr_buttonUp.UseVisualStyleBackColor = true;
            this.noTr_buttonUp.Click += new System.EventHandler(this.buttonUp_Click);
            // 
            // noTr_buttonRemove
            // 
            this.noTr_buttonRemove.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noTr_buttonRemove.Location = new System.Drawing.Point(13, 67);
            this.noTr_buttonRemove.Name = "noTr_buttonRemove";
            this.noTr_buttonRemove.Size = new System.Drawing.Size(26, 23);
            this.noTr_buttonRemove.TabIndex = 2;
            this.noTr_buttonRemove.Text = "←";
            this.noTr_buttonRemove.UseVisualStyleBackColor = true;
            this.noTr_buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
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
            // labelSelectedColumns
            // 
            this.labelSelectedColumns.AutoSize = true;
            this.labelSelectedColumns.Location = new System.Drawing.Point(42, 13);
            this.labelSelectedColumns.Name = "labelSelectedColumns";
            this.labelSelectedColumns.Size = new System.Drawing.Size(94, 13);
            this.labelSelectedColumns.TabIndex = 0;
            this.labelSelectedColumns.Text = "Selected columns:";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(540, 277);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Location = new System.Drawing.Point(446, 277);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 2;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            // 
            // labelName
            // 
            this.labelName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(10, 281);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(38, 13);
            this.labelName.TabIndex = 3;
            this.labelName.Text = "Name:";
            // 
            // noTr_textBoxName
            // 
            this.noTr_textBoxName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.noTr_textBoxName.Location = new System.Drawing.Point(57, 278);
            this.noTr_textBoxName.Name = "noTr_textBoxName";
            this.noTr_textBoxName.Size = new System.Drawing.Size(215, 20);
            this.noTr_textBoxName.TabIndex = 4;
            // 
            // ChooseColumnsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 306);
            this.Controls.Add(this.noTr_textBoxName);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.splitContainer1);
            this.Icon = global::HtHistory.Images.ht_history_ball1;
            this.Name = "ChooseColumnsDialog";
            this.Text = "Select colums";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label labelAvailableColumns;
        private System.Windows.Forms.ListBox listBoxLeft;
        private System.Windows.Forms.Label labelSelectedColumns;
        private System.Windows.Forms.ListBox listBoxRight;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button noTr_buttonRemove;
        private System.Windows.Forms.Button noTr_buttonAdd;
        private System.Windows.Forms.Button noTr_buttonDown;
        private System.Windows.Forms.Button noTr_buttonUp;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox noTr_textBoxName;
    }
}