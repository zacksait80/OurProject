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


namespace OurProject
{
    public partial class Report : Form
    {
        public Report()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-DBDNK1G\\SQLEXPRESS;Initial Catalog=Group_D;Integrated Security=True");

        private void Report_Load(object sender, EventArgs e)
        {

        }

        private void homeform_Click(object sender, EventArgs e)
        {
            home ho = new home();
            this.Hide();
            ho.ShowDialog();
        }

        private void userform_Click(object sender, EventArgs e)
        {
            Users r = new Users();
            r.Show();
            this.Hide();

        }

        private void patientform_Click(object sender, EventArgs e)
        {
            patient patient = new patient();
            this.Hide();
            patient.Show();
        }

        private void bookingform_Click(object sender, EventArgs e)
        {
            Booking booking = new Booking();
            booking.Show();
            this.Hide();
        }

        private void reportform_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        private void logoutform_Click(object sender, EventArgs e)
        {
            login login = new login();
            login.Show();
            this.Hide();
        }

        private void bind_data()
        {
            SqlCommand cmd = new SqlCommand("select * from Users", conn);
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = cmd;
            DataTable dt = new DataTable();
            dt.Clear();
            sda.Fill(dt);
            DataGridView1.DataSource = dt;

        }

        private void button10_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from Doctors", conn);
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = cmd;
            DataTable dt = new DataTable();
            dt.Clear();
            sda.Fill(dt);
            DataGridView1.DataSource = dt;

            DataGridView1.Visible = true;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            bind_data();
            DataGridView1.Visible = true;

            //cmd.Parameters.AddWithValue("@us_name", txtsearch.Text);
        }

        private void button12_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from patient", conn);
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = cmd;
            DataTable dt = new DataTable();
            dt.Clear();
            sda.Fill(dt);
            DataGridView1.DataSource = dt;

            DataGridView1.Visible = true;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from Appointment", conn);
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = cmd;
            DataTable dt = new DataTable();
            dt.Clear();
            sda.Fill(dt);
            DataGridView1.DataSource = dt;

            DataGridView1.Visible = true;
        }

        private void doctorform_Click(object sender, EventArgs e)
        {
            Doctor d=new Doctor();
            d.Show();
            this.Hide();
        }
    }
}
