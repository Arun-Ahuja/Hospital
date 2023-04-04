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
    public partial class Doctor : Form
    {
        SqlConnection con = new SqlConnection("Data Source=VAIO; User Id=sa; Password=123; Database=CMS");
        SqlCommand cmd = null;
        SqlDataReader reader = null;

        public Doctor()
        {
            InitializeComponent();
            getPatientNO();
            getAllDoc();
        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            new PatientHistory().Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            try
            {
                if (TxtDrName.Text == "")
                    MessageBox.Show("Fill All the Fields");
                else { 
                con.Open();
                cmd = new SqlCommand("insert into Doctor (DoctorID,DR_Name,Specialisation,Qualification,Desination,Salary,Remarks,[Status],Gender) values ('" + int.Parse(TxtId.Text) + "','" + TxtDrName.Text + "','" + TxtSP.Text + "','" + TxtQul.Text + "','" + TxtDes.Text + "','" + TxtSalary.Text + "', '" + TxtRemarks .Text+ "', 1 , '" + TxtGander.Text + "')", con);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Doctor Added");
                }

                }

            }
            catch (Exception exe)
            {
                MessageBox.Show("Message : " + exe.Message);
            }
            finally
            {
                con.Close();
                getPatientNO();
                getAllDoc();
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            TxtDrName.Text = "";
            TxtId.Text = "";
            TxtSP.Text = "";
            TxtSalary.Text = "";
            TxtRemarks.Text = "";
            TxtDes.Text = "";
            TxtQul.Text = "";
            getPatientNO();
        }

        private void btnDeleteVS_Click(object sender, EventArgs e)
        {
            try
            {
                
                
                    con.Open();
                    cmd = new SqlCommand(" update doctor set status=0 where DoctorID = '" + TxtId .Text+ "'", con);
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Doctor Deleted");
                        TxtDrName.Text = "";
                        TxtId.Text = "";
                        TxtSP.Text = "";
                        TxtSalary.Text = "";
                        TxtRemarks.Text = "";
                        TxtDes.Text = "";
                        TxtQul.Text = "";
                       
                    }

                

            }
            catch (Exception exe)
            {
                MessageBox.Show("Message : " + exe.Message);
            }
            finally
            {
                con.Close();
                getPatientNO();
                getAllDoc();
            }
        }
        public void getPatientNO()
        {
            con.Open();
            cmd = new SqlCommand("select (MAX(DoctorID)+1) as pid from Doctor", con);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (reader["pid"].ToString() == "")
                {
                    TxtDrName.Text = "1";
                }
                else
                {
                    TxtId.Text = reader["pid"].ToString();
                }
            }
            con.Close();
        }

        public void getAllDoc() {
            try
            {
                con.Open();
                cmd = new SqlCommand("select * from Doctor where status=1", con);
                reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                if (dt.Rows.Count > 0)
                    dgvDoctor.DataSource = dt;
                else
                    MessageBox.Show("No Record Founds");

            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.Message);
            }
            finally
            {
                con.Close();
            }
        
        }

        private void dgvDoctor_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow drvr = dgvDoctor.SelectedRows[0];
  
            TxtId .Text= drvr.Cells[0].Value.ToString();
            TxtDrName.Text = drvr.Cells[1].Value.ToString();
            TxtSP.Text = drvr.Cells[2].Value.ToString();
            TxtGander.Text = drvr.Cells[8].Value.ToString();
            TxtDes.Text = drvr.Cells[4].Value.ToString();
            TxtQul.Text = drvr.Cells[3].Value.ToString();
            TxtSalary.Text = drvr.Cells[5].Value.ToString();
            TxtRemarks.Text = drvr.Cells[6].Value.ToString();
            tabPage2.Show();
        }

        private void btnUpdateVS_Click(object sender, EventArgs e)
        {
            try
            {
                if (TxtDrName.Text == "")
                    MessageBox.Show("Fill All the Fields");
                else
                {
                    con.Open();
                    cmd = new SqlCommand("Update Doctor set DR_Name='" + TxtDrName.Text + "' ,Specialisation='" + TxtSP.Text + "', Qualification='" + TxtQul.Text + "' ,Desination='" + TxtDes.Text + "',Salary='" + TxtSalary.Text + "',Remarks='" + TxtRemarks.Text + "',[Status]=1 , Gender='" + TxtGander.Text + "' where DoctorID='" + TxtId.Text + "' ", con);
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Doctor Updated");
                        tabPage2.Show();
                    }

                }

            }
            catch (Exception exe)
            {
                MessageBox.Show("Message : " + exe.Message);
            }
            finally
            {
                con.Close();
                getPatientNO();
                getAllDoc();
            }
        }
    }
}