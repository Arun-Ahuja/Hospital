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
    public partial class patient_information : Form
    {
        SqlConnection con = new SqlConnection("Data Source=VAIO; User Id=sa; Password=123; Database=CMS");
        SqlCommand cmd = null;
        SqlDataReader reader = null;
        public patient_information()
        {
            InitializeComponent();
            GetNewPatientCode();
            getAllpeint();
           
        }
        public patient_information(string pat_No, string Name, string Email, string City, string Dob, string MS, string Mob, string gen, string HT, string OCP, string OI,string doc)
        {
            InitializeComponent();
            txtpatientNo.Text = pat_No;
            TxtName.Text = Name;
            TxtEmail.Text = Email;
            TxtCity.Text = City;
            TxtHouse.Text = HT;
            TxtOtherInfo.Text = OI;
            DTPDOB.Text = Dob;
            TxtMob.Text = Mob;
            TxtO.Text = OCP;
            CbMS.Text = MS;
            CbSex.Text = gen;
            comboBox2.Text = doc;

        }

        private void Form2_Load(object sender, EventArgs e)
        {
             

               
            
          

        }

        private void GetNewPatientCode()
        {
        try
            {
              
            con.Open();
            cmd = new SqlCommand("select (MAX(patient_no)+1) as pid from Patient_reg", con);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (reader["pid"].ToString() == "")
                {
                    txtpatientNo.Text = "1";
                }
                else
                {
                    txtpatientNo.Text = reader["pid"].ToString();
                }

            }
            }
        catch (Exception exe)
        {
            MessageBox.Show("Message : "+ exe.Message);
        }
        finally
        {
            con.Close();
        }
           

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ViewPatient v = new ViewPatient();
            v.Show();
            this.Hide();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
           
            
            try
            {
              //  con.Open();
              ////  if (TxtFName.Text != "")
              ////  {
              //  string query2 = "insert into Patient_reg values('" +TxtCode.Text+ "' , '" +DTPDOB.Value.ToShortDateString()+ "' , '" +TxtCPR_No.Text + "' , '" + CbSex.Text + "', '" + CbMS.Text + "' , '" + TxtHouse.Text + "' , '" + TxtO.Text + "' , '" + TxtName.Text + "', '" + TxtFile_No.Text + "' , '" + TxtEmail.Text + "' , '" + TxtCity.Text + "' , '" + TxtMob.Text + "' , '" + TxtOtherInfo.Text + "' )";
              //      cmd = new SqlCommand(query2, con);
                  
              //      if (cmd.ExecuteNonQuery() > 0)
              //          MessageBox.Show("Patient Added");
              //      this.Hide();
              //  }


               // else
                //    throw new Exception();
            }

            catch (Exception e2)
            {
                MessageBox.Show("Message : " + e2.Message);
            }
            finally
            {
                con.Close();
            }
        }
        public void GetPCode()
        {

            try
            {

                string c;
                int c2;
                con.Open();
                SqlDataReader reader = null;
                cmd = new SqlCommand("select MAX(patient_no) from patient_REg", con);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    c = reader[0].ToString();
                    c2 = int.Parse(c) + 1;
                    txtpatientNo.Text = c2.ToString();
                }


            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
            finally {
                con.Close();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            
            try
            {
                con.Open();
                cmd = new SqlCommand("insert into Patient_reg(Name,DOB,Email,Gender,City,Marital_Status,Mobile,House_tell,Occupation,Other_Info,Status,Doctor) values('" + TxtName.Text + "','" + DTPDOB.Text + "','" + TxtEmail.Text + "','" + CbSex.SelectedItem.ToString() + "','" + TxtCity.Text + "','" + CbMS.SelectedItem.ToString() + "','" + TxtMob.Text + "','" + TxtHouse.Text + "','" + TxtO.Text + "','" + TxtOtherInfo.Text + "',1,'" + comboBox2.SelectedItem.ToString() + "')", con);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Patient Added");
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

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            GetNewPatientCode();
            TxtName.Text = "";
            TxtEmail.Text = "";
            DTPDOB.Text="";
           // TxtEmail.Text="";
                CbSex.Text="";
                TxtCity.Text="";
                    CbMS.Text="";
                    TxtMob.Text="";
                        TxtHouse.Text="";
                        TxtO.Text="";
                        TxtOtherInfo.Text = "";
                        comboBox2.Text = "";
            //CbSex.
           
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnUpdateVS_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("update Patient_reg set Name='" + TxtName.Text + "' , DOB='" + DTPDOB.Text + "' , Email='" + TxtEmail.Text + "' , gender='" + CbSex.SelectedText.ToString() + "', city='" + TxtCity.Text + "',Marital_Status='" + CbMS.SelectedText.ToString() + "' ,Mobile='" + TxtMob.Text + "',House_Tell='" + TxtHouse.Text + "' ,Occupation='" + TxtO.Text + "' ,Other_Info='" + TxtOtherInfo.Text + "' ,status=1,Doctor='" + comboBox2.SelectedText.ToString() + "' where Patient_No='" + int.Parse(txtpatientNo.Text) + "'  ", con);
                if (cmd.ExecuteNonQuery() > 0)
                    MessageBox.Show("Record Updated");


            }
            catch (Exception exe)
            {
                MessageBox.Show("Message  : " + exe.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void btnDeleteVS_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("update Patient_reg set status=0 where Patient_No='" + int.Parse(txtpatientNo.Text) + "'  ", con);
                if (cmd.ExecuteNonQuery() > 0)
                    MessageBox.Show("Record Updated");


            }
            catch (Exception exe)
            {
                MessageBox.Show("Message  : " + exe.Message);
            }
            finally
            {
                con.Close();
            }
        }


        public void getAllpeint()
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("select * from  Doctor where status=1", con);
                reader = cmd.ExecuteReader();
                while (reader.Read()) { 
                
                comboBox2.Items.Add(reader[1].ToString());
                
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
