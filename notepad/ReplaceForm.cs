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


        private void ReplaceButton_Click(object sender, EventArgs e)
        {
            ((MainForm)Owner).ReplaceContent(replaceTextBox.Text);
        }


        private void ReplaceAllButton_Click(object sender, EventArgs e)
        {
            bool isMatchCase = false;
            if (matchCaseCheckBox.Checked == true)
            {
                isMatchCase = true;
            }
            ((MainForm)Owner).ReplaceAllContent(replaceTextBox.Text, isMatchCase);
        }


        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ReplaceForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ((MainForm)Owner).ReplaceFormShown = false;
        }

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
