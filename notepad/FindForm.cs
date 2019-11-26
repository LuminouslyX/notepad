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

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
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

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text == string.Empty)
                findNextButton.Enabled = false;
            else
                findNextButton.Enabled = true;
        }

        private void FindForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ((MainForm)Owner).FindFormShown = false;
        }
    }
}
