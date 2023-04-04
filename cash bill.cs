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
namespace Clinik_managment_system
{
    public partial class Form7 : Form
    {
        SqlConnection con = new SqlConnection("Data Source=VAIO; User Id=sa; Password=123; Database=CMS");
        SqlCommand cmd = null;
        SqlDataReader reader = null;
        public Form7()
        {
            InitializeComponent();
            getAllBills();
        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            new PatientHistory().Show();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form7_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            new ViewPatient().Show();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            this.Hide();
        }


        public void getAllBills() {
            try
            {
                con.Open();
                cmd = new SqlCommand("select * from Cach_bill", con);
                reader = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(reader);
                if (dt.Rows.Count >= 1)
                    dataGridView2.DataSource = dt;
                else
                    MessageBox.Show("No Record Founds");

            }
            catch (Exception exe)
            {
                MessageBox.Show("Message : " + exe.Message);
            }
            finally
            {
                con.Close();
            }
        
        
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
           try
            {
                con.Open();
                cmd = new SqlCommand("insert into Cach_bill(Name,DOB,Email,Gender,City,Marital_Status,Mobile,House_tell,Occupation,Status,Cash,Remarks) values('" + TxtName.Text + "','" + DTPDOB.Text + "','" + TxtEmail.Text + "','" + CbSex.SelectedItem.ToString() + "','" + TxtCity.Text + "','" + CbMS.SelectedItem.ToString() + "','" + TxtMob.Text + "','" + TxtHouse.Text + "','" + TxtO.Text + "',1,'" + textBox15.Text + "','" + textBox1.Text + "')", con);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Payment Added");
                }
            }
            catch (Exception exe)
            {
                MessageBox.Show("Message : " + exe.Message);
            }
            finally
            {
                con.Close();
            }

        }
        
        }
    }

