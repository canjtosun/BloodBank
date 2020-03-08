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
    public partial class ResultBox : Form
    {
        static string connectionString = "SERVER=sql3.freemysqlhosting.net;PORT=3306;DATABASE=sql3326494;UID=sql3326494;PASSWORD=qwlhf4VVam";
        MySqlConnection conn = new MySqlConnection(connectionString);
        MySqlCommand cmd;
        DateTime aDate = DateTime.Now;

        public ResultBox()
        {
            InitializeComponent();
        }

        private void DonorAddButton_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open(); //open connection
                //check the table(not null constrain check)
                if (DonorFirstNameTextBox.Text == "" || DonorLastNameTextBox.Text == "" ||
                    DonorPhoneNumberTextBox.Text == "" || DonorBloodTypeBox.Text == "" )
                {
                    MessageBox.Show("Please fill up First Name, Last Name, Phone Number and Blood Type!");
                    conn.Close(); //close connection
                }

                else
                {
                    cmd.CommandText =
                    //insert donor to person table
                    "INSERT INTO Person (FirstName,MiddleName,LastName,PhoneNumber)" + " VALUES('" +
                    DonorFirstNameTextBox.Text.ToString() + "','" +
                    DonorMiddleNameTextBox.Text.ToString() + "','" +
                    DonorLastNameTextBox.Text.ToString() + "','" +
                    DonorPhoneNumberTextBox.Text.ToString() + "');" +

                    //insert blood type **dont forget to delete validation**
                    "INSERT INTO Blood (Type,ValidBlood)" + " VALUES('" +
                    DonorBloodTypeBox.Text.ToString() + "','" +

                    //insert donation time when we add everything to the system
                    "INSERT INTO Donation (DateTime)" + " VALUES('" +
                    aDate.ToString("yyyy-MM-dd HH:mm:ss") + "');";

                    
                    cmd.ExecuteNonQuery(); //execute
                    MessageBox.Show("Successful"); //promp user that success
                    conn.Close(); // close connection

                }

            }catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
        }

        private void NurseAddButton_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open(); //open connection
                //check the table(not null constrain check)
                if (NurseFirstNameTextBox.Text == "" || NurseLastNameTextBox.Text == "" ||
                    NursePhoneNumberTextBox.Text == "")
                {
                    MessageBox.Show("Please fill up First Name, Last Name, and Phone Number!");
                    conn.Close(); //close connection
                }

                else
                {
                    cmd.CommandText =
                    //insert donor to person table
                    "INSERT INTO Person (FirstName,MiddleName,LastName,PhoneNumber)" + " VALUES('" +
                    NurseFirstNameTextBox.Text.ToString() + "','" +
                    NurseMiddleNameTextBox.Text.ToString() + "','" +
                    NurseLastNameTextBox.Text.ToString() + "','" +
                    NursePhoneNumberTextBox.Text.ToString() + "');" +

                    cmd.ExecuteNonQuery(); //execute
                    MessageBox.Show("Successful"); //promp user that success
                    conn.Close(); // close connection

                }
            }catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
        }

        private void FacilityAddButton_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open(); //open connection
                //check the table(not null constrain check)
                if (FacilityAddress1TextBox.Text == "" || FacilityCityTextBox.Text == "" ||
                    FacilityStateTextBox.Text == "" || FacilityZipCodeTextBox.Text == "")
                {
                    MessageBox.Show("Please fill up First Name, Last Name, and Phone Number!");
                    conn.Close(); //close connection
                }

                else
                {
                    cmd.CommandText =
                    //insert info to the facility
                    "INSERT INTO Facility (Address1,Address2,City,State,ZipCode,FacilityPhone,InventoryId)" + " VALUES('" +
                    FacilityAddress1TextBox.Text.ToString() + "','" +
                    FacilityAddress2TextBox.Text.ToString() + "','" +
                    FacilityCityTextBox.Text.ToString() + "','" +
                    FacilityStateTextBox.Text.ToString() + "','" +
                    FacilityZipCodeTextBox.Text.ToString() + "','" +
                    FacilityFacilityPhoneTextBox.Text.ToString() +
                    FacilityInverntoryIdTextBox.Text.ToString() + "');";

                    cmd.ExecuteNonQuery(); //execute
                    MessageBox.Show("Successful"); //promp user that success
                    conn.Close(); // close connection
                }
            }catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
        }
    }
}
