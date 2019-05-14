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
    public partial class MainAdmin : MetroFramework.Forms.MetroForm
    {
        public MainAdmin()
        {
            InitializeComponent();
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Search s = new Search(this);
            s.Show();
        }

        private void pieseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            WindowsFormsApp2.Piese p = new WindowsFormsApp2.Piese(this);
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
            Masini m = new Masini(this);
            m.Show();
        }

        private void pieseToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            WindowsFormsApp2.Piese p = new WindowsFormsApp2.Piese(this);
            p.Show();
            
        }

        private void adaugaPiesaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddPiese ap = new AddPiese();
            ap.Show();
        }
		
        private void MainAdmin_Load(object sender, EventArgs e)
        {

        }

        private void searchPiesaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            WindowsFormsApp2.SearchPiese s = new WindowsFormsApp2.SearchPiese(this);
            s.Show();
        }
    }
}
