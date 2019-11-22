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
    public partial class Form1 : Form
    {
        private int numberOfNewPage = 2;
        private Font font;
        public Form1()
        {
            InitializeComponent();
            font = new Font("Consolas", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);       
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }
    }
}
