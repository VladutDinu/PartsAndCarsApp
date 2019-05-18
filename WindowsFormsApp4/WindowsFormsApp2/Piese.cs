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

namespace WindowsFormsApp2
{
    public partial class Piese : MetroFramework.Forms.MetroForm
    {
        Form m;
        static string connectionString = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
        string query;
        public List<PartsInfo> cd = new List<PartsInfo>();
         
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
                    PartsInfo c = new PartsInfo();
                    c.id = Convert.ToInt32(rdr[0]);
                    c.Producator = rdr[1].ToString();
                    c.Pret = rdr[2].ToString();
                    c.Material = rdr[3].ToString();
                    c.Descriere = rdr[4].ToString();
                    cd.Add(c);
                }
            }
            con.Close();
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
        private void add()
        {
            query = "Select * from Piese";
            getData(query);
            for (int i = 0; i < cd.Count(); i++)
            {
                dataGridView1.Rows.Add(cd[i].id, cd[i].Producator, cd[i].Pret, cd[i].Material, cd[i].Descriere);
            }
        }
        public Piese(Form fereastraInitiala)
        {
            InitializeComponent();
            this.m = fereastraInitiala;
            sortByNew();
            add();
        }
        private void buy()
        {
            query = "DELETE From Piese where Id=@Id";
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

        private void button2_Click(object sender, EventArgs e)
        {
            buy();
            add();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            m.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Piese_Load(object sender, EventArgs e)
        {

        }
    }
}
