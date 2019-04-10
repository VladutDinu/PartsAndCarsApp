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
   
    public partial class Search : Form
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
        string query;
      
        private void add()
        {
            SqlCommand cmd;
            SqlConnection con;
            SqlDataAdapter da;
           
            query = "Select * from Masini";
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
        Form m;
        public Search(Form fereastraInitiala)
        {   
            InitializeComponent();
            this.m = fereastraInitiala;
            string[] lines = System.IO.File.ReadAllLines(@".\txt\marca.txt");
            foreach (string line in lines)
            {
                comboBox1.Items.Add(line);
            }
            string[] lines1 = System.IO.File.ReadAllLines(@".\txt\capacitate.txt");
            foreach (string line in lines1)
            {
                comboBox2.Items.Add(line);
                comboBox4.Items.Add(line);
            }
            string[] lines2 = System.IO.File.ReadAllLines(@".\txt\combustibil.txt");
            foreach (string line in lines2)
            {
                comboBox5.Items.Add(line);
            }
            add();
        }
        private void check()
        {
            query = "Select * from Masini";
            if (comboBox1.SelectedIndex != -1 )
                if(!query.Contains("where"))
                query += " where Marca ='" + comboBox1.SelectedItem + "'";
            else query += " and Marca ='" + comboBox1.SelectedItem + "'";
            if (comboBox2.SelectedIndex != -1 && comboBox4.SelectedIndex != -1)
                if (!query.Contains("where"))
                    query += " where Capacitate BETWEEN '" + comboBox4.SelectedItem + "' AND  '" + comboBox2.SelectedItem + "'";
                else query += " and Capacitate BETWEEN '" + comboBox4.SelectedItem + "' AND '" + comboBox2.SelectedItem + "'";
            else if (comboBox2.SelectedIndex != -1)
                if (!query.Contains("where"))
                    query += " where Capacitate <= '" + comboBox2.SelectedItem + "'";
                else query += " and Capacitate <='" + comboBox2.SelectedItem + "'";
            else if (comboBox4.SelectedIndex != -1)
                if (!query.Contains("where"))
                    query += " where Capacitate >='" + comboBox4.SelectedItem + "'";
                else query += " and Capacitate >='" + comboBox4.SelectedItem + "'";
            if (comboBox5.SelectedIndex != -1)
                if (!query.Contains("where"))
                    query += " where Combustibil = '" + comboBox5.SelectedItem + "'";
            else query += " and Combustibil = '" + comboBox5.SelectedItem + "'";

            if (textBox3.Text != "" && textBox4.Text != "")
                if (!query.Contains("where"))
                    query += " where Km BETWEEN '" + textBox3.Text + "' AND  '" + textBox4.Text + "'";
                else query += " and Km BETWEEN '" + textBox3.Text + "' AND '" + textBox4.Text + "'";
            else if (textBox4.Text != "")
                if (!query.Contains("where"))
                    query += " where Km <= '" + textBox4.Text + "'";
                else query += " and Km <='" +  textBox4.Text + "'";
            else if (textBox3.Text != "")
                if (!query.Contains("where"))
                    query += " where Km >='" + textBox3.Text + "'";
                else query += " and Km >='" + textBox3.Text + "'";

            if (textBox1.Text != "" && textBox2.Text != "")
                if (!query.Contains("where"))
                    query += " where Pret BETWEEN '" + textBox1.Text + "' AND  '" + textBox2.Text + "'";
                else query += " and Pret BETWEEN '" + textBox1.Text + "' AND '" + textBox2.Text + "'";
            else if (textBox2.Text != "")
                if (!query.Contains("where"))
                    query += " where Pret <= '" + textBox2.Text + "'";
                else query += " and Pret <='" + textBox2.Text + "'";
            else if (textBox1.Text != "")
                if (!query.Contains("where"))
                    query += " where Pret >='" + textBox1.Text + "'";
                else query += " and Pret >='" + textBox1.Text + "'";

            if (textBox5.Text != "" && textBox6.Text != "")
                if (!query.Contains("where"))
                    query += " where An BETWEEN '" + textBox5.Text + "' AND  '" + textBox6.Text + "'";
                else query += " and An BETWEEN '" + textBox5.Text + "' AND '" + textBox6.Text + "'";
            else if (textBox6.Text != "")
                if (!query.Contains("where"))
                    query += " where An <= '" + textBox6.Text + "'";
                else query += " and An <='" + textBox6.Text + "'";
            else if (textBox5.Text != "")
                if (!query.Contains("where"))
                    query += " where An >='" + textBox5.Text + "'";
                else query += " and An >='" + textBox5.Text + "'";

        }
        private void search_m()
        {
            query = "Select * from Masini";
            
            check();
            
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
        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            search_m();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            m.Show();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void DisplayData()
        {
           
            query = "Select * from Masini where Marca='" + comboBox1.SelectedItem + "' and Capacitate='" + comboBox2.SelectedItem + "'";
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
            cmd.Parameters.AddWithValue("@id", dataGridView1.CurrentRow.Cells[0].Value.ToString());
            cmd.ExecuteNonQuery();
            con.Close();
            DisplayData();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            buy();
            add();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void Search_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
         
        }

        private void label2_Click(object sender, EventArgs e)
        {
            query = "Select * from Masini";
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            comboBox4.SelectedIndex = -1;
            comboBox5.SelectedIndex = -1;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
    }

  
}