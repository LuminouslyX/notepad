using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace notepad
{
    public partial class NotePadTabControl : UserControl
    {
        private int numberOfPage = 1;
        internal bool WordWrap { get; private set; } = true;
        internal new Font Font { get; private set; }
        internal Color BackGroundColor { get; private set; }

        public NotePadTabControl()
        {
            InitializeComponent();
            Font = new Font("Consolas", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BackGroundColor = richTextBoxTest.BackColor;
        }

        public void AddNewTabPage()
        {
            AddNewTabPage("newFile" + numberOfPage, new RichTextBox());
            numberOfPage++;
        }

        public void AddNewTabPage(string tabPageName, RichTextBox richTextBox)
        {
            richTextBox.AcceptsTab = true;
            richTextBox.ContextMenuStrip = richTextBoxContextMenuStrip;
            richTextBox.Dock = DockStyle.Fill;
            richTextBox.Font = Font;
            richTextBox.Location = new Point(3, 3);
            richTextBox.Name = "richTextBox";
            richTextBox.Size = new Size(1213, 673);
            richTextBox.TabIndex = 0;
            richTextBox.TextChanged += new EventHandler(SetUnsaved);

            TabPage tabPage = new TabPage();
            tabPage.SuspendLayout();
            tabPage.AllowDrop = true;
            tabPage.Controls.Add(richTextBox);
            tabPage.Location = new Point(4, 25);
            tabPage.Name = "tabPage";
            tabPage.Padding = new Padding(3);
            tabPage.Size = new Size(1219, 679);
            tabPage.TabIndex = 0;
            tabPage.Text = tabPageName;
            tabPage.UseVisualStyleBackColor = true;

            tabControl.Controls.Add(tabPage);
            tabPage.ResumeLayout();
            tabControl.SelectedTab = tabPage;
        }

        public void SetFont(Font font)
        {
            Font = font;
            foreach(TabPage tabPage in tabControl.TabPages)
            {
                RichTextBox richTextBox = (RichTextBox)tabPage.Controls[0];
                richTextBox.Font = Font;
            }
        }

        public void SetBackGroundColor(Color color)
        {
            BackGroundColor = color;
            foreach (TabPage tabPage in tabControl.TabPages)
            {
                RichTextBox richTextBox = (RichTextBox)tabPage.Controls[0];
                richTextBox.BackColor = BackGroundColor;
            }
        }


        private void SetUnsaved(object sender, EventArgs e)
        {
            if (sender is RichTextBox)
            {
                RichTextBox richTextBox = (RichTextBox)sender;
                richTextBox.Modified = true;
            }
        }

        internal void ReverseWordWrap()
        {
            WordWrap = !WordWrap;
            foreach(TabPage tabPage in tabControl.TabPages)
            {
                foreach (Control control in tabPage.Controls)
                {
                    if (control is RichTextBox)
                    {
                        RichTextBox richTextBox = (RichTextBox)control;
                        richTextBox.WordWrap = WordWrap;
                    }
                }
            }
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl.Controls.Remove(tabControl.SelectedTab);
        }

        private void TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabPage tabPage = tabControl.SelectedTab;
            RichTextBox richTextBox = (RichTextBox)tabPage.Controls[0];
            richTextBox.Focus();
        }
    }
}
