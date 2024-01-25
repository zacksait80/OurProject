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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace OurProject
{
    public partial class Users : Form
    {
        public Users()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-DBDNK1G\\SQLEXPRESS;Initial Catalog=Group_D;Integrated Security=True");

        private void button13_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void bigLabel2_Click(object sender, EventArgs e)
        {

        }

        private void labelEdit3_Click(object sender, EventArgs e)
        {

        }

        private void Users_Load(object sender, EventArgs e)
        {
           // bind_data();
        }

        private void homeform_Click(object sender, EventArgs e)
        {
            home hm= new home();
            this.Hide();
            hm.ShowDialog();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void userform_Click(object sender, EventArgs e)
        {

        }

        private void patientform_Click(object sender, EventArgs e)
        {

        }

        private void doctorform_Click(object sender, EventArgs e)
        {

        }

        private void bookingform_Click(object sender, EventArgs e)
        {

        }

        private void reportform_Click(object sender, EventArgs e)
        {

        }

        private void logoutform_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelEdit1_Click(object sender, EventArgs e)
        {

        }

        private void labelEdit4_Click(object sender, EventArgs e)
        {

        }

        private void labelEdit2_Click(object sender, EventArgs e)
        {

        }

        private void labelEdit5_Click(object sender, EventArgs e)
        {

        }

        private void bigLabel2_Click_1(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void nightControlBox1_Click(object sender, EventArgs e)
        {

        }

        private void doctorsform_Click(object sender, EventArgs e)
        {
            Doctor doc = new Doctor();
            this.Hide();
            doc.ShowDialog();
        }

        private void homeform_Click_1(object sender, EventArgs e)
        {
            home ho = new home();
            this.Hide();
            ho.ShowDialog();
        }

        private void usersform_Click(object sender, EventArgs e)
        {

        }

        private void patientsform_Click(object sender, EventArgs e)
        {
            patient pat = new patient();
            this.Hide();
            pat.ShowDialog();
        }

        private void txtusername_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void bookingform2_Click(object sender, EventArgs e)
        {
            Booking b = new Booking();
            b.Show();
            this.Hide();

        }

        private void reportform2_Click(object sender, EventArgs e)
        {
            Report report = new Report();   
            report.Show();
            this.Hide();
        }

        private void logoutform2_Click(object sender, EventArgs e)
        {
            login login = new login();
            login.Show();
            this.Hide();
        }

        /*private void bind_data()
        {
            SqlCommand cmd = new SqlCommand("select * from Users", conn);
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = cmd;
            DataTable dt = new DataTable();
            dt.Clear();
            sda.Fill(dt);
            dataGridView2.DataSource = dt;

        }
        */

        private void button11_Click_1(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("insert into Users values(@us_name, @us_phone, @usr_name, @us_type, @us_Password)",conn);
            cmd.Parameters.AddWithValue("@us_name",txtFname.Text);
            cmd.Parameters.AddWithValue("us_phone",txtPhone.Text);
            cmd.Parameters.AddWithValue("usr_name",txtEmail.Text);
            cmd.Parameters.AddWithValue("us_type", comboBox1.SelectedItem);
            cmd.Parameters.AddWithValue("us_Password",txtPass.Text);

            conn.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("saved  ...");
            conn.Close();
            //bind_data();


            txtFname.Clear();
            txtPhone.Clear();
            txtEmail.Clear();
            txtPass.Clear();
            txtFname.Focus();
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Update Users set us_name=@us_name, us_phone=@us_phone, usr_name=@usr_name, us_type=@us_type, us_Password=@us_Password  where us_name = @us_name OR us_Phone = @us_phone ",conn);
            cmd.Parameters.AddWithValue("@us_name",txtFname.Text);
            cmd.Parameters.AddWithValue("@us_phone",txtPhone.Text);
            cmd.Parameters.AddWithValue("@usr_name", txtEmail.Text);
            cmd.Parameters.AddWithValue("@us_type", comboBox1.Text);
            cmd.Parameters.AddWithValue("@us_Password", txtPass.Text);

            conn.Open( );
            cmd.ExecuteNonQuery();
            MessageBox.Show("updated the data ..");
            conn.Close();
            //bind_data();


            txtFname.Clear();
            txtPhone.Clear();
            txtEmail.Clear();
            txtPass.Clear();
            txtFname.Focus();

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index;
            index = e.RowIndex;
            DataGridViewRow selectedrow = dataGridView2.Rows[index];
            txtFname.Text = selectedrow.Cells[1].Value.ToString();
            txtPhone.Text = selectedrow.Cells[2].Value.ToString();
            txtEmail.Text = selectedrow.Cells[3].Value.ToString();
            comboBox1.Text = selectedrow.Cells[4].Value.ToString();
            txtPass.Text = selectedrow.Cells[5].Value.ToString();

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("delete from Users where us_name = @us_name",conn);
            cmd.Parameters.AddWithValue("@us_name",txtFname.Text);

            conn.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("deleted ..");
            conn.Close();
            //bind_data();

            txtFname.Clear();
            txtPhone.Clear();
            txtEmail.Clear();
            txtPass.Clear();
            comboBox1.SelectedItem = "Select Type";
            txtFname.Focus();
        }

        private void Fil_show()
        {
            try
            {
                string query = "SELECT us_name,us_phone,usr_name,us_type,us_password from Users where us_name = @us_name ";
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@us_name", txtsearch.Text);

                conn.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    txtFname.Text = reader["us_name"].ToString();
                    txtPhone.Text = reader["us_phone"].ToString();
                    txtEmail.Text = reader["usr_name"].ToString();
                    comboBox1.Text = reader["us_type"].ToString();
                    txtPass.Text = reader["us_password"].ToString();




                }
                else
                {
                    if (txtsearch.Text == "")
                    {
                        MessageBox.Show("Enter the name");
                    }
                    else
                    {
                        txtEmail.Clear();
                        txtPass.Clear();
                        txtFname.Clear();
                        txtPhone.Clear();
                        comboBox1.SelectedItem = "Select Type";
                        txtFname.Focus();
                        MessageBox.Show("No results found.");

                    }
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                conn.Close();

            }
        }


        private void button8_Click_1(object sender, EventArgs e)
        {

        
            SqlCommand cmd = new SqlCommand("select * from Users where us_name like @us_name +'%'", conn);
            cmd.Parameters.AddWithValue("@us_name", txtsearch.Text);
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = cmd;
            DataTable dt = new DataTable();
            dt.Clear();
            sda.Fill(dt);
           // dataGridView2.DataSource = dt;
           // dataGridView2.Visible = true;
           Fil_show();

        }     
    }
}
