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
            fileToolStripMenuItem.PerformClick();
            editToolStripMenuItem.PerformClick();
        }


        /// <summary>
        /// 打开工具栏的文件项的时候产生的响应处理。
        /// </summary>
        /// <param name="sender">响应时间的源。</param>
        /// <param name="e">响应事件。</param>
        private void FileToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            RichTextBox richTextBox = notePadTabControl.GetSelectedRichTextBox();
            if (richTextBox != null && richTextBox.Modified == true)
            {
                saveToolStripMenuItem.Enabled = true;
            }
            else
            {
                saveToolStripMenuItem.Enabled = false;
            }
        }


        /// <summary>
        /// 点击工具栏下文件项里的新建项时产生的响应处理。
        /// </summary>
        /// <param name="sender">响应时间的源。</param>
        /// <param name="e">响应事件。</param>
        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notePadTabControl.AddNewTabPage();
        }


        /// <summary>
        /// 点击工具栏下文件项里的打开项时产生的响应处理。
        /// </summary>
        /// <param name="sender">响应时间的源。</param>
        /// <param name="e">响应事件。</param>
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


        /// <summary>
        /// 点击工具栏下文件项里的保存项时产生的响应处理。
        /// </summary>
        /// <param name="sender">响应时间的源。</param>
        /// <param name="e">响应事件。</param>
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


        /// <summary>
        /// 点击工具栏下文件项里的另存为项时产生的响应处理。
        /// </summary>
        /// <param name="sender">响应时间的源。</param>
        /// <param name="e">响应事件。</param>
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


        /// <summary>
        /// 点击工具栏下文件项里的退出项时产生的响应处理。
        /// </summary>
        /// <param name="sender">响应时间的源。</param>
        /// <param name="e">响应事件。</param>
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }


        /// <summary>
        /// 打开工具栏的编辑项的时候产生的响应处理。
        /// </summary>
        /// <param name="sender">响应时间的源。</param>
        /// <param name="e">响应事件。</param>
        private void EditToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            RichTextBox richTextBox = notePadTabControl.GetSelectedRichTextBox();
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

        /// <summary>
        /// 点击工具栏下编辑项里的剪切项时产生的响应处理。
        /// </summary>
        /// <param name="sender">响应时间的源。</param>
        /// <param name="e">响应事件。</param>
        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notePadTabControl.CutToolStripMenuItem_Click(sender, e);
        }


        /// <summary>
        /// 点击工具栏下编辑项里的复制项时产生的响应处理。
        /// </summary>
        /// <param name="sender">响应时间的源。</param>
        /// <param name="e">响应事件。</param>
        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notePadTabControl.CopyToolStripMenuItem_Click(sender, e);
        }


        /// <summary>
        /// 点击工具栏下编辑项里的粘贴项时产生的响应处理。
        /// </summary>
        /// <param name="sender">响应时间的源。</param>
        /// <param name="e">响应事件。</param>
        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notePadTabControl.PasteToolStripMenuItem_Click(sender, e);
        }


        /// <summary>
        /// 点击工具栏下编辑项里的删除项时产生的响应处理。
        /// </summary>
        /// <param name="sender">响应时间的源。</param>
        /// <param name="e">响应事件。</param>
        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notePadTabControl.DeleteToolStripMenuItem_Click(sender, e);
        }


        /// <summary>
        /// 点击工具栏下编辑项里的全选项时产生的响应处理。
        /// </summary>
        /// <param name="sender">响应时间的源。</param>
        /// <param name="e">响应事件。</param>
        private void SelectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notePadTabControl.SelectAllToolStripMenuItem_Click(sender, e);
        }


        /// <summary>
        /// 点击工具栏下格式项里的换行项时产生的响应处理。
        /// </summary>
        /// <param name="sender">响应时间的源。</param>
        /// <param name="e">响应事件。</param>
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


        /// <summary>
        /// 点击工具栏下格式项里的字体项时产生的响应处理。
        /// </summary>
        /// <param name="sender">响应时间的源。</param>
        /// <param name="e">响应事件。</param>
        private void FontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog.Font = notePadTabControl.Font;
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                notePadTabControl.SetFont(fontDialog.Font);
            }
        }


        /// <summary>
        /// 点击工具栏下格式项里的颜色项时产生的响应处理。
        /// </summary>
        /// <param name="sender">响应时间的源。</param>
        /// <param name="e">响应事件。</param>
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
