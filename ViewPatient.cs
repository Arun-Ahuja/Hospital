using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Clinik_managment_system
{

    public partial class ViewPatient : Form
    {
        SqlConnection con = new SqlConnection("Data Source=VAIO; User Id=sa; Password=123; Database=CMS");
        SqlCommand cmd = null;
        SqlDataReader reader = null;
        public ViewPatient()
        {
            InitializeComponent();
        }

        private void ViewPatient_Load(object sender, EventArgs e)
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

            string Name, Email, City, Dob, MS, Mob, gen, HT, OCP, OI, pat_No, doc;

            DataGridViewRow drvr = dgvPatient.SelectedRows[0];
            pat_No =drvr.Cells[0].Value.ToString();
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
            doc = drvr.Cells[12].Value.ToString();
            patient_information v = new patient_information(pat_No, Name, Email, City, Dob, MS, Mob, gen, HT, OCP, OI,doc);
            this.Hide();
            v.Show();
        }

        private void dgvPatient_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvPatient.Columns[12].Visible = false;
        }
    }
}
