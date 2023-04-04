using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clinik_managment_system
{
    public partial class PatientHistory : Form
    {
        SqlConnection con = new SqlConnection("Data Source=VAIO; User Id=sa; Password=123; Database=CMS");
        SqlCommand cmd = null;
        SqlDataReader reader = null;

        public PatientHistory()
        {
            InitializeComponent();
        }

        private void PatientHistory_Load(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("select * from patient_reg where status=1", con);
                reader = cmd.ExecuteReader();

                DataTable dt = new DataTable("patient");
                dt.Load(reader);

                dgvPatient.DataSource = dt;

            }
            catch (Exception exe)
            {
            }
            finally
            {
                con.Close();
            }

        }

        private void dgvPatient_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int pat_No;
            string Name, Email, City, Dob, MS, Mob, gen, HT, OCP,OI;

            DataGridViewRow drvr = dgvPatient.SelectedRows[0];
            pat_No =int.Parse( drvr.Cells[0].Value.ToString());
            Name = drvr.Cells[1].Value.ToString();
            Dob = drvr.Cells[2].Value.ToString();
            Email = drvr.Cells[3].Value.ToString();
            City = drvr.Cells[5].Value.ToString();
            MS = drvr.Cells[6].Value.ToString();
            Mob = drvr.Cells[7].Value.ToString();
            gen = drvr.Cells[4].Value.ToString();
            HT = drvr.Cells[8].Value.ToString();
            OCP = drvr.Cells[9].Value.ToString();
            OI = drvr.Cells[10].Value.ToString();
           // doc = drvr.Cells[10].Value.ToString();
            vital_sign v = new vital_sign(pat_No,Name,Email,City,Dob,MS,Mob,gen,HT,OCP,OI);
            this.Hide();
            v.Show();

        }
    }
}
