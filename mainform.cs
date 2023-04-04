using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clinik_managment_system
{
    public partial class main_form : Form
    {
        public main_form()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            new Doctor ().Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            new patient_information().Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
           
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            new vital_sign().Show();
           // this.Hide();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            new Form7 ().Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            new appointment ().Show();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            new View_Vital().Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }
    }
}
