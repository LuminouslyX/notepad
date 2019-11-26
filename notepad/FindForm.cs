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
    public partial class FindForm : Form
    {
        public FindForm(MainForm mainForm)
        {
            InitializeComponent();
            Owner = mainForm;
            findNextButton.Enabled = false;
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
            if (upRadioButton.Checked)
            {
                if (!((MainForm)Owner).FindLastIndexOf(textBox.Text, isMatchCase, isRotated))
                {
                    ((MainForm)Owner).ShowContentNotFoundMessage(
                        this, string.Format(("找不到\"{0}\""), textBox.Text));
                }
            }
            else
            {
                if (!((MainForm)Owner).FindNextIndexOf(textBox.Text, isMatchCase, isRotated))
                {
                    ((MainForm)Owner).ShowContentNotFoundMessage(
                        this, string.Format(("找不到\"{0}\""), textBox.Text));
                }
            }
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
        /// 当查找内容的文本框的内容发生改变时产生的事件处理。
        /// </summary>
        /// <param name="sender">事件的源。</param>
        /// <param name="e">事件信息。</param>
        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text == string.Empty)
                findNextButton.Enabled = false;
            else
                findNextButton.Enabled = true;
        }


        /// <summary>
        /// 关闭窗口时产生的事件处理。
        /// </summary>
        /// <param name="sender">事件的源。</param>
        /// <param name="e">事件信息。</param>
        private void FindForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ((MainForm)Owner).FindFormShown = false;
        }
    }
}
