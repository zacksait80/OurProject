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
    public partial class patient : Form
    {
        public patient()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-DBDNK1G\\SQLEXPRESS;Initial Catalog=Group_D;Integrated Security=True");

        private void homeform_Click(object sender, EventArgs e)
        {
            home hm = new home();
            this.Hide();
            hm.ShowDialog();
        }

        private void usersform_Click(object sender, EventArgs e)
        {
            Users user = new Users();
            this.Hide();
            user.ShowDialog();
        }

        private void labelEdit5_Click(object sender, EventArgs e)
        {

        }

        private void patient_Load(object sender, EventArgs e)
        {
            //Fil_show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void reportform2_Click(object sender, EventArgs e)
        {
            Report r = new Report();
            r.Show();
            this.Hide();
        }

        private void logoutform2_Click(object sender, EventArgs e)
        {
            login login = new login();
            login.Show();
            this.Hide();
        }

        private void bookingform2_Click(object sender, EventArgs e)
        {
            Booking b = new Booking();
            b.Show();
            this.Hide();
        }

        private void doctorsform_Click(object sender, EventArgs e)
        {
            Doctor d = new Doctor();
            d.Show();
            this.Hide();
        }

        private void patientsform_Click(object sender, EventArgs e)
        {
            this.Show();
        }
        public void clearText()
        {
            txtName.Clear();
            txtPhone.Clear();
            txtAge.Clear();
            comboBox1.SelectedItem = "Select Sex";
            txtName.Focus();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("insert into Patient values(@pt_name, @tell, @pt_sex, @pt_Age)", conn);
            cmd.Parameters.AddWithValue("@pt_name", txtName.Text);
            cmd.Parameters.AddWithValue("@tell", txtPhone.Text);
            cmd.Parameters.AddWithValue("@pt_sex", comboBox1.SelectedItem);
            cmd.Parameters.AddWithValue("@pt_Age", txtAge.Text);


            conn.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("saved  ...");
            conn.Close();
            clearText();

        }

        private void button10_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Update Patient set pt_name=@pt_name,tell=@tell,sex=@pt_sex,Age=@pt_Age where pt_name=@pt_name", conn);
            cmd.Parameters.AddWithValue("@pt_name", txtName.Text);
            cmd.Parameters.AddWithValue("@tell", txtPhone.Text);
            cmd.Parameters.AddWithValue("@pt_sex", comboBox1.SelectedItem);
            cmd.Parameters.AddWithValue("@pt_Age", txtAge.Text);


            conn.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("updated  ...");
            conn.Close();
            clearText();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("delete from Patient where pt_name=@pt_name ", conn);
            cmd.Parameters.AddWithValue("@pt_name", txtName.Text);

            conn.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("deleted  ...");
            conn.Close();
            clearText();
        }

        private void Fil_show()
        {
            try
            {
                string query = "Select * From Patient where pt_name=@pt_name ";
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@pt_name", txtsearch.Text);

                conn.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    txtName.Text = reader["pt_name"].ToString();
                    txtPhone.Text = reader["tell"].ToString();
                    txtAge.Text = reader["Age"].ToString();
                    comboBox1.Text = reader["sex"].ToString();
                   



                }
                else
                {
                    if (txtsearch.Text == "")
                    {
                        MessageBox.Show("Enter the name");
                    }
                    else
                    {
                       
                        txtName.Clear();
                        txtPhone.Clear();
                        txtAge.Clear();
                        comboBox1.SelectedItem = "Select Sex";
                        txtName.Focus();
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

        private void button8_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from Patient where pt_name like @pt_name+'%' ", conn);
            cmd.Parameters.AddWithValue("@pt_name", txtsearch.Text);

            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = cmd;
            DataTable dt = new DataTable();
            dt.Clear();
            sda.Fill(dt);
            // dataGridView1.DataSource = dt;
            //dataGridView1.Visible = true;
            Fil_show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index;
            index = e.RowIndex;
            DataGridViewRow selectedrow = dataGridView1.Rows[index];
            txtName.Text = selectedrow.Cells[1].Value.ToString();
            txtPhone.Text = selectedrow.Cells[2].Value.ToString();
            comboBox1.Text = selectedrow.Cells[3].Value.ToString();
            txtAge.Text = selectedrow.Cells[4].Value.ToString();

        }
    }
}
