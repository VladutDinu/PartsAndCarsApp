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
        int count;
        private void getData()
        {
            SqlCommand cmd;
            SqlConnection con;
            con = new SqlConnection(connectionString);
            con.Open();
            cmd = new SqlCommand("Select * from Masini", con);
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                int i = 0;
                while (rdr.Read())
                {
                    i++;
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
        private void add()
        {
            getData();
            SqlCommand cmd;
            SqlConnection con;
            SqlDataAdapter da;
           
            query = "Select * from Masini";
            con = new SqlConnection(connectionString);
            cmd = new SqlCommand(query, con);
            da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            count = ds.Tables[0].Rows.Count;
            for(int i=0;i<count;i++)
            {
                dataGridView1.Rows.Add(cd[i].id, cd[i].Marca, cd[i].Capacitate, cd[i].Km, cd[i].Pret, cd[i].Combustibil, cd[i].An, cd[i].Descriere, cd[i].CodSasiu);
            }
        }
     
        public Masini(Form fereastraInitiala)
        {
            InitializeComponent();
            this.m = fereastraInitiala;
            add();
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            m.Show();
        }
        private void DisplayData()
        {
            query = "Select * from Masini";
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            SqlCommand cmd;
            SqlConnection con;
            SqlDataAdapter da;

            con = new SqlConnection(connectionString);
            cmd = new SqlCommand(query, con);
            da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                dataGridView1.Rows.Add(ds.Tables[0].Rows[i][0], ds.Tables[0].Rows[i][1], ds.Tables[0].Rows[i][2], ds.Tables[0].Rows[i][3], ds.Tables[0].Rows[i][5], ds.Tables[0].Rows[i][6], ds.Tables[0].Rows[i][4], ds.Tables[0].Rows[i][7], ds.Tables[0].Rows[i][8]);
            }
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
            DisplayData();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            buy();
        }

        private void Masini_Load(object sender, EventArgs e)
        {

        }
    }
}
