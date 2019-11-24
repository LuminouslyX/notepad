namespace notepad
{
    partial class NotePadTabControl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.closeTabPageContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPageTest = new System.Windows.Forms.TabPage();
            this.richTextBoxTest = new System.Windows.Forms.RichTextBox();
            this.richTextBoxContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl.SuspendLayout();
            this.closeTabPageContextMenuStrip.SuspendLayout();
            this.tabPageTest.SuspendLayout();
            this.richTextBoxContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.ContextMenuStrip = this.closeTabPageContextMenuStrip;
            this.tabControl.Controls.Add(this.tabPageTest);
            this.tabControl.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControl.HotTrack = true;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1227, 708);
            this.tabControl.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tabControl.TabIndex = 0;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.TabControl_SelectedIndexChanged);
            // 
            // closeTabPageContextMenuStrip
            // 
            this.closeTabPageContextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.closeTabPageContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem});
            this.closeTabPageContextMenuStrip.Name = "closeTabPageContextMenuStrip";
            this.closeTabPageContextMenuStrip.Size = new System.Drawing.Size(129, 28);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(128, 24);
            this.closeToolStripMenuItem.Text = "关闭(&C)";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.CloseToolStripMenuItem_Click);
            // 
            // tabPageTest
            // 
            this.tabPageTest.AllowDrop = true;
            this.tabPageTest.Controls.Add(this.richTextBoxTest);
            this.tabPageTest.Location = new System.Drawing.Point(4, 29);
            this.tabPageTest.Name = "tabPageTest";
            this.tabPageTest.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTest.Size = new System.Drawing.Size(1219, 675);
            this.tabPageTest.TabIndex = 0;
            this.tabPageTest.Text = "Welcome";
            this.tabPageTest.UseVisualStyleBackColor = true;
            // 
            // richTextBoxTest
            // 
            this.richTextBoxTest.AcceptsTab = true;
            this.richTextBoxTest.ContextMenuStrip = this.richTextBoxContextMenuStrip;
            this.richTextBoxTest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxTest.Font = new System.Drawing.Font("Consolas", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxTest.Location = new System.Drawing.Point(3, 3);
            this.richTextBoxTest.Name = "richTextBoxTest";
            this.richTextBoxTest.Size = new System.Drawing.Size(1213, 669);
            this.richTextBoxTest.TabIndex = 0;
            this.richTextBoxTest.Text = "Welcome to my note pad!\nEnjoy yourself!";
            this.richTextBoxTest.TextChanged += new System.EventHandler(this.SetUnsaved);
            // 
            // richTextBoxContextMenuStrip
            // 
            this.richTextBoxContextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.richTextBoxContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.richTextBoxContextMenuStrip.Name = "contextMenuStrip1";
            this.richTextBoxContextMenuStrip.Size = new System.Drawing.Size(130, 100);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(129, 24);
            this.cutToolStripMenuItem.Text = "剪切(&T)";
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(129, 24);
            this.copyToolStripMenuItem.Text = "复制(&C)";
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(129, 24);
            this.pasteToolStripMenuItem.Text = "粘贴(&P)";
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(129, 24);
            this.deleteToolStripMenuItem.Text = "删除(&D)";
            // 
            // NotePadTabControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl);
            this.Name = "NotePadTabControl";
            this.Size = new System.Drawing.Size(1227, 708);
            this.tabControl.ResumeLayout(false);
            this.closeTabPageContextMenuStrip.ResumeLayout(false);
            this.tabPageTest.ResumeLayout(false);
            this.richTextBoxContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabPage tabPageTest;
        private System.Windows.Forms.RichTextBox richTextBoxTest;
        private System.Windows.Forms.ContextMenuStrip richTextBoxContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        internal System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.ContextMenuStrip closeTabPageContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
    }
}
