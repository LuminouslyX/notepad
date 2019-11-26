using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace notepad
{
    public partial class MainForm : Form
    {
        private FindForm findForm;
        private ReplaceForm replaceForm;
        internal bool FindFormShown { get; set; } = false;
        internal bool ReplaceFormShown { get; set; } = false;
        public MainForm()
        {
            InitializeComponent();
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
                string absolutePathName = openFileDialog.FileName;
                string fileType = absolutePathName.Substring(absolutePathName.LastIndexOf('.') + 1).ToLower();
                
                RichTextBox richTextBox = new RichTextBox();
                if (fileType.Equals("rtf"))
                {
                    richTextBox.LoadFile(absolutePathName, RichTextBoxStreamType.RichText);
                }
                else 
                {
                    FileStream fileSteam = new FileStream(absolutePathName, FileMode.Open, FileAccess.Read);
                    StreamReader streamReader = new StreamReader(fileSteam, Encoding.UTF8);
                    richTextBox.Text = streamReader.ReadToEnd();
                    streamReader.Close();
                    fileSteam.Close();
                }
                notePadTabControl.AddNewTabPage(absolutePathName, richTextBox);
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
            if (richTextBox == null || richTextBox.Focused == false)
            {
                dateToolStripMenuItem.Enabled = false;
            }
            else
            {
                dateToolStripMenuItem.Enabled = true;
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
        /// 点击工具栏下编辑项里的时间日期项时产生的响应处理。
        /// </summary>
        /// <param name="sender">响应时间的源。</param>
        /// <param name="e">响应事件。</param>
        private void DateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notePadTabControl.GetSelectedRichTextBox()?.AppendText(DateTime.Now.ToString());
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


        /// <summary>
        /// 点击工具栏下查看项里的查找项时产生的响应处理。
        /// </summary>
        /// <param name="sender">响应时间的源。</param>
        /// <param name="e">响应事件。</param>
        private void FindToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FindFormShown)
            {
                findForm.Focus();
            }
            else
            {
                findForm = new FindForm(this);
                findForm.Show();
                FindFormShown = true;
            }
        }


        /// <summary>
        /// 点击工具栏下查看项里的替换项时产生的响应处理。
        /// </summary>
        /// <param name="sender">响应时间的源。</param>
        /// <param name="e">响应事件。</param>
        private void ReplaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ReplaceFormShown)
            {
                replaceForm.Focus();
            }
            else
            {
                replaceForm = new ReplaceForm(this);
                replaceForm.Show();
                ReplaceFormShown = true;
            }
        }


        /// <summary>
        /// 以往下文查找的方式,在当前页里的富文本里寻找要查找的字符串,并用鼠标选择对应下标。
        /// </summary>
        /// <param name="value">要查找的字符串。</param>
        /// <param name="isMatchCase">指明是否区分大小写。</param>
        /// <param name="isRotated">指明是否循环。</param>
        /// <returns>如果找得到字符串,返回true;否则返回false。</returns>
        internal bool FindNextIndexOf(string value, bool isMatchCase, bool isRotated)
        {
            StringComparison stringComparison = 
                isMatchCase ? StringComparison.Ordinal : StringComparison.OrdinalIgnoreCase;
            RichTextBox richTextBox = notePadTabControl.GetSelectedRichTextBox();
            richTextBox.Focus();
            int startIndex = richTextBox.SelectionStart + richTextBox.SelectionLength;
            int indexOfValue;
            try
            {
                indexOfValue = richTextBox.Text.IndexOf(value, startIndex, stringComparison);
            }
            catch (ArgumentOutOfRangeException)
            {
                indexOfValue = -1;
            }

            if (indexOfValue != -1)
            {
                richTextBox.Select(indexOfValue, value.Length);
                return true;
            }
            else if (isRotated)
            {
                startIndex = 0;
                int count = richTextBox.SelectionStart + richTextBox.SelectionLength;
                try
                {
                    indexOfValue = richTextBox.Text.IndexOf(value, startIndex, count, stringComparison);
                }
                catch(ArgumentOutOfRangeException)
                {
                    indexOfValue = -1;
                }

                if (indexOfValue != -1)
                {
                    richTextBox.Select(indexOfValue, value.Length);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 以往上文查找的方式,在当前页里的富文本里寻找要查找的字符串,并用鼠标选择对应下标。
        /// </summary>
        /// <param name="value">要查找的字符串。</param>
        /// <param name="isMatchCase">指明是否区分大小写。</param>
        /// <param name="isRotated">指明是否循环。</param>
        /// <returns>如果找得到字符串,返回true;否则返回false。</returns>
        internal bool FindLastIndexOf(string value, bool isMatchCase, bool isRotated)
        {
            StringComparison stringComparison =
                isMatchCase ? StringComparison.Ordinal : StringComparison.OrdinalIgnoreCase;
            RichTextBox richTextBox = notePadTabControl.GetSelectedRichTextBox();
            richTextBox.Focus();

            int count = richTextBox.SelectionStart;
            int startIndex = count - 1;

            int lastIndexOfValue;
            try
            {
                lastIndexOfValue = richTextBox.Text.LastIndexOf(value, startIndex, count, stringComparison);
            }
            catch(ArgumentOutOfRangeException)
            {
                lastIndexOfValue = -1;
            }

            if (lastIndexOfValue != -1)
            {
                richTextBox.Select(lastIndexOfValue, value.Length);
                return true;
            }
            else if (isRotated)
            {
                startIndex = richTextBox.Text.Length - 1;
                count = richTextBox.Text.Length - richTextBox.SelectionStart;
                try
                {
                    lastIndexOfValue = richTextBox.Text.IndexOf(value, startIndex, count, stringComparison);
                }
                catch (ArgumentOutOfRangeException)
                {
                    lastIndexOfValue = -1;
                }
                if (lastIndexOfValue != -1)
                {
                    richTextBox.Select(lastIndexOfValue, value.Length);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        
        internal void ReplaceContent(string newValue)
        {
            RichTextBox richTextBox = notePadTabControl.GetSelectedRichTextBox();
            if (richTextBox.SelectionLength != 0)
            {
                notePadTabControl.GetSelectedRichTextBox().SelectedText = newValue;
            }
        }


        internal void ReplaceAllContent(string newValue, bool isMatchCase)
        {
            while(FindLastIndexOf(newValue, isMatchCase, false))
            {
                ReplaceContent(newValue);
            }
        }

        /// <summary>
        /// 弹出信息框并报告错误。
        /// </summary>
        /// <param name="owner">该信息框的父窗体。</param>
        /// <param name="errorMessage">错误信息。</param>
        internal void ShowContentNotFoundMessage(Form owner, string errorMessage)
        {
            MessageBox.Show(owner, errorMessage, "notepad", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
