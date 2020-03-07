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

        static string connectionString = "SERVER=sql3.freemysqlhosting.net;PORT=3306;DATABASE=sql3326494;UID=sql3326494;PASSWORD=qwlhf4VVam"; 
        //static string localConnectionString = "SERVER=127.0.0.1;PORT=3306;DATABASE=bloodbank;username=admin;password=12345;";
        

        MySqlConnection conn = new MySqlConnection(connectionString);
        MySqlCommand cmd;

        public Form1()
        {
            InitializeComponent(); 
    
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
                    DonationDescriptionTextBox.Text == "" || FacilityAddress1TextBox.Text == "" ||
                    FacilityCityTextBox.Text == "" || FacilityStateTextBox.Text == "" ||
                    FacilityZipCodeTextBox.Text == "")
                {
                    MessageBox.Show("Please fill up all information!");
                    conn.Close();
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

                    //assign that person is a donor
                    "INSERT INTO Donor (PersonID)" + " VALUES((SELECT Person.ID FROM Person WHERE Lastname = '" + 
                    DonorLastNameTextBox.Text.ToString() + "'));" +

                    //insert nurse to a person. well nurse is person too!
                    "INSERT INTO Person (FirstName,MiddleName,LastName,PhoneNumber)" + " VALUES('" +
                    NurseFirstNameTextBox.Text.ToString() + "','" +
                    NurseMiddleNameTextBox.Text.ToString() + "','" +
                    NurseLastNameTextBox.Text.ToString() + "','" +
                    NursePhoneNumberTextBox.Text.ToString() + "');" +

                    //assign that person is a nurse
                    "INSERT INTO Nurse (PersonID)" + " VALUES((SELECT Person.ID FROM Person WHERE Lastname = '" +
                    NurseLastNameTextBox.Text.ToString() + "'));" +

                    //insert blood type and validation
                    "INSERT INTO Blood (Type,ValidBlood)" + " VALUES('" +
                    DonationBloodTypeTextBox.Text.ToString() + "','" +
                    DonorValidationTextBox.Text.ToString() + "');" +


                    //insert description to donation type table
                    "INSERT INTO DonationType (Description)" + " VALUES('" +
                    DonationDescriptionTextBox.Text.ToString() + "');" +

                    //insert info to facility table
                    "INSERT INTO Facility (Address1,Address2,City,State,ZipCode,FacilityPhone)" + " VALUES('" +
                    FacilityAddress1TextBox.Text.ToString() + "','" +
                    FacilityAddress2TextBox.Text.ToString() + "','" +
                    FacilityCityTextBox.Text.ToString() + "','" +
                    FacilityStateTextBox.Text.ToString() + "','" +
                    FacilityZipCodeTextBox.Text.ToString() + "','" +
                    FacilityPhoneNumberTextBox.Text.ToString() + "');" +

                    //insert donation time when we add everything to the system
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
            cmd.CommandText = "SELECT * FROM nurse join person on(person.id=nurse.personid)";

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
