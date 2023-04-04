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
    public partial class vital_sign : Form
    {
        int pat_No, vsno;
        string name, gender, group, value;

        SqlConnection con = new SqlConnection("Data Source=VAIO; User Id=sa; Password=123; Database=CMS");
        SqlCommand cmd = null;
        SqlDataReader reader = null;
       // int pat_No;
        //string Name, Email, City,  Dob, MS, Mob, gen, HT, OCP,OI;
        public vital_sign()
        {
            InitializeComponent();
            getAllVitalSigns();
        }
        public vital_sign(int pat_No,string Name,string Email,string City, string Dob,string MS,string Mob,string gen,string HT,string OCP,String OI)
        {
            InitializeComponent();
            txtpatientNo.Text = pat_No.ToString();
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

            getAllVitalSigns();

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            new PatientHistory().Show();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            txtpatientNo.Text = "";
            CbMS.Text = "";
            TxtName.Text = "";
            TxtMob.Text = "";
            TxtEmail.Text = "";
            CbSex.Text = "";
            TxtCity.Text = "";
            TxtHouse.Text = "";
            DTPDOB.Text = "";
            TxtO.Text = "";
            TxtOtherInfo.Text = "";
            comboBox1.Text = "";
            textBox1.Text = "";
            dataGridView2.Rows.Clear();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            bool a=false;
            con.Open();
               

            for (int i = 0; i < dataGridView2.Rows.Count-1; i++)
            {

                cmd = new SqlCommand("insert into vital_sign(Patient_No,Groupp,Value,status) values(" + dataGridView2.Rows[i].Cells[0].Value.ToString() + ",'" + dataGridView2.Rows[i].Cells[2].Value.ToString() + "','"+dataGridView2.Rows[i].Cells[3].Value.ToString()+ "',1)", con);
                if (cmd.ExecuteNonQuery() > 0)
                    a = true;
    
            }
            if (a)
            {
                MessageBox.Show("Vital signs Added");
                txtpatientNo.Text = "";
                CbMS.Text = "";
                TxtName.Text = "";
                TxtMob.Text = "";
                TxtEmail.Text = "";
                CbSex.Text = "";
                TxtCity.Text = "";
                TxtHouse.Text = "";
                DTPDOB.Text = "";
                TxtO.Text = "";
                TxtOtherInfo.Text = "";
                comboBox1.Text = "";
                textBox1.Text = "";
                dataGridView2.Rows.Clear();
            }
            else
                MessageBox.Show("No Vital signs selected");

          
            con.Close();
            getAllVitalSigns();
        }

        private void txtpatientNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            new PatientHistory().Show();
            //this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*try{
                    con.Open();
                 //   cmd = new SqlCommand("insert into Patient_reg(Name,DOB,Email,Gender,City,Marital_Status,Mobile,House_tell,Occupation,Other_Info,Status) values('" + TxtName.Text + "','" + DTPDOB.Text + "','" + TxtEmail.Text + "','" + CbSex.SelectedItem.ToString() + "','" + TxtCity.Text + "','" + CbMS.SelectedItem.ToString() + "','" + TxtMob.Text + "','" + TxtHouse.Text + "','" + TxtO.Text + "','" + TxtOtherInfo.Text + "',1)", con);
                    cmd = new SqlCommand("insert into Vital_sign values('" + txtpatientNo.Text + "','" + CbMS.Text + "','" + TxtName.Text + "','" + TxtMob.Text + "','" + TxtEmail.Text + "','" + CbSex.SelectedItem.ToString() + "','" + TxtCity.Text + "','" + TxtHouse.Text + "','" + DTPDOB.Text + "','" + TxtO.Text + "','" + TxtOtherInfo.Text + "' , '" + comboBox1.SelectedItem.ToString() + "','" + textBox1.Text + "')", con);
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Vital Sign Added");
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
            }*/
           // DataGridViewRow row = (DataGridViewRow)dataGridView2.Rows[0].Clone();

           // row.Cells[0].Value = "XYZ";
           // row.Cells[1].Value = 50.2;
           // dataGridView2.Rows.Add(row);
            this.dataGridView2.Rows.Add(txtpatientNo.Text, TxtName.Text, comboBox1.SelectedItem.ToString(), textBox1.Text);

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            //new main_form().Show();
            this.Hide();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            //x
        }

        private void button1_Click_3(object sender, EventArgs e)
        {
            new PatientHistory().Show();
            this.Hide();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.dataGridView2.Rows.Add(txtpatientNo.Text, TxtName.Text, comboBox1.SelectedItem.ToString(), textBox1.Text);
            /*try{
                con.Open();
             //   cmd = new SqlCommand("insert into Patient_reg(Name,DOB,Email,Gender,City,Marital_Status,Mobile,House_tell,Occupation,Other_Info,Status) values('" + TxtName.Text + "','" + DTPDOB.Text + "','" + TxtEmail.Text + "','" + CbSex.SelectedItem.ToString() + "','" + TxtCity.Text + "','" + CbMS.SelectedItem.ToString() + "','" + TxtMob.Text + "','" + TxtHouse.Text + "','" + TxtO.Text + "','" + TxtOtherInfo.Text + "',1)", con);
                cmd = new SqlCommand("insert into Vital_sign values('" + txtpatientNo.Text + "','" + CbMS.Text + "','" + TxtName.Text + "','" + TxtMob.Text + "','" + TxtEmail.Text + "','" + CbSex.SelectedItem.ToString() + "','" + TxtCity.Text + "','" + TxtHouse.Text + "','" + DTPDOB.Text + "','" + TxtO.Text + "','" + TxtOtherInfo.Text + "' , '" + comboBox1.SelectedItem.ToString() + "','" + textBox1.Text + "')", con);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Vital Sign Added");
                }
            }
            catch (Exception exe)
            {
                MessageBox.Show("Message : " + exe.Message);
            }
            finally
            {
                con.Close();
            }*/
        }

        public void getAllVitalSigns() {

            try{
               con.Open();
                string  query =@"select distinct v.vsId as 'VitalSignNo', p.Patient_No,p.Name,p.Gender,v.Groupp,v.Value from Patient_reg p 
                                inner join Vital_sign v on p.Patient_No = v.Patient_No 
                                where p.Status = 1 and v.status = 1";

               cmd = new SqlCommand(query, con);
               reader=cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                if (dt.Rows.Count > 0)
                    dgvVS.DataSource = dt;
                else
                   MessageBox.Show("No Record Found");


              //  dgvVS.Columns[0].Visible = false;


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

        private void btnClearVS_Click(object sender, EventArgs e)
        {
            //dataGridView2.DataSource = null;
            dataGridView2.Rows.Clear();
            //dataGridView2.Refresh();
            //dataGridView2.Columns.Clear();
        }

        private void dataGridView2_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string group, value;
            DataGridViewRow drvr = dataGridView2.SelectedRows[0];

         
            group= drvr.Cells[2].Value.ToString();
            value = drvr.Cells[3].Value.ToString();

            comboBox1.SelectedText = group;
            textBox1.Text = value;
          

            btnUpdateVS.Enabled = true;
            btnDeleteVS.Enabled = true;

          

        }

        private void dgvVS_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
           

            DataGridViewRow drvr = dgvVS.SelectedRows[0];


            vsno = int.Parse(drvr.Cells[0].Value.ToString());
            //MessageBox.Show(vsno.ToString());

            pat_No = int.Parse(drvr.Cells[1].Value.ToString());
            name = drvr.Cells[2].Value.ToString();
          
            group = drvr.Cells[4].Value.ToString();
            value = drvr.Cells[5].Value.ToString();

            dataGridView2.Rows.Clear();
            this.dataGridView2.Rows.Add(pat_No, name, group, value);


                tabControl1.SelectedTab = tabPage1;
                button2.Enabled = false;
           

                
           

           
        }

        private void TxtMob_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnUpdateVS_Click(object sender, EventArgs e)
        {


            try
            {
                con.Open();
                cmd = new SqlCommand("update Vital_sign set Groupp='"+comboBox1.Text+"' , value='"+textBox1.Text+"' where vsid='"+vsno+"' ", con);


                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Vital signs updated");
                    
                }
                else
                    MessageBox.Show("No Record Found");


                //  dgvVS.Columns[0].Visible = false;


            }

            catch (Exception exe)
            {
                MessageBox.Show("Message : " + exe.Message);
            }
            finally
            {
                con.Close();
                getAllVitalSigns();
            }
        }

        private void btnDeleteVS_Click(object sender, EventArgs e)
        {

            try
            {
                con.Open();
                cmd = new SqlCommand("update Vital_sign set status=0 where vsid='" + vsno + "' ", con);


                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Vital signs Deleted");

                }
                else
                    MessageBox.Show("No Record Found");


                //  dgvVS.Columns[0].Visible = false;


            }

            catch (Exception exe)
            {
                MessageBox.Show("Message : " + exe.Message);
            }
            finally
            {
                con.Close();
                getAllVitalSigns();
            }
        }

        }

       

    }

