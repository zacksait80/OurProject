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
using ReaLTaiizor.Enum.Poison;
using System.Xml.Linq;

namespace OurProject
{
    public partial class Doctor : Form
    {
        public Doctor()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-DBDNK1G\\SQLEXPRESS;Initial Catalog=Group_D;Integrated Security=True");

        private void Doctor_Load(object sender, EventArgs e)
        {

        }
       

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

        private void doctorsform_Click(object sender, EventArgs e)
        {
            Doctor doctor = new Doctor();
            doctor.Show();
            this.Hide();
        }

        private void bookingform2_Click(object sender, EventArgs e)
        {
            Booking booking = new Booking();
            booking.Show();
            this.Hide();

        }

        private void logoutform2_Click(object sender, EventArgs e)
        {
            login lg= new login();
            lg.Show();
            this.Hide();
        }

        private void reportform2_Click(object sender, EventArgs e)
        {
            Report R= new Report();
            R.Show();
            this.Hide();
        }

        private void patientsform_Click(object sender, EventArgs e)
        {
            patient patient = new patient();
            patient.Show();
            this.Hide();
        }

        public void clearText()
        {
            txtFname.Clear();
            txtPhone.Clear();
            txtEmail.Clear();
            txtExpe.Clear();
            txtspic.Clear();
            comboBox1.SelectedItem = "Select Sex";
            txttime.SelectedItem = "Select Work Time";

            txtFname.Focus();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("insert into Doctors values(@doc_name, @doc_Email, @doc_phone, @doc_sex, @doc_spiac, @doc_time, @doc_exp)", conn);
            cmd.Parameters.AddWithValue("@doc_name", txtFname.Text);
            cmd.Parameters.AddWithValue("@doc_Email", txtEmail.Text);
            cmd.Parameters.AddWithValue("@doc_phone", txtPhone.Text);
            cmd.Parameters.AddWithValue("@doc_sex", comboBox1.SelectedItem);
            cmd.Parameters.AddWithValue("@doc_spiac",txtspic.Text);
            cmd.Parameters.AddWithValue("@doc_time",txttime.Text);
            cmd.Parameters.AddWithValue("@doc_exp", txtExpe.Text);

            
            conn.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("saved  ...");
            conn.Close();
            Fil_show(); 
            clearText();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("update Doctors set doc_name=@doc_name, doc_Email=@doc_Email, tell=@doc_phone, sex=@doc_sex, doc_spical=@doc_spiac, doc_time=@doc_time, doc_exp=@doc_exp where doc_name = @doc_name", conn);
            cmd.Parameters.AddWithValue("@doc_name", txtFname.Text);
            cmd.Parameters.AddWithValue("@doc_Email", txtEmail.Text);
            cmd.Parameters.AddWithValue("@doc_phone", txtPhone.Text);
            cmd.Parameters.AddWithValue("@doc_sex", comboBox1.SelectedItem);
            cmd.Parameters.AddWithValue("@doc_spiac", txtspic.Text);
            cmd.Parameters.AddWithValue("@doc_time", txttime.Text);
            cmd.Parameters.AddWithValue("@doc_exp", txtExpe.Text);


            conn.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("updated  ...");
            conn.Close();
            clearText() ;

        }

        private void button9_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("delete  from Doctors where doc_name = @doc_name", conn);
            cmd.Parameters.AddWithValue("@doc_name", txtFname.Text);
           
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
                string query = "SELECT * from Doctors where doc_no = @doc_no ";
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@doc_no", txtsearch.Text);

                conn.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    txtFname.Text = reader["doc_name"].ToString();
                    txtPhone.Text = reader["tell"].ToString();
                    txtspic.Text = reader["doc_spical"].ToString();
                    comboBox1.SelectedItem = reader["sex"].ToString();
                    txtEmail.Text = reader["doc_email"].ToString();
                    txttime.SelectedItem = reader["doc_time"].ToString();
                    txtExpe.Text = reader["tell"].ToString();



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
                        txtspic.Clear();
                        txtFname.Clear();
                        txtPhone.Clear();
                        txttime.SelectedItem = "Select Work Time";
                        txtExpe.Clear();
                        comboBox1.SelectedItem = "Select Sex";
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

      



        private void button8_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from Doctors where doc_name like @doc_name +'%'", conn);
            cmd.Parameters.AddWithValue("@doc_name", txtsearch.Text);
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = cmd;
            DataTable dt = new DataTable();
            dt.Clear();
            sda.Fill(dt);
            //dataGridView1.DataSource = dt;
            //dataGridView1.Visible = true;
            Fil_show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index;
            index = e.RowIndex;
            DataGridViewRow selectedrow = dataGridView1.Rows[index];
            txtFname.Text = selectedrow.Cells[1].Value.ToString();
            txtPhone.Text = selectedrow.Cells[2].Value.ToString();
            txtEmail.Text = selectedrow.Cells[3].Value.ToString();
            comboBox1.Text = selectedrow.Cells[4].Value.ToString();
            txtspic.Text = selectedrow.Cells[5].Value.ToString();
            
            txttime.Text = selectedrow.Cells[6].Value.ToString();
            txtExpe.Text = selectedrow.Cells[7].Value.ToString();
        }

        private void txtFname_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtid_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
