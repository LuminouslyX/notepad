﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace notepad
{
    public partial class NotePadTabControl : UserControl
    {
        private int numberOfPage = 1;
        internal bool WordWrap { get; private set; }
        internal new Font Font { get; private set; }
        internal Color BackGroundColor { get; private set; }

        public NotePadTabControl()
        {
            InitializeComponent();
            richTextBoxTest.AllowDrop = true;
            richTextBoxTest.DragDrop += new DragEventHandler(RichTextBox_DragDrop);
            richTextBoxTest.DragEnter += new DragEventHandler(RichTextBox_DragEnter);
            richTextBoxTest.Focus();
            richTextBoxTest.SelectionStart = richTextBoxTest.Text.Length;
            WordWrap = true;
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
            richTextBox.AllowDrop = true;
            richTextBox.ContextMenuStrip = richTextBoxContextMenuStrip;
            richTextBox.Dock = DockStyle.Fill;
            richTextBox.DragDrop += new DragEventHandler(RichTextBox_DragDrop);
            richTextBox.DragEnter += new DragEventHandler(RichTextBox_DragEnter);
            richTextBox.Font = Font;
            richTextBox.Location = new Point(3, 3);
            richTextBox.Name = "richTextBox";
            richTextBox.Size = new Size(1213, 673);
            richTextBox.TabIndex = 0;
            richTextBox.TextChanged += new EventHandler(SetUnsaved);
            richTextBox.WordWrap = WordWrap;

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

        private void TabControl_Click(object sender, EventArgs e)
        {
            ((RichTextBox)tabControl.SelectedTab.Controls[0]).Focus();
        }

        internal void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CopyToolStripMenuItem_Click(sender, e);
            DeleteToolStripMenuItem_Click(sender, e);
        }

        internal void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RichTextBox richTextBox = GetSelectedRichTextBox();
            if (richTextBox == null)
                return;
            string selectedText = richTextBox.SelectedText;
            if (selectedText != string.Empty)
            {
                Clipboard.SetText(selectedText);
            }
        }

        internal void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetSelectedRichTextBox()?.Paste();
        }

        internal void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ((RichTextBox)tabControl.SelectedTab.Controls[0]).SelectedText = string.Empty;
        }

        internal void SelectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetSelectedRichTextBox()?.SelectAll();
        }

        internal RichTextBox GetSelectedRichTextBox()
        {
            TabPage tabPage = tabControl.SelectedTab;
            if (tabPage == null)
                return null;
            return (RichTextBox)tabPage.Controls[0];
        }

        private void RichTextBoxContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            RichTextBox richTextBox = GetSelectedRichTextBox();
            if (richTextBox == null || richTextBox.Focused == false || Clipboard.GetText() == string.Empty)
            {
                pasteToolStripMenuItem.Enabled = false;
            }
            else
            {
                pasteToolStripMenuItem.Enabled = true;
            }
            if (richTextBox == null || richTextBox.SelectedText == string.Empty)
            {
                cutToolStripMenuItem.Enabled = false;
                copyToolStripMenuItem.Enabled = false;
                deleteToolStripMenuItem.Enabled = false;
            }
            else
            {
                cutToolStripMenuItem.Enabled = true;
                copyToolStripMenuItem.Enabled = true;
                deleteToolStripMenuItem.Enabled = true;
            }
            if (richTextBox == null || richTextBox.Focused == false)
            {
                selectAllToolStripMenuItem.Enabled = false;
            }
            else
            {
                selectAllToolStripMenuItem.Enabled = true;
            }
        }

        private void RichTextBox_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
            {
                string fileType = Path.GetExtension(file);
                if (fileType.Equals(".rtf"))
                {
                    RichTextBox richTextBox = GetSelectedRichTextBox();
                    int separateIndex = richTextBox.SelectionStart;
                    string contentOfLeft = richTextBox.Text.Substring(0, separateIndex);
                    string contentOfRight = richTextBox.Text.Substring(separateIndex);
                    richTextBox.LoadFile(file, RichTextBoxStreamType.RichText);
                    string contentOfMiddle = richTextBox.Text;
                    richTextBox.Text = contentOfLeft + contentOfMiddle + contentOfRight;
                }
                else if (fileType.Equals(".uni") || fileType.Equals(".txt")) 
                {
                    RichTextBox richTextBox = GetSelectedRichTextBox();
                    FileStream fileSteam = new FileStream(file, FileMode.Open, FileAccess.Read);
                    StreamReader streamReader = new StreamReader(fileSteam, Encoding.UTF8);
                    int separateIndex = richTextBox.SelectionStart;
                    string contentOfLeft = richTextBox.Text.Substring(0, separateIndex);
                    string contentOfRight = richTextBox.Text.Substring(separateIndex);
                    richTextBox.Clear();
                    richTextBox.AppendText(contentOfLeft);
                    richTextBox.AppendText(streamReader.ReadToEnd());
                    richTextBox.AppendText(contentOfRight);
                    streamReader.Close();
                    fileSteam.Close();
                }
            }
        }

        private void RichTextBox_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Link;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
    }
}
