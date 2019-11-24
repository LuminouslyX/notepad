using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace notepad
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent(); 
        }

        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notePadTabControl.AddNewTabPage();
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string absolutePahtName = openFileDialog.FileName;
                string fileType = absolutePahtName.Substring(absolutePahtName.LastIndexOf('.') + 1).ToLower();
                FileStream fileSteam = new FileStream(absolutePahtName, FileMode.Open, FileAccess.Read);
                StreamReader streamReader = new StreamReader(fileSteam, Encoding.UTF8);
                RichTextBox richTextBox = new RichTextBox();
                if (fileType.Equals("rtf"))
                {
                    richTextBox.LoadFile(absolutePahtName, RichTextBoxStreamType.RichText);
                }
                else
                {
                    richTextBox.Text = streamReader.ReadToEnd();
                }
                streamReader.Close();
                fileSteam.Close();
                notePadTabControl.AddNewTabPage(absolutePahtName, richTextBox);
            }
        }

        private void WordWrapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (notePadTabControl.WordWrap == false)
            {
                wordWrapToolStripMenuItem.Text = "取消自动换行(&W)";
            }
            else
            {
                wordWrapToolStripMenuItem.Text = "自动换行(&W)";
            }
            notePadTabControl.ReverseWordWrap();
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabPage tabPage = notePadTabControl.tabControl.SelectedTab;
            RichTextBox richTextBox = (RichTextBox)tabPage.Controls[0];
            string absolutePathName = tabPage.Text;
            try
            {
                FileStream fileStream = new FileStream(absolutePathName, FileMode.Open);
                fileStream.Close();
                string fileType = absolutePathName.Substring(absolutePathName.LastIndexOf('.') + 1).ToLower();
                if (fileType.Equals("rtf"))
                {
                    richTextBox.SaveFile(absolutePathName, RichTextBoxStreamType.RichText);
                }
                else if (fileType.Equals("uni"))
                {
                    richTextBox.SaveFile(absolutePathName, RichTextBoxStreamType.UnicodePlainText);
                }
                else
                {
                    richTextBox.SaveFile(absolutePathName, RichTextBoxStreamType.PlainText);
                }
            }
            catch (FileNotFoundException)
            {
                SaveAsToolStripMenuItem_Click(sender, e);
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string absolutePathName = notePadTabControl.tabControl.SelectedTab.Text;
            if (absolutePathName.LastIndexOf('.') != -1)
            {
                saveFileDialog.FileName = absolutePathName;
            }
            else
            {
                saveFileDialog.FileName = absolutePathName + ".rtf";        //默认为rtf文件
            }

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                absolutePathName = saveFileDialog.FileName;
                notePadTabControl.tabControl.SelectedTab.Text = absolutePathName;
                string fileType = absolutePathName.Substring(absolutePathName.LastIndexOf('.') + 1);
                FileStream fileStream = new FileStream(absolutePathName, FileMode.OpenOrCreate);
                fileStream.Close();

                RichTextBox richTextBox = (RichTextBox)notePadTabControl.tabControl.SelectedTab.Controls[0];
                if (fileType.Equals("rtf"))
                {
                    richTextBox.SaveFile(absolutePathName, RichTextBoxStreamType.RichText);
                }
                else if (fileType.Equals("uni"))
                {
                    richTextBox.SaveFile(absolutePathName, RichTextBoxStreamType.UnicodePlainText);
                }
                else
                {
                    richTextBox.SaveFile(absolutePathName, RichTextBoxStreamType.PlainText);
                }
            }
        }
    }
}
