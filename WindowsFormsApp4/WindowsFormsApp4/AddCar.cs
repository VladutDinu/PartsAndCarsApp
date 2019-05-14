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

namespace WindowsFormsApp4
{
    public partial class AddCar : MetroFramework.Forms.MetroForm
    {
        public AddCar()
        {
            InitializeComponent();
        }
      static string connectionString = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;

        private void AddCar_Load(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection sqc = new SqlConnection(connectionString);
            sqc.Open();
            SqlCommand cmd = new SqlCommand("insert into Masini (Marca, Capacitate, An, Km, Combustibil, Pret, Descriere, CodSasiu) VALUES  (@Marca, @Capacitate, @An, @Km, @Combustibil, @Pret, @Descriere, @CodSasiu)", sqc);
            cmd.Parameters.AddWithValue("@Marca", textBox1.Text);
            cmd.Parameters.AddWithValue("@Capacitate", textBox2.Text);
            cmd.Parameters.AddWithValue("@An", textBox5.Text);
            cmd.Parameters.AddWithValue("@Km", textBox4.Text);
            cmd.Parameters.AddWithValue("@Combustibil", textBox3.Text);
            cmd.Parameters.AddWithValue("@Pret", textBox6.Text);
            cmd.Parameters.AddWithValue("@Descriere", textBox7.Text);
            cmd.Parameters.AddWithValue("@CodSasiu", textBox8.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Inregistrat");
            sqc.Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
