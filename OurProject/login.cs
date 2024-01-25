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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-DBDNK1G\\SQLEXPRESS;Initial Catalog=Group_D;Integrated Security=True;");

        private void bigLabel1_Click(object sender, EventArgs e)
        {

        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x84:
                    base.WndProc(ref m);
                    if ((int)m.Result == 0x1)
                        m.Result = (IntPtr)0x2;
                    return;
            }
            base.WndProc(ref m);
        }

        private void showbtn_Click(object sender, EventArgs e)
        {
            if (txtPassword.PasswordChar == '*')
            {
                hidebtn.BringToFront();
                txtPassword.PasswordChar = '\0';
            }
        }

        private void hidebtn_Click(object sender, EventArgs e)
        {
            if (txtPassword.PasswordChar == '\0')
            {
                showbtn.BringToFront();
                txtPassword.PasswordChar = '*';
            }
        }

        private void txtusername_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        string log;

        private void loginbtn_Click(object sender, EventArgs e)
        {
           string user_name = txtusername.Text;
            string Pass = txtPassword.Text;

            if (txtusername.Text == "" || txtPassword.Text =="")
            {
                MessageBox.Show("Enter the user_Name or Pas...");
            }
            else
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("select us_type,us_Password from Users where us_type=@us_type  AND us_Password=@us_Password ", conn);
                    cmd.Parameters.AddWithValue("us_type", txtusername.Text);
                    cmd.Parameters.AddWithValue("us_Password", txtPassword.Text);


                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    int i = ds.Tables[0].Rows.Count;

                    if(i ==  1)
                    {
                        conn.Open();
                        SqlDataReader sdr = cmd.ExecuteReader();
                        sdr.Read();
                        if(sdr["us_type"].ToString() == "Admin")
                        {
                            Ulog.type = "A";
                            this.Hide();
                            home h = new home();
                            h.Show();
                        }
                        else
                        {
                            Ulog.type = "D";
                            this.Hide();
                            home h = new home();
                            h.Show();
                        }
                        

                                           
                    }
                    else
                    {
                        MessageBox.Show("Invalid User or Password");
                    }
                    txtPassword.Clear();
                    txtusername.Clear();
                    txtusername.Focus();


                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex);

                }

            }
            
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void usernamelbl_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void nightControlBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void login_Load(object sender, EventArgs e)
        {
            txtusername.Focus();
        }
    }
}
