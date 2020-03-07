using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace BloodBank
{
    public partial class Form1 : Form
    {

        static string connectionString = "SERVER=remotemysql.com;PORT=3306;DATABASE=N0hLjLJLCL;UID=N0hLjLJLCL;PASSWORD=oKQxuqRKgj"; 
        static string localConnectionString = "SERVER=127.0.0.1;PORT=3306;DATABASE=bloodbank;username=admin;password=12345;";
        

        MySqlConnection conn = new MySqlConnection(localConnectionString);
        MySqlCommand cmd;

        public Form1()
        {
            InitializeComponent(); 
    
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }

        private void DonorFirstNameTextBox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
           
            try
            {
                conn.Open();
                DateTime aDate = DateTime.Now;
                cmd = conn.CreateCommand();

                if(DonorFirstNameTextBox.Text == "" || DonorLastNameTextBox.Text == "" ||
                    NurseFirstNameTextBox.Text == "" || NurseLastNameTextBox.Text == "" ||
                    DonationBloodTypeTextBox.Text == "" || DonorValidationTextBox.Text == "" ||
                    DonationDescriptionTextBox.Text == "")
                {
                    MessageBox.Show("First Name, Last Name, Blood Type, Validation or Description can not be empty");
                    conn.Close();
                }

                else
                {
                    cmd.CommandText = "INSERT INTO person (FirstName,MiddleName,LastName,PhoneNumber)" + " VALUES('" +
                        DonorFirstNameTextBox.Text.ToString() + "','" +
                        DonorMiddleNameTextBox.Text.ToString() + "','" +
                        DonorLastNameTextBox.Text.ToString() + "','" +
                        DonorPhoneNumberTextBox.Text.ToString() + "');" +

                        "INSERT INTO person (FirstName,MiddleName,LastName,PhoneNumber)" + " VALUES('" +
                        NurseFirstNameTextBox.Text.ToString() + "','" +
                        NurseMiddleNameTextBox.Text.ToString() + "','" +
                        NurseLastNameTextBox.Text.ToString() + "','" +
                        NursePhoneNumberTextBox.Text.ToString() + "');" +

                        "INSERT INTO blood (Type,ValidBlood)" + " VALUES('" +
                        DonationBloodTypeTextBox.Text.ToString() + "','" +
                        DonorValidationTextBox.Text.ToString() + "');" +

                        "INSERT INTO DonationType (Description)" + " VALUES('" +
                        DonationDescriptionTextBox.Text.ToString() + "');" +

                        "INSERT INTO Donation (DateTime)" + " VALUES('" +
                        aDate.ToString("yyyy-MM-dd HH:mm:ss") + "');";


                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Added");
                    conn.Close();
                }
            }

            catch(MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        
        //this is test method
        private void ShowTableButton_Click(object sender, EventArgs e)
        {
            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM person";

            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    listBox1.Items.Add(reader["id"].ToString());
                    listBox1.Items.Add(reader["firstname"].ToString());
                    listBox1.Items.Add(reader["middlename"].ToString());
                    listBox1.Items.Add(reader["lastname"].ToString());
                    listBox1.Items.Add(reader["phonenumber"].ToString());

                }

                conn.Close();
            }

            catch(MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
