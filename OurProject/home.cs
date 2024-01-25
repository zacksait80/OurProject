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
using System.Data.SqlClient;

namespace OurProject
{
    public partial class home : Form
    {
        public home()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-DBDNK1G\\SQLEXPRESS;Initial Catalog=Group_D;Integrated Security=True");


        string val = "0";
        private void Shown()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("select count(doc_name) from Doctors", conn);

            int i = Convert.ToInt32(cmd.ExecuteScalar());

            conn.Close();

            lbl2.Text = val + i.ToString();
           
            i++;
        }

        private void showNumbers()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("select count(pt_name) from Patient", conn);
            SqlCommand cmd1 = new SqlCommand("select count(us_name) from Users",conn);
            SqlCommand cmd2 = new SqlCommand("select count(app_no) from Appointment", conn);

            int i = Convert.ToInt32(cmd.ExecuteScalar());
            int A = Convert.ToInt32(cmd1.ExecuteScalar());
            int y = Convert.ToInt32(cmd2.ExecuteScalar());
            //Convert.ToInt32(cmd2.ExecuteScalar());
            conn.Close();

            lbl1.Text = val + A.ToString();
            lbl3.Text = val + i.ToString();
            lbl5.Text = val + y.ToString();
            A++;
            i++;
            y++;
        }





        private void Form1_Load(object sender, EventArgs e)
        {
            Shown();
            showNumbers();

            if(Ulog.type == "A")
            {
                button1.Visible = false;
            }
            else if(Ulog.type == "D")
            {
                button1.Visible = true;

                userform.Visible = false;
                bookingform.Visible = false;
                doctorform.Visible = false;
                patientform.Visible = false;
                reportform.Visible = false;
                btnU.Visible = false;
                btnB.Visible = false;
                btnD.Visible = false;
                btnP.Visible = false;
                btnpe.Visible = false;
                lbl1.Visible = false;
                lbl2.Visible = false;
                lbl3.Visible = false;
                lbl4.Visible = false;
                lbl5.Visible = false;

            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void nightControlBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bigLabel1_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            //Shown();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            login login = new login();

            DialogResult r;
            r = MessageBox.Show("Do you want to LogOut ", "LOG OUT",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                login.Show();
                this.Hide();
            }
            else
            {
                this.Show();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Report re = new Report();
            this.Hide();
            re.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Doctor doc = new Doctor();
            this.Hide();
            doc.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Booking bk = new Booking();     
            this.Hide();
            bk.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            patient pat = new patient();
            this.Hide();
            pat.ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            showNumbers();
        }

        private void button9_Click_1(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
        }

        private void userform_Click(object sender, EventArgs e)
        {
            Users user = new Users();
            this.Hide();
            user.ShowDialog();
        }

        private void lbl2_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            D_Petients dP= new D_Petients();
            dP.Show();
            this.Hide();
        }
    }
}
