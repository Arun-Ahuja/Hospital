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
    public partial class appointment : Form
    {
         SqlConnection con = new SqlConnection("Data Source=VAIO; User Id=sa; Password=123; Database=CMS");
        SqlCommand cmd = null;
        SqlDataReader reader = null;
        public appointment()
        {
            InitializeComponent();
            getAllAppoinments();
            getPatientNO();
            getDocName();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            new PatientHistory().Show();
        }

        private void appointment_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
              try{
                con.Open();
             //   cmd = new SqlCommand("insert into Patient_reg(Name,DOB,Email,Gender,City,Marital_Status,Mobile,House_tell,Occupation,Other_Info,Status) values('" + TxtName.Text + "','" + DTPDOB.Text + "','" + TxtEmail.Text + "','" + CbSex.SelectedItem.ToString() + "','" + TxtCity.Text + "','" + CbMS.SelectedItem.ToString() + "','" + TxtMob.Text + "','" + TxtHouse.Text + "','" + TxtO.Text + "','" + TxtOtherInfo.Text + "',1)", con);
                cmd = new SqlCommand("insert into Appointment values('" + textBox1.Text + "','" + textBox4.Text + "','" + dateTimePicker2.Text + "','" + textBox8.Text + "','" + CbSex.SelectedItem.ToString() + "','" + textBox10.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + dateTimePicker1.Text + "', '" + comboBox2.SelectedItem.ToString() + "')", con);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Appoinmnet Added");
                   
                }
            }
            catch (Exception exe)
            {
                MessageBox.Show("Message : " + exe.Message);
            }
            finally
            {
                con.Close();
                getAllAppoinments();
            }


       
        }

        //private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{

        //}
        public void getAllAppoinments() {
            try
            {
                con.Open();
                cmd = new SqlCommand("select * from Appointment", con);
                reader = cmd.ExecuteReader();
                DataTable dt = new DataTable("patient");
                dt.Load(reader);
                dataGridView1.DataSource = dt;

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

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void pictureBox7_Click_1(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox4.Text = "";
            dateTimePicker2.Text = "";
            CbSex.Text = "";
            textBox6.Text = "";
            textBox10.Text = "";
            textBox8.Text = "";
            textBox7.Text = "";
            dateTimePicker1.Text = "";
            comboBox2.Text = "";
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        public void getPatientNO(){
            con.Open();
            cmd = new SqlCommand("select (MAX(Patient_no)+1) as pid from Appointment", con);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (reader["pid"].ToString() == "")
                {
                    textBox1.Text = "1";
                }
                else
                {
                    textBox1.Text = reader["pid"].ToString();
                }
            }
            con.Close();
        
        
        
        
        }

        public void getDocName() {
            try
            {
                con.Open();
                cmd = new SqlCommand("select * from Doctor where status=1", con);
                reader = cmd.ExecuteReader();
                while(reader.Read()){

                    comboBox2.Items.Add(reader[1]);
                }

                

            }
            catch (Exception exe)
            {
            }
            finally
            {
                con.Close();
            }
        
        }

    }
}
