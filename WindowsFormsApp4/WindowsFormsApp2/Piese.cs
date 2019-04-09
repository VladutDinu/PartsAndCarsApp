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
    public partial class Piese : Form
    {
        Form m;
        static string connectionString = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
        string query;
        string n;
        private void add()
        {
            SqlCommand cmd;
            SqlConnection con;
            SqlDataAdapter da;
          

            query = "Select * from Piese";
            con = new SqlConnection(connectionString);
            cmd = new SqlCommand(query, con);
            da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                dataGridView1.Rows.Add(ds.Tables[0].Rows[i][0], ds.Tables[0].Rows[i][1], ds.Tables[0].Rows[i][2], ds.Tables[0].Rows[i][3], ds.Tables[0].Rows[i][4]);
            }
        }
        public Piese(Form fereastraInitiala)
        {
            InitializeComponent();
            this.m = fereastraInitiala;
            add();
        }

        private void DisplayData ()
        {
          

            query = "Select * from Piese";
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
            for (int i = 0; i< ds.Tables[0].Rows.Count; i++)
            {
                dataGridView1.Rows.Add(ds.Tables[0].Rows[i][0], ds.Tables[0].Rows[i][1], ds.Tables[0].Rows[i][2], ds.Tables[0].Rows[i][3], ds.Tables[0].Rows[i][4]);
            }

        }

        private void  buy()
        {
         

            query = "DELETE From Piese where Id=@Id";
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            cmd.Parameters.AddWithValue("@Id", dataGridView1.CurrentRow.Cells[0].Value.ToString());
            cmd.ExecuteNonQuery();
            con.Close();
            DisplayData();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            buy();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            m.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
