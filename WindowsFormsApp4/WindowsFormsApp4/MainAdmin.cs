using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class MainAdmin : Form
    {
        public MainAdmin()
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
            Piese p = new Piese();
            p.Show();
        }

      

        private void adaugaMasinaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddCar a = new AddCar();
            a.Show();
        }

        private void masiniToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Masini m = new Masini();
            m.Show();
        }
    }
}
