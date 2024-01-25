using ReaLTaiizor.Extension;
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
    public partial class Booking : Form
    {
        public Booking()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-DBDNK1G\\SQLEXPRESS;Initial Catalog=Group_D;Integrated Security=True");

        private void homeform_Click(object sender, EventArgs e)
        {
            home h = new home();
            h.Show();
            this.Hide();
        }

        private void logoutform2_Click(object sender, EventArgs e)
        {
            login l = new login();
            l.Show();
            this.Hide();
        }

        private void reportform2_Click(object sender, EventArgs e)
        {
            Report report = new Report();
            report.Show();
            this.Hide();
        }

        private void bookingform2_Click(object sender, EventArgs e)
        {
            Booking booking = new Booking();
            booking.Show();
            this.Hide();
        }

        private void doctorsform_Click(object sender, EventArgs e)
        {
            Doctor doctor  = new Doctor();
            doctor.Show();
            this.Hide();
        }

        private void patientsform_Click(object sender, EventArgs e)
        {
            patient patient = new patient();
            patient.Show();
            this.Hide();
        }

        private void usersform_Click(object sender, EventArgs e)
        {
            Users users = new Users();
            users.Show();
            this.Hide();
        }

        private void FillComboboxData()
        {
            doctors.Items.Clear();
            conn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select doc_name from Doctors ";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill( dt );



            foreach(DataRow dr in dt.Rows)
            {
                doctors.Items.Add(dr["doc_name"].ToString());
            }
            conn.Close();


        }


        private void Fil_show()
        {
            try
            {
                string query = "Select pt_name,tell,sex From Patient where pt_no=@pt_id";
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@pt_id", txtid.Text);


                conn.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    //txtid.Text = reader["pt_no"].ToString();
                    txtName.Text = reader["pt_name"].ToString();
                    txtPhone.Text = reader["tell"].ToString();
                    ComboBox1.Text = reader["sex"].ToString();


                }
                else
                {
                    if (txtid.Text == "")
                    {
                    }

                    else
                    {
                        txtName.Clear();
                        txtPhone.Clear();
                        ComboBox1.SelectedItem = "Select Sex";
                        txtName.Focus();
                        MessageBox.Show("No results found.");
                        return;

                    }
                    
                }

                reader.Close();
                
            }
            catch
            {
               
            }
            conn.Close();
           
        }


        private void Booking_Load(object sender, EventArgs e)
        {

            FillComboboxData();
        

        }

        private void button11_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("insert into Appointment(pt_no,doc_name,card_no,app_date) values(@pt_no,@doc_name,@card_No,@app_date) ", conn);
            cmd.Parameters.AddWithValue("@pt_no", txtid.Text);
            cmd.Parameters.AddWithValue("@doc_name", doctors.SelectedItem);
            cmd.Parameters.AddWithValue("@card_No", txtNo.Text);
            cmd.Parameters.AddWithValue("@app_date", dateTimePicker1.Text);

            conn.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("Saved the data ..");
            conn.Close();
            //bind_data();

            txtid.Clear();
            txtName.Clear();
            txtPhone.Clear();
            txtNo.Clear();
            txtPayment.Clear();
            doctors.SelectedItem = "Select Doctor";
            ComboBox1.SelectedItem = "Select Sex";
            txtName.Focus();
        }

        private void doctors_SelectedIndexChanged(object sender, EventArgs e)
        {
            doctors.SelectedItem = "Select Doctor";

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {

                SqlCommand cmd = new SqlCommand("select * from Appointment where app_no like @pt_no +'%'", conn);
                cmd.Parameters.AddWithValue("@app_no", txtsearch.Text);
                SqlDataAdapter sda = new SqlDataAdapter();
                sda.SelectCommand = cmd;
                DataTable dt = new DataTable();
                dt.Clear();
                sda.Fill(dt);
                Fil_show();
            }
            catch
            {

            }
            
        }

        private void txtid_TextChanged(object sender, EventArgs e)
        {
            Fil_show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("update Appointment set pt_no=@pt_no ,doc_name=@doc_name,card_No=@card_No,app_date=@app_date where pt_no=@pt_no  ", conn);
            cmd.Parameters.AddWithValue("@pt_no", txtid.Text);
            cmd.Parameters.AddWithValue("@doc_name", doctors.SelectedItem);
            cmd.Parameters.AddWithValue("@card_No", txtNo.Text);
            cmd.Parameters.AddWithValue("@app_date", dateTimePicker1.Text);

            conn.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("update the data..");
            conn.Close();
            //bind_data();

            txtid.Clear();
            txtName.Clear();
            txtPhone.Clear();
            txtNo.Clear();
            txtPayment.Clear();
            doctors.SelectedItem = "Select Doctor";
            ComboBox1.SelectedItem = "Select Sex";
            txtName.Focus();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("delete  from Appointment where app_no = @app_no", conn);
            cmd.Parameters.AddWithValue("@app_No", txtid.Text);

            conn.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("deleted  ...");
            conn.Close();

            txtid.Clear();
            txtName.Clear();
            txtPhone.Clear();
            txtNo.Clear();
            txtPayment.Clear();
            doctors.SelectedItem = "Select Doctor";
            ComboBox1.SelectedItem = "Select Sex";
            txtid.Focus();


        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void id_Click(object sender, EventArgs e)
        {

        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void labelEdit4_Click(object sender, EventArgs e)
        {

        }

        private void labelEdit3_Click(object sender, EventArgs e)
        {

        }

        private void labelEdit1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
