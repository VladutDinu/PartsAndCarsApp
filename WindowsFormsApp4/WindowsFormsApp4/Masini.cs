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
using System.Collections.Specialized;
using System.Configuration;

namespace WindowsFormsApp4
{
    public partial class Masini : MetroFramework.Forms.MetroForm
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
        string query;
        Form m;
        
        public List<CarsInfo> cd = new List<CarsInfo>();
         
        private void getData(string cs)
        {
            SqlCommand cmd;
            SqlConnection con;
            con = new SqlConnection(connectionString);
            con.Open();
            cmd = new SqlCommand(cs, con);
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                while (rdr.Read())
                {
                    CarsInfo c = new CarsInfo();
                    c.id = Convert.ToInt32(rdr[0]);
                    c.Marca = rdr[1].ToString();
                    c.Capacitate = rdr[2].ToString();
                    c.Km = rdr[3].ToString();
                    c.Pret = rdr[4].ToString();
                    c.Combustibil = rdr[5].ToString();
                    c.An = rdr[6].ToString();
                    c.Descriere = rdr[7].ToString();
                    c.CodSasiu = rdr[8].ToString();
                    cd.Add(c);
                }
            }
            con.Close();
        }
        private void add(string cs)
        {
            
            getData(cs);
            for (int i = 0; i < cd.Count(); i++)
            {
                dataGridView1.Rows.Add(cd[i].id, cd[i].Marca, cd[i].Capacitate, cd[i].Km, cd[i].Pret, cd[i].Combustibil, cd[i].An, cd[i].Descriere, cd[i].CodSasiu);
            }

        }

        public Masini(Form fereastraInitiala)
        {
            InitializeComponent();
            this.m = fereastraInitiala;
            sortByNew();
            add("Select * from Masini");
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            m.Show();
        }
        private void sortByNew()
        {
            query = "Select * From Masini Order By Id DESC";
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        private void buy()
        {
            query = "DELETE From Masini where Id=@Id";
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            cmd.Parameters.AddWithValue("@Id", dataGridView1.CurrentRow.Cells[0].Value.ToString());
            cmd.ExecuteNonQuery();
            con.Close();
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            cd.RemoveRange(0, cd.Count());
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            buy();
            add(query);
        }
        public void sortBy(string c)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(c, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            cd.RemoveRange(0, cd.Count());
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
        }
        private void Masini_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            sortBy("Select * From Masini Order By Pret ASC");
            add("Select * From Masini Order By Pret ASC");
        }

        private void label1_Click(object sender, EventArgs e)
        {
            sortBy("Select * From Masini Order By Id DESC");
            add("Select * From Masini Order By Id DESC");
        }

        private void label3_Click(object sender, EventArgs e)
        {
            sortBy("Select * From Masini Order By Pret DESC");
            add("Select * From Masini Order By Pret DESC");
        }
    }
}
