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
    public partial class SearchPiese : MetroFramework.Forms.MetroForm
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
        string query;
        public List<PartsInfo> cd = new List<PartsInfo>();
        int count;
        private void getData()
        {
            SqlCommand cmd;
            SqlConnection con;
            con = new SqlConnection(connectionString);
            con.Open();
            cmd = new SqlCommand("Select * from Piese", con);
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                int i = 0;
                while (rdr.Read())
                {
                    i++;
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
        private void add()
        {
            getData();
            SqlCommand cmd;
            SqlConnection con;
            SqlDataAdapter da;


            query = "Select * from Piese";
            con = new SqlConnection(connectionString);
            cmd = new SqlCommand(query, con);
            da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            count = ds.Tables[0].Rows.Count;
            for (int i = 0; i < count; i++)
            {
                dataGridView1.Rows.Add(cd[i].id, cd[i].Producator, cd[i].Material, cd[i].Pret, cd[i].Descriere);
            }
        }
        Form m;


        public SearchPiese(Form fereastraInitiala)
        {
            InitializeComponent();
            this.m = fereastraInitiala;
            string[] lines = System.IO.File.ReadAllLines(System.AppDomain.CurrentDomain.BaseDirectory + "producator.txt");
            foreach (string cuvant in lines )
            {
                string[] words = cuvant.Split(' ');
                foreach (string line in words)
                {

                    comboBox1.Items.Add(line);
                }
            }
          
            
            string[] lines1 = System.IO.File.ReadAllLines(System.AppDomain.CurrentDomain.BaseDirectory + "material.txt");
            foreach (string cuvant in lines1)
            {
                string[] words = cuvant.Split(' ');
                foreach (string line in words)
                {

                    comboBox2.Items.Add(line);
                }
            }
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            add();
        }
        public bool verify(TextBox a,TextBox b)
        {   if(a.Text!="" && b.Text!="")
                if (Convert.ToInt32(a.Text) > Convert.ToInt32(b.Text))
                 return true;
            return false;
        }
        private void check()
        {
            query = "Select * from Piese ";
            if (comboBox1.SelectedIndex != -1)
                if (!query.Contains("where"))
                    query += " where Producator ='" + comboBox1.SelectedItem + "'";
                else query += " and Producator ='" + comboBox1.SelectedItem + "'";
            if (comboBox2.SelectedIndex != -1)
                if (!query.Contains("where"))
                    query += " where Material ='" + comboBox2.SelectedItem + "'";
                else query += " and Material ='" + comboBox2.SelectedItem + "'";


            if (textBox3.Text != "" && textBox4.Text != "")
                    if (!query.Contains("where"))
                        query += " where Pret BETWEEN '" + Convert.ToInt32(textBox3.Text) + "' AND  '" + Convert.ToInt32(textBox4.Text) + "'";
                    else query += " and Pret BETWEEN '" + Convert.ToInt32(textBox3.Text) + "' AND '" + Convert.ToInt32(textBox4.Text) + "'";
            else if (textBox4.Text != "")
                if (!query.Contains("where"))
                    query += " where Pret <= '" + Convert.ToInt32(textBox4.Text) + "'";
                else query += " and Pret <='" + Convert.ToInt32(textBox4.Text) + "'";
            else if (textBox3.Text != "")
                if (!query.Contains("where"))
                    query += " where Pret >='" + Convert.ToInt32(textBox3.Text) + "'";
                else query += " and Pret >='" + Convert.ToInt32(textBox3.Text) + "'";
        }

        private void search_m()
        {
            query = "Select * from Piese ";
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
                    dataGridView1.Rows.Add(ds.Tables[0].Rows[i][0], ds.Tables[0].Rows[i][1], ds.Tables[0].Rows[i][3], ds.Tables[0].Rows[i][2], ds.Tables[0].Rows[i][4]);
                }
            

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //cautare
            if (!verify(textBox3, textBox4))
            {
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                search_m();
            }
            else MessageBox.Show("Filtre gresite");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //inapoi
            this.Close();
            m.Show();
        }

        private void DisplayData()
        {

            query = "Select * from Piese where Producator='" + comboBox1.SelectedItem + "' and Material='" + comboBox2.SelectedItem + "'";
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
               dataGridView1.Rows.Add(ds.Tables[0].Rows[i][0], ds.Tables[0].Rows[i][1], ds.Tables[0].Rows[i][2], ds.Tables[0].Rows[i][3], ds.Tables[0].Rows[i][4]);
            }
        }

        private void buy()
        {

            query = "DELETE From Piese where Id=@Id";
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
            //cumpara
            buy();
            add();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Reset filtre
            query = "Select * from Piese";
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            textBox3.Text = "";
            textBox4.Text = "";
        }

        private void label1_Click(object sender, EventArgs e)
        {
            //producator
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //omboBox producator
        }

        private void label2_Click(object sender, EventArgs e)
        {
            //material
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //combobox material
        }

        private void label3_Click(object sender, EventArgs e)
        {
            //pret de la
        }


        private void label4_Click(object sender, EventArgs e)
        {
            //pret pana la 
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //textbox pret pana la
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //textbox pret pana la
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}