using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;//for database
namespace Clinik_managment_system
{
    public partial class login : Form
    {
        SqlConnection con=null;
        SqlCommand cmd;

        public login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //new main_form().Show();
            try
            {
                string user, pass;
                //user = textBox1.Text;
                //pass = textBox2.Text;
                user = "karishma";
                pass = "Dembani";
                //if (user == "admin" && pass == "admin")
               // {
                    //MessageBox.Show("successful");
                    
                if ((textBox1.Text == user) && (textBox2.Text == pass))
                    {
                        MessageBox.Show("Welcome " + user + " !");
                        new main_form().Show();
                        this.Hide();
                    }
                
                    
                    else if (string.IsNullOrWhiteSpace(textBox1.Text))
                    {
                        MessageBox.Show("Please input proper Username...!");
                    }
                    else if (string.IsNullOrWhiteSpace(textBox2.Text))
                    {
                        MessageBox.Show("Please input proper Password...!");
                    }
                    
                    else if ((textBox1.Text != user) && (textBox2.Text != pass))
                    {
                        MessageBox.Show("Please input proper Username and/or Password...!");
                    }
                //    else if ((textBox1.Text != user) && (textBox2.Text != pass))
                //{
                //    MessageBox.Show("Please inter proper username and Password");

                //}
                    
                    //
                //}
                //else
                //{
                //    MessageBox.Show("error");
                //}
            }
            catch (Exception exec)
            {
                MessageBox.Show("Massage "+ exec);
            }
            //finally
            //{
            //    con.Close();
            //}
            
            
       
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
