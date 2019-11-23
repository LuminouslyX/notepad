using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
