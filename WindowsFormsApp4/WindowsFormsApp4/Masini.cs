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
namespace WindowsFormsApp4
{
    public partial class Masini : Form
    {
        string cs;
        string query;
        string n;
        private void add()
        {
            SqlCommand cmd;
            SqlConnection con;
            SqlDataAdapter da;
            cs = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\dinui\Desktop\proiect\DBS\Db.mdf;Integrated Security=True;Connect Timeout=30";
            query = "Select * from Masini_p";
            con = new SqlConnection(cs);
            cmd = new SqlCommand(query, con);
            da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                dataGridView1.Rows.Add(ds.Tables[0].Rows[i][0], ds.Tables[0].Rows[i][1], ds.Tables[0].Rows[i][2], ds.Tables[0].Rows[i][3], ds.Tables[0].Rows[i][5], ds.Tables[0].Rows[i][6], ds.Tables[0].Rows[i][4], ds.Tables[0].Rows[i][7], ds.Tables[0].Rows[i][8]);
            }

        }
        public Masini()
        {
            InitializeComponent();
            add();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Main m = new Main();
            m.Show();
        }
        private void DisplayData()
        {
            cs = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\dinui\Desktop\proiect\DBS\Db.mdf;Integrated Security=True;Connect Timeout=30";
            query = "Select * from Masini_p";
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            SqlCommand cmd;
            SqlConnection con;
            SqlDataAdapter da;

            con = new SqlConnection(cs);
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
            cs = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\dinui\Desktop\proiect\DBS\Db.mdf;Integrated Security=True;Connect Timeout=30";
            query = "DELETE From Masini_p where Id=@Id";
            SqlConnection con = new SqlConnection(cs);
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
