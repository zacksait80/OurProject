using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace OurProject
{
    public partial class D_Petients : Form
    {
        public D_Petients()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-DBDNK1G\\SQLEXPRESS;Initial Catalog=Group_D;Integrated Security=True;Encrypt=False");


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
                    txtFname.Text = reader["pt_name"].ToString();
                    txtPhone.Text = reader["tell"].ToString();
                    comboBox1.Text = reader["sex"].ToString();


                }
                else
                {
                    if (txtid.Text == "")
                    {
                    }

                    else
                    {
                        txtFname.Clear();
                        txtPhone.Clear();
                        comboBox1.SelectedItem = "Select Sex";
                        txtFname.Focus();
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
        private void bind_data()
        {
            SqlCommand cmd = new SqlCommand("select * from Users", conn);
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = cmd;
            DataTable dt = new DataTable();
            dt.Clear();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Visible = true;

        }

        private void txtid_TextChanged(object sender, EventArgs e)
        {
            Fil_show();
        }

        private void button11_Click(object sender, EventArgs e)
        {

            SqlCommand cmd = new SqlCommand("Insert into pt_Status(pt_no,pt_name,tell,sex,Status,S_time) values(@pt_no,@pt_name,@tell,@sex,@Status,@S_time)", conn);
            cmd.Parameters.AddWithValue("@pt_no", txtid.Text);
            cmd.Parameters.AddWithValue("@pt_name", txtFname);
            cmd.Parameters.AddWithValue("@tell", txtPhone.Text);
            cmd.Parameters.AddWithValue("@sex", comboBox1.SelectedItem.ToString());
            cmd.Parameters.AddWithValue("@Status", aloneComboBox1.SelectedItem.ToString());
            cmd.Parameters.AddWithValue("@S_time", dateTimePicker1.Text);

            conn.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("Saved the data ..");
            conn.Close();
            bind_data();

            txtid.Clear();
            txtFname.Clear();
            txtPhone.Clear();
            aloneComboBox1.SelectedItem = "Select Status";
            comboBox1.SelectedItem = "Select Sex";
            txtFname.Focus();
        }

        private void patientsform_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;

        }

        private void homeform_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
        }

        private void logoutform2_Click(object sender, EventArgs e)
        {
            login l = new login();
            this.Hide();
            l.Show();
        }

        private void D_Petients_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtid_TextChanged_1(object sender, EventArgs e)
        {
            Fil_show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("update pt_Status set pt_no=@pt_no,pt_name=@pt_name,tell=@tell,sex=@sex,Status=@Status,S_time=@S_time where pt_no=@pt_no", conn);
            cmd.Parameters.AddWithValue("@pt_no", txtid.Text);
            cmd.Parameters.AddWithValue("@pt_name", txtFname);
            cmd.Parameters.AddWithValue("@tell", txtPhone.Text);
            cmd.Parameters.AddWithValue("@sex", comboBox1.SelectedItem.ToString());
            cmd.Parameters.AddWithValue("@Status", aloneComboBox1.SelectedItem.ToString());
            cmd.Parameters.AddWithValue("@S_time", dateTimePicker1.Text);

            conn.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("Updated the data ..");
            conn.Close();
            bind_data();

            txtid.Clear();
            txtFname.Clear();
            txtPhone.Clear();
            aloneComboBox1.SelectedItem = "Select Status";
            comboBox1.SelectedItem = "Select Sex";
            txtFname.Focus();
        }

        private void id_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void labelEdit7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void labelEdit4_Click(object sender, EventArgs e)
        {

        }

        private void labelEdit3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void bigLabel1_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void logoutform_Click(object sender, EventArgs e)
        {

        }

        private void reportform_Click(object sender, EventArgs e)
        {

        }

        private void doctorform_Click(object sender, EventArgs e)
        {

        }

        private void bookingform_Click(object sender, EventArgs e)
        {

        }

        private void patientform_Click(object sender, EventArgs e)
        {

        }

        private void userform_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void labelEdit2_Click(object sender, EventArgs e)
        {

        }

        private void aloneComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void labelEdit6_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtFname_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
