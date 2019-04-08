using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp2;

namespace WindowsFormsApp4
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Search s = new Search();
            s.Show();
        }

        private void pieseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            WindowsFormsApp2.Piese p = new WindowsFormsApp2.Piese(this);
            p.Show();
            this.Hide();
           
        }

        private void masiniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Masini m = new Masini();
            m.Show();
        }
    }
}
