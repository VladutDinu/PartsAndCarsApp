﻿using System;
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
using System.Collections.Specialized;
using System.Configuration;


namespace WindowsFormsApp4
{

    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
        
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
       
        }
     
        private bool verif()
        {
           SqlConnection sqc = new SqlConnection(connectionString);
           string query = "Select Count(*) From LoginTable where Username= '" + textBox1.Text + "' and Password ='" + textBox2.Text + "'";
           SqlDataAdapter sda = new SqlDataAdapter(query, sqc);
            DataTable dt = new DataTable();
           sda.Fill(dt);
           if (dt.Rows[0][0].ToString() == "1")
               return true;
            return false;
        }
        private bool verif_admin()
        {
            SqlConnection sqc = new SqlConnection(connectionString);
            string query = "Select Count(*) From LoginTable where Username= '" + textBox1.Text + "' and Password ='" + textBox2.Text + "' and role= 'admin'";
            SqlDataAdapter sda = new SqlDataAdapter(query, sqc);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
                return true;
            return false;
        }
        private void login()
        {
            if (verif()&&!verif_admin())
            {
                this.Hide();
                Main ss = new Main();
                ss.Show();

            }
            else if(verif()&&verif_admin())
            {
                this.Hide();
                MainAdmin ss = new MainAdmin();
                ss.Show();
                    
            }

        }
        private bool check()
        {
            if (textBox1.Text == "" || textBox2.Text == "")
                return false;
            return true;
        }
        private void register_login()
        {
            if (verif())
            {
                login();
                MessageBox.Show("Deja inregistrat");
            }
            else
            {
                SqlConnection sqc = new SqlConnection(connectionString);
                sqc.Open();
                SqlCommand cmd = new SqlCommand("insert into LoginTable (username,password) VALUES  (@username,@password)", sqc);
                cmd.Parameters.AddWithValue("@username", textBox1.Text);
                cmd.Parameters.AddWithValue("@password", textBox2.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Inregistrat");
                sqc.Close();
                login();
            }
         
        }
        private void button1_Click(object sender, EventArgs e)
        {   if (check())
                login();
            
            else MessageBox.Show("Nume/Parola invalida");
        }

        private void button2_Click(object sender, EventArgs e)
        {   if (check())
                register_login();
            else MessageBox.Show("Nume/Parola invalida");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
