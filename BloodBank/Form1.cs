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

        string connectionString = "SERVER=remotemysql.com;PORT=3306;DATABASE=N0hLjLJLCL;UID=N0hLjLJLCL;PASSWORD=oKQxuqRKgj"; 

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
                MySqlConnection conn = new MySqlConnection(connectionString);
                conn.Open();

                string add = "INSERT INTO Person (FirstName,MiddleName,LastName,PhoneNumber) " + " VALUES(" + DonorFirstNameTextBox.Text.ToString() +
                    "," + DonorMiddleNameTextBox.Text.ToString() + "," + DonorLastNameTextBox.Text.ToString() + "," + DonorPhoneNumberTextBox.Text.ToString() + ");";
                //like that ? + nurse calls another entity to add first last name. fuu**k
                //Honeslty tell your group to come up with the query's just go hard on the UI and guilt them into doing the work
                //well so far i did everything. they did not even touch anything. anyway i need to figure it out. my sqlite is rusty right now lol
                //Ask them, just ask, be direct and let them know you need help or else you'll delete everything lol
                MySqlCommand cmd = new MySqlCommand(add, conn);
                cmd.ExecuteNonQuery();
            }
            catch(MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
