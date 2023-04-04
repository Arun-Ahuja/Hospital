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
    public partial class View_Vital : Form
    {
        SqlConnection con = new SqlConnection("Data Source=VAIO; User Id=sa; Password=123; Database=CMS");
        SqlCommand cmd = null;
        SqlDataReader reader = null;
        public View_Vital()
        {
            InitializeComponent();
            getAllpeint();
            getAllVitals();
            getAllAppointment();
            getAllDoctor();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }
        public void getAllpeint()
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("select * from patient_reg where status=1", con);
                reader = cmd.ExecuteReader();

                DataTable dt = new DataTable("patient");
                dt.Load(reader);

                dataGridView1.DataSource = dt;

            }
            catch (Exception exe)
            {
            }
            finally
            {
                con.Close();
            }
        }

        public void getAllVitals()
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("select * from Vital_sign where status=1", con);
                reader = cmd.ExecuteReader();

                DataTable dt = new DataTable("Vitals");
                dt.Load(reader);

                dataGridView2.DataSource = dt;

            }
            catch (Exception exe)
            {
            }
            finally
            {
                con.Close();
            }
        }
        public void getAllAppointment()
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("select * from Appointment", con);
                reader = cmd.ExecuteReader();

                DataTable dt = new DataTable("Appointment");
                dt.Load(reader);

                dataGridView3.DataSource = dt;

            }
            catch (Exception exe)
            {
            }
            finally
            {
                con.Close();
            }
        }
        public void getAllDoctor()
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("select * from Doctor where status=1", con);
                reader = cmd.ExecuteReader();

                DataTable dt = new DataTable("Doctor");
                dt.Load(reader);

                dataGridView4.DataSource = dt;

            }
            catch (Exception exe)
            {
            }
            finally
            {
                con.Close();
            }
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }

}
    