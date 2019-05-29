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
   
    public partial class Search : MetroFramework.Forms.MetroForm
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
        string query;
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
                    c.Id = Convert.ToInt32(rdr[0]);
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
        private void add(string qrr)
        {
            getData(qrr);
            for (int i = 0; i < cd.Count(); i++)
            {
                dataGridView1.Rows.Add(cd[i].Id, cd[i].Marca, cd[i].Capacitate, cd[i].Km, cd[i].Pret, cd[i].Combustibil, cd[i].An, cd[i].Descriere, cd[i].CodSasiu);
            }
        }
        Form m;
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
        public Search(Form fereastraInitiala)
        {   
            InitializeComponent();
            this.m = fereastraInitiala;
            comboBox1.Items.Add("");
            comboBox5.Items.Add("");
            comboBox4.Items.Add("");
            comboBox2.Items.Add("");

            string[] lines = System.IO.File.ReadAllLines(System.AppDomain.CurrentDomain.BaseDirectory + "marca.txt");
            foreach (string line in lines)
            {
                comboBox1.Items.Add(line);
            }
            string[] lines1 = System.IO.File.ReadAllLines(System.AppDomain.CurrentDomain.BaseDirectory + "capacitate.txt");
            foreach (string line in lines1)
            {
                comboBox2.Items.Add(line);
                comboBox4.Items.Add(line);
            }
            string[] lines2 = System.IO.File.ReadAllLines(System.AppDomain.CurrentDomain.BaseDirectory + "combustibil.txt");
            foreach (string line in lines2)
            {
                comboBox5.Items.Add(line);
            }
            
            add("Select * From Masini Order By Id DESC");
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox5.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox4.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        public bool verifyKm(TextBox a, TextBox b)
        {
            if (a.Text != "" && b.Text != "")
                if (Convert.ToInt32(a.Text) > Convert.ToInt32(b.Text))
                return true;
            return false;
        }
        public bool verifyPret(TextBox a, TextBox b)
        {
            if (a.Text != "" && b.Text != "")
                if (Convert.ToInt32(a.Text) > Convert.ToInt32(b.Text))
                return true;
            return false;
        }
        public bool verifyAn(TextBox a, TextBox b)
        {
            if (a.Text != "" && b.Text != "")
                if (Convert.ToInt32(a.Text) > Convert.ToInt32(b.Text))
                return true;
            return false;
        }
        public bool verifyCap(ComboBox a, ComboBox b)
        {   if(a.Text!="" && b.Text!="")
                if (Convert.ToDouble(a.SelectedItem) > Convert.ToDouble(b.SelectedItem))
                 return true;
            return false;
        }
        public bool verify()
        {
            if (!verifyCap(comboBox4,comboBox2) && !verifyAn(textBox5, textBox6) && !verifyPret(textBox1, textBox2) && !verifyKm(textBox3,textBox4))
                return true;
            else return false;
        }
        
        private string check()
        {
            query = "Select * from Masini";
            if (comboBox1.SelectedIndex  > 0 )
                if(!query.Contains("where"))
                query += " where Marca ='" + comboBox1.SelectedItem + "'";
            else query += " and Marca ='" + comboBox1.SelectedItem + "'";

            if (comboBox2.SelectedIndex  > 0 && comboBox4.SelectedIndex  > 0)
                if (!query.Contains("where")) 
                    query += " where Capacitate BETWEEN '" + Convert.ToDouble(comboBox4.SelectedItem) + "' AND  '" + Convert.ToDouble(comboBox2.SelectedItem) + "'";
                else query += " and Capacitate BETWEEN '" + Convert.ToDouble(comboBox4.SelectedItem) + "' AND '" + Convert.ToDouble(comboBox2.SelectedItem) + "'";
            else if (comboBox2.SelectedIndex  > 0)
                if (!query.Contains("where"))
                    query += " where Capacitate <= '" + Convert.ToDouble(comboBox2.SelectedItem) + "'";
                else query += " and Capacitate <='" + Convert.ToDouble(comboBox2.SelectedItem) + "'";
            else if (comboBox4.SelectedIndex > 0)
                if (!query.Contains("where"))
                    query += " where Capacitate >='" + Convert.ToDouble(comboBox4.SelectedItem) + "'";
                else query += " and Capacitate >='" + Convert.ToDouble(comboBox4.SelectedItem) + "'";

            if (comboBox5.SelectedIndex  > 0)
                if (!query.Contains("where"))
                    query += " where Combustibil = '" + comboBox5.SelectedItem + "'";
            else query += " and Combustibil = '" + comboBox5.SelectedItem + "'";

            if (textBox3.Text != "" && textBox4.Text != "")
                if (!query.Contains("where"))
                    query += " where Km BETWEEN '" + Convert.ToInt32(textBox3.Text) + "' AND  '" + Convert.ToInt32(textBox4.Text) + "'";
                else query += " and Km BETWEEN '" + Convert.ToInt32(textBox3.Text) + "' AND '" + Convert.ToInt32(textBox4.Text) + "'";
            else if (textBox4.Text != "")
                if (!query.Contains("where"))
                    query += " where Km <= '" + Convert.ToInt32(textBox4.Text) + "'";
                else query += " and Km <='" + Convert.ToInt32(textBox4.Text) + "'";
            else if (textBox3.Text != "")
                if (!query.Contains("where"))
                    query += " where Km >='" + Convert.ToInt32(textBox3.Text) + "'";
                else query += " and Km >='" + Convert.ToInt32(textBox3.Text) + "'";

            if (textBox1.Text != "" && textBox2.Text != "")
                if (!query.Contains("where"))
                    query += " where Pret BETWEEN '" + Convert.ToInt32(textBox1.Text) + "' AND  '" + Convert.ToInt32(textBox2.Text) + "'";
                else query += " and Pret BETWEEN '" + Convert.ToInt32(textBox1.Text) + "' AND '" + Convert.ToInt32(textBox2.Text) + "'";
            else if (textBox2.Text != "")
                if (!query.Contains("where"))
                    query += " where Pret <= '" + Convert.ToInt32(textBox2.Text) + "'";
                else query += " and Pret <='" + Convert.ToInt32(textBox2.Text) + "'";
            else if (textBox1.Text != "")
                if (!query.Contains("where"))
                    query += " where Pret >='" + Convert.ToInt32(textBox1.Text) + "'";
                else query += " and Pret >='" + Convert.ToInt32(textBox1.Text) + "'";

            if (textBox5.Text != "" && textBox6.Text != "")
                if (!query.Contains("where"))
                    query += " where An BETWEEN '" + Convert.ToInt32(textBox5.Text) + "' AND  '" + Convert.ToInt32(textBox6.Text) + "'";
                else query += " and An BETWEEN '" + Convert.ToInt32(textBox5.Text) + "' AND '" + Convert.ToInt32(textBox6.Text) + "'";
            else if (textBox6.Text != "")
                if (!query.Contains("where"))
                    query += " where An <= '" + Convert.ToInt32(textBox6.Text) + "'";
                else query += " and An <='" + Convert.ToInt32(textBox6.Text) + "'";
            else if (textBox5.Text != "")
                if (!query.Contains("where"))
                    query += " where An >='" + Convert.ToInt32(textBox5.Text) + "'";
                else query += " and An >='" + Convert.ToInt32(textBox5.Text) + "'";
            return query;

        }
        private void search_m()
        {
            getData(check());
            for (int i = 0; i < cd.Count(); i++)
            {
                dataGridView1.Rows.Add(cd[i].Id, cd[i].Marca, cd[i].Capacitate, cd[i].Km, cd[i].Pret, cd[i].Combustibil, cd[i].An, cd[i].Descriere, cd[i].CodSasiu);
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (verify())
            {
                cd.RemoveRange(0, cd.Count());
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                search_m();
            }
            else
                MessageBox.Show("Filtre gresite");
            
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
    
        private void buy()
        {
            query = "DELETE From Masini where Id=" + dataGridView1.CurrentRow.Cells[0].Value.ToString();
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            cd.RemoveRange(0, cd.Count());

        }
        private void button3_Click(object sender, EventArgs e)
        {
            buy();
            add("Select * from Masini");
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
            cd.RemoveRange(0, cd.Count());
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            add(query);
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

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}