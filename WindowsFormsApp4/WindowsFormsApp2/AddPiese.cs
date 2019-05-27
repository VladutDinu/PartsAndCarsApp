using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace WindowsFormsApp2
{
    public partial class AddPiese : MetroFramework.Forms.MetroForm
    {
        public AddPiese()
        {
            InitializeComponent();
        }

        static string connectionString = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
        private void AddPiese_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private bool verifT(TextBox a)
        {
            if (a.Text == "")
                return false;
            return true;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (!verifT(textBox1) || !verifT(textBox2) || !verifT(textBox3))
                MessageBox.Show("Campuri necompletate.");
            else
            {
                SqlConnection sqc = new SqlConnection(connectionString);
                sqc.Open();
                SqlCommand cmd = new SqlCommand("insert into Piese (Producator , Pret , Material , Descriere) VALUES (@Producator , @Pret , @Material , @Descriere)", sqc);
                cmd.Parameters.AddWithValue("@Producator", textBox1.Text);
                cmd.Parameters.AddWithValue("@Pret", textBox2.Text);
                cmd.Parameters.AddWithValue("@Material", textBox3.Text);
                cmd.Parameters.AddWithValue("@Descriere", textBox4.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Inregistrat!");
                sqc.Close();
                textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = "";
            }
        }

       
    }
}
