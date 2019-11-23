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
        private new Font Font { get; set; }

        public NotePadTabControl()
        {
            InitializeComponent();
            Font = new Font("Consolas", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
        }

        public void AddNewTabPage()
        {
            AddNewTabPage("newFile" + numberOfPage, new RichTextBox());
            numberOfPage++;
        }

        public void AddNewTabPage(string tabPageName, RichTextBox richTextBox)
        {
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

        private void SetUnsaved(object sender, EventArgs e)
        {
            if (sender is RichTextBox)
            {
                RichTextBox richTextBox = (RichTextBox)sender;
                richTextBox.Modified = true;
            }
        }
    }
}
