namespace notepad
{
    partial class ReplaceForm
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
            this.contentLabel = new System.Windows.Forms.Label();
            this.replaceLabel = new System.Windows.Forms.Label();
            this.contentTextBox = new System.Windows.Forms.TextBox();
            this.replaceTextBox = new System.Windows.Forms.TextBox();
            this.findNextButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.replaceAllButton = new System.Windows.Forms.Button();
            this.replaceButton = new System.Windows.Forms.Button();
            this.matchCaseCheckBox = new System.Windows.Forms.CheckBox();
            this.rotateCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // contentLabel
            // 
            this.contentLabel.AutoSize = true;
            this.contentLabel.Location = new System.Drawing.Point(12, 28);
            this.contentLabel.Name = "contentLabel";
            this.contentLabel.Size = new System.Drawing.Size(91, 20);
            this.contentLabel.TabIndex = 0;
            this.contentLabel.Text = "查找内容(&N)";
            // 
            // replaceLabel
            // 
            this.replaceLabel.AutoSize = true;
            this.replaceLabel.Location = new System.Drawing.Point(12, 78);
            this.replaceLabel.Name = "replaceLabel";
            this.replaceLabel.Size = new System.Drawing.Size(77, 20);
            this.replaceLabel.TabIndex = 1;
            this.replaceLabel.Text = "替换为(&P):";
            // 
            // contentTextBox
            // 
            this.contentTextBox.Location = new System.Drawing.Point(109, 25);
            this.contentTextBox.Name = "contentTextBox";
            this.contentTextBox.Size = new System.Drawing.Size(245, 27);
            this.contentTextBox.TabIndex = 2;
            this.contentTextBox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // replaceTextBox
            // 
            this.replaceTextBox.Location = new System.Drawing.Point(109, 75);
            this.replaceTextBox.Name = "replaceTextBox";
            this.replaceTextBox.Size = new System.Drawing.Size(245, 27);
            this.replaceTextBox.TabIndex = 3;
            this.replaceTextBox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // findNextButton
            // 
            this.findNextButton.Location = new System.Drawing.Point(360, 20);
            this.findNextButton.Name = "findNextButton";
            this.findNextButton.Size = new System.Drawing.Size(132, 33);
            this.findNextButton.TabIndex = 6;
            this.findNextButton.Text = "查找下一个(&F)";
            this.findNextButton.UseVisualStyleBackColor = true;
            this.findNextButton.Click += new System.EventHandler(this.FindNextButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(360, 176);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(132, 33);
            this.cancelButton.TabIndex = 9;
            this.cancelButton.Text = "取消";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // replaceAllButton
            // 
            this.replaceAllButton.Location = new System.Drawing.Point(360, 124);
            this.replaceAllButton.Name = "replaceAllButton";
            this.replaceAllButton.Size = new System.Drawing.Size(132, 33);
            this.replaceAllButton.TabIndex = 8;
            this.replaceAllButton.Text = "全部替换(&A)";
            this.replaceAllButton.UseVisualStyleBackColor = true;
            this.replaceAllButton.Click += new System.EventHandler(this.ReplaceAllButton_Click);
            // 
            // replaceButton
            // 
            this.replaceButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.replaceButton.Location = new System.Drawing.Point(360, 72);
            this.replaceButton.Name = "replaceButton";
            this.replaceButton.Size = new System.Drawing.Size(132, 33);
            this.replaceButton.TabIndex = 7;
            this.replaceButton.Text = "替换(&R)";
            this.replaceButton.UseVisualStyleBackColor = true;
            this.replaceButton.Click += new System.EventHandler(this.ReplaceButton_Click);
            // 
            // matchCaseCheckBox
            // 
            this.matchCaseCheckBox.AutoSize = true;
            this.matchCaseCheckBox.Location = new System.Drawing.Point(12, 153);
            this.matchCaseCheckBox.Name = "matchCaseCheckBox";
            this.matchCaseCheckBox.Size = new System.Drawing.Size(126, 24);
            this.matchCaseCheckBox.TabIndex = 4;
            this.matchCaseCheckBox.Text = "区分大小写(&C)";
            this.matchCaseCheckBox.UseVisualStyleBackColor = true;
            // 
            // rotateCheckBox
            // 
            this.rotateCheckBox.AutoSize = true;
            this.rotateCheckBox.Checked = true;
            this.rotateCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.rotateCheckBox.Location = new System.Drawing.Point(12, 192);
            this.rotateCheckBox.Name = "rotateCheckBox";
            this.rotateCheckBox.Size = new System.Drawing.Size(61, 24);
            this.rotateCheckBox.TabIndex = 5;
            this.rotateCheckBox.Text = "循环";
            this.rotateCheckBox.UseVisualStyleBackColor = true;
            // 
            // ReplaceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(504, 228);
            this.Controls.Add(this.rotateCheckBox);
            this.Controls.Add(this.matchCaseCheckBox);
            this.Controls.Add(this.replaceAllButton);
            this.Controls.Add(this.replaceButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.findNextButton);
            this.Controls.Add(this.replaceTextBox);
            this.Controls.Add(this.contentTextBox);
            this.Controls.Add(this.replaceLabel);
            this.Controls.Add(this.contentLabel);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReplaceForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "替换";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ReplaceForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label contentLabel;
        private System.Windows.Forms.Label replaceLabel;
        private System.Windows.Forms.TextBox contentTextBox;
        private System.Windows.Forms.TextBox replaceTextBox;
        private System.Windows.Forms.Button findNextButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button replaceAllButton;
        private System.Windows.Forms.Button replaceButton;
        private System.Windows.Forms.CheckBox matchCaseCheckBox;
        private System.Windows.Forms.CheckBox rotateCheckBox;
    }
}