using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace notepad
{
    public partial class ReplaceForm : Form
    {
        public ReplaceForm(MainForm owner)
        {
            InitializeComponent();
            Owner = owner;
            findNextButton.Enabled = replaceButton.Enabled = replaceAllButton.Enabled = false;
        }


        /// <summary>
        /// 点击"查找下一个"按钮时产生的事件处理。
        /// </summary>
        /// <param name="sender">事件的源。</param>
        /// <param name="e">事件信息。</param>
        private void FindNextButton_Click(object sender, EventArgs e)
        {
            bool isMatchCase = false;
            bool isRotated = true;
            if (matchCaseCheckBox.Checked == true)
            {
                isMatchCase = true;
            }
            if (rotateCheckBox.Checked == false)
            {
                isRotated = false;
            }
            if (!((MainForm)Owner).FindNextIndexOf(contentTextBox.Text, isMatchCase, isRotated))
            {
                ((MainForm)Owner).ShowContentNotFoundMessage(
                    this, string.Format("找不到\"{0}\"", contentTextBox.Text));
            }
        }


        /// <summary>
        /// 点击"替换"按钮时产生的事件处理。
        /// </summary>
        /// <param name="sender">事件的源。</param>
        /// <param name="e">事件信息。</param>
        private void ReplaceButton_Click(object sender, EventArgs e)
        {
            ((MainForm)Owner).ReplaceContent(replaceTextBox.Text);
        }


        /// <summary>
        /// 点击"全部替换"按钮时产生的事件处理。
        /// </summary>
        /// <param name="sender">事件的源。</param>
        /// <param name="e">事件信息。</param>
        private void ReplaceAllButton_Click(object sender, EventArgs e)
        {
            bool isMatchCase = false;
            if (matchCaseCheckBox.Checked == true)
            {
                isMatchCase = true;
            }
            ((MainForm)Owner).ReplaceAllContent(contentTextBox.Text, replaceTextBox.Text, isMatchCase);
        }


        /// <summary>
        /// 点击"取消"按钮时产生的事件处理。
        /// </summary>
        /// <param name="sender">事件的源。</param>
        /// <param name="e">事件信息。</param>
        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }


        /// <summary>
        /// 关闭窗口时产生的事件处理。
        /// </summary>
        /// <param name="sender">事件的源。</param>
        /// <param name="e">事件信息。</param>
        private void ReplaceForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ((MainForm)Owner).ReplaceFormShown = false;
        }


        /// <summary>
        /// 当文本框内容发生改变时产生的事件处理。
        /// </summary>
        /// <param name="sender">事件的源。</param>
        /// <param name="e">事件信息。</param>
        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox == contentTextBox)
            {
                if (contentTextBox.Text == string.Empty)
                {
                    findNextButton.Enabled = replaceButton.Enabled = replaceAllButton.Enabled = false;
                }
                else
                {
                    findNextButton.Enabled = true;
                    TextBox_TextChanged(replaceTextBox, e);
                }
            }
            else if (textBox == replaceTextBox)
            {
                if (findNextButton.Enabled == true)
                {
                    if (replaceTextBox.Text != string.Empty)
                    {
                        replaceButton.Enabled = replaceAllButton.Enabled = true;
                    }
                    else
                    {
                        replaceButton.Enabled = replaceAllButton.Enabled = false;
                    }
                }
                else
                {
                    replaceButton.Enabled = replaceAllButton.Enabled = false;
                }
            }
        }
    }
}
