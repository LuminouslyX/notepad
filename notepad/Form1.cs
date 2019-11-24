using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace notepad
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]

        internal static extern IntPtr GetFocus();

        ///获取 当前拥有焦点的控件
        private Control GetFocusedControl()
        {

            Control focusedControl = null;
            
            IntPtr focusedHandle = GetFocus();
            if (focusedHandle != IntPtr.Zero)
            {
                focusedControl = Control.FromChildHandle(focusedHandle);
            }
            return focusedControl;
        }

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
                richTextBox.Modified = false;
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
                richTextBox.Modified = false;
            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private RichTextBox GetSelectedRichTextBox()
        {
            TabPage tabPage = notePadTabControl.tabControl.SelectedTab;
            if (tabPage == null)
                return null;
            RichTextBox richTextBox = (RichTextBox)tabPage.Controls[0];
            return richTextBox;
        }

        private void FileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RichTextBox richTextBox = GetSelectedRichTextBox();
            if (richTextBox == null)
                return;
            if (richTextBox.Modified == true)
            {
                saveToolStripMenuItem.Enabled = true;
            }
            else
            {
                saveToolStripMenuItem.Enabled = false;
            }
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RichTextBox richTextBox = GetSelectedRichTextBox();
            string selectedText = richTextBox.SelectedRtf;
            if (selectedText != string.Empty)
            {
                Clipboard.SetText(selectedText);
            }
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RichTextBox richTextBox = (RichTextBox)notePadTabControl.tabControl.SelectedTab.Controls[0];
            richTextBox.Paste();
        }

        private void SelectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RichTextBox richTextBox = (RichTextBox)notePadTabControl.tabControl.SelectedTab.Controls[0];
            richTextBox.SelectAll();
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RichTextBox richTextBox = (RichTextBox)notePadTabControl.tabControl.SelectedTab.Controls[0];
            richTextBox.SelectedText = string.Empty;
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CopyToolStripMenuItem_Click(sender, e);
            DeleteToolStripMenuItem_Click(sender, e);
        }

        private void EditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Clipboard.GetText() == string.Empty)
            {
                pasteToolStripMenuItem.Enabled = false;
            }
            else
            {
                pasteToolStripMenuItem.Enabled = true;
            }
            if (GetSelectedRichTextBox().SelectedText == string.Empty)
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
            Control control = GetFocusedControl();
            if (control == null || !(control is RichTextBox))
            {
                selectAllToolStripMenuItem.Enabled = false;
            }
            else
            {
                selectAllToolStripMenuItem.Enabled = true;
            }
        }

        private void FontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog.Font = notePadTabControl.Font;
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                notePadTabControl.SetFont(fontDialog.Font);
            }
        }

        private void ColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog.Color = notePadTabControl.BackGroundColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                notePadTabControl.SetBackGroundColor(colorDialog.Color);
            }
        }
    }
}
