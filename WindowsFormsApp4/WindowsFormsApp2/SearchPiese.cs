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
        private void add()
        {
            query = "Select * from Piese";
            getData(query);
            for (int i = 0; i < cd.Count(); i++)
            {
                dataGridView1.Rows.Add(cd[i].id, cd[i].Producator, cd[i].Material, cd[i].Pret, cd[i].Descriere);
            }
        }
        Form m;

        private void sortByNew()
        {
            query = "Select * From Piese Order By Id DESC";
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public SearchPiese(Form fereastraInitiala)
        {
            InitializeComponent();
            this.m = fereastraInitiala;
            comboBox1.Items.Add("");
            comboBox2.Items.Add("");
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
            sortByNew();
            add();
        }
        public bool verify(TextBox a,TextBox b)
        {   if(a.Text!="" && b.Text!="")
                if (Convert.ToInt32(a.Text) > Convert.ToInt32(b.Text))
                 return true;
            return false;
        }
        private string check()
        {
            query = "Select * from Piese ";
            if (comboBox1.SelectedIndex >0 )
                if (!query.Contains("where"))
                    query += " where Producator ='" + comboBox1.SelectedItem + "'";
                else query += " and Producator ='" + comboBox1.SelectedItem + "'";
            if (comboBox2.SelectedIndex >0 )
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
            return query;
        }

        private void search_m()
        {
            getData(check());
            for (int i = 0; i < cd.Count(); i++)
                {
                dataGridView1.Rows.Add(cd[i].id, cd[i].Producator, cd[i].Material, cd[i].Pret, cd[i].Descriere);
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
                cd.RemoveRange(0, cd.Count());
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
        private void buy()
        {

            query = "DELETE From Piese where Id=@Id";
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            cmd.Parameters.AddWithValue("@id", dataGridView1.CurrentRow.Cells[0].Value.ToString());
            cmd.ExecuteNonQuery();
            con.Close();
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            cd.RemoveRange(0, cd.Count());
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
            cd.RemoveRange(0, cd.Count());
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            add();
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

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8 && ch != 46)
                e.Handled = true;
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8 && ch != 46)
                e.Handled = true;
        }
    }
}