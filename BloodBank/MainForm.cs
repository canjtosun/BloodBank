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
    public partial class MainForm : Form
    {
        private const string GET_PERSON_COMMAND =
            "SELECT * FROM Person WHERE FirstName = '{0}' and MiddleName = '{1}' " +
            "and LastName = '{2}' and PhoneNumber = '{3}';";

        private const string INSERT_PERSON_COMMAND =
            "INSERT INTO Person (FirstName, MiddleName, LastName, PhoneNumber) VALUES ('{0}', '{1}', '{2}', '{3}');";

        private const string GET_FACILITY_COMMAND =
            "SELECT * FROM Facility WHERE Address1 = '{0}' and Address2 = '{1}' and City = '{2}' and State = '{3}' and ZipCode = '{4}' and FacilityPhone = '{5}';";

        static string connectionString = "SERVER=sql3.freemysqlhosting.net;PORT=3306;DATABASE=sql3326494;UID=sql3326494;PASSWORD=qwlhf4VVam";

        private MySqlConnection dbConnection;
        private MySqlCommand sqlCommand;

        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Property that encapsulates the MySql connection object
        /// </summary>
        private MySqlConnection DBConnection
        {
            get
            {
                // if the connection does not exist, create it
                if (dbConnection == null)
                {
                    dbConnection = new MySqlConnection(connectionString);
                }

                // if it's not open, open it
                if (dbConnection.State != ConnectionState.Open)
                {
                    try
                    {
                        dbConnection.Open();
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message, "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                // return it to the caller
                return dbConnection;
            }
        }

        /// <summary>
        /// Property wrapper for sqlCommand object
        /// </summary>
        private MySqlCommand SQLCommand
        {
            get
            {
                if (sqlCommand == null)
                {
                    sqlCommand = new MySqlCommand();
                }

                if (sqlCommand.Connection == null)
                {
                    sqlCommand.Connection = DBConnection;
                }

                return sqlCommand;
            }
        }

        private int AddPerson(string firstName, string middleName, string lastName, string phoneNumber)
        {
            Person result = GetPerson(firstName, middleName, lastName, phoneNumber);

            if (result.ID == 0)
            {
                SQLCommand.CommandText = string.Format(INSERT_PERSON_COMMAND, firstName, middleName, lastName, phoneNumber);
                SQLCommand.ExecuteNonQuery();
                MessageBox.Show("Success");
                result = GetPerson(firstName, middleName, lastName, phoneNumber);
            }

            return result.ID;
        }

        private Person GetPerson(string firstName, string middleName, string lastName, string phoneNumber)
        {
            Person result = new Person();
            int rowCount = 0;

            SQLCommand.CommandText = string.Format(GET_PERSON_COMMAND, firstName, middleName, lastName, phoneNumber);

            using (MySqlDataReader rows = SQLCommand.ExecuteReader())
            {
                while (rows.Read())
                {
                    rowCount++;

                    if (rowCount > 1)
                    {
                        throw new Exception("GetPerson returned too many rows");
                    }

                    result.ID = (int)rows["ID"];
                    result.FirstName = rows["FirstName"].ToString();
                    result.MiddleName = rows["MiddleName"].ToString();
                    result.LastName = rows["LastName"].ToString();
                    result.PhoneNumber = rows["PhoneNumber"].ToString();
                }
            }

            return result;
        }

        private int AddFacility(string Address1, string Address2, string City, string State, string ZipCode, string FacilityPhone)
        {
            string insert_facility_command =
            "INSERT INTO Facility (Address1, Address2, City, State, ZipCode, FacilityPhone) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');";

            Facility result = GetFacility(Address1, Address2, City, State, ZipCode, FacilityPhone);

            if (result.ID == 0)
            {
                SQLCommand.CommandText = string.Format(insert_facility_command, Address1, Address2, City, State, ZipCode, FacilityPhone);
                SQLCommand.ExecuteNonQuery();
                MessageBox.Show("Success");
                result = GetFacility(Address1, Address2, City, State, ZipCode, FacilityPhone);
            }

            return result.ID;
        }

        private Facility GetFacility(string Address1, string Address2, string City, string State, string ZipCode, string FacilityPhone)
        {
            Facility result = new Facility();
            int rowCount = 0;

            SQLCommand.CommandText = string.Format(GET_FACILITY_COMMAND, Address1, Address2, City, State, ZipCode, FacilityPhone);

            using (MySqlDataReader rows = SQLCommand.ExecuteReader())
            {
                while (rows.Read())
                {
                    rowCount++;

                    if (rowCount > 1)
                    {
                        throw new Exception("GetFacility returned too many rows");
                    }

                    result.ID = (int)rows["ID"];
                    result.Address1 = rows["Address1"].ToString();
                    result.Address2 = rows["Address2"].ToString();
                    result.City = rows["City"].ToString();
                    result.State = rows["State"].ToString();
                    result.ZipCode = rows["ZipCode"].ToString();
                    result.FacilityPhone = rows["FacilityPhone"].ToString();
                }
            }

            return result;
        }



        private void DonorAddButton_Click(object sender, EventArgs e)
        {

            if (DonorFirstNameTextBox.Text == "" || DonorLastNameTextBox.Text == "" ||
                DonorPhoneNumberTextBox.Text == "")
                MessageBox.Show("* field cannot be empty!");

            AddPerson(DonorFirstNameTextBox.Text,
                DonorMiddleNameTextBox.Text,
                DonorLastNameTextBox.Text,
                DonorPhoneNumberTextBox.Text);
        }

        private void NurseAddButton_Click(object sender, EventArgs e)
        {

            if (NurseFirstNameTextBox.Text == "" || NurseLastNameTextBox.Text == "" ||
                NursePhoneNumberTextBox.Text == "")
                MessageBox.Show("* field cannot be empty!");

            AddPerson(DonorFirstNameTextBox.Text,
                DonorMiddleNameTextBox.Text,
                DonorLastNameTextBox.Text,
                DonorPhoneNumberTextBox.Text);
        }

        private void FacilityAddButton_Click(object sender, EventArgs e)
        {

            if (FacilityAddress1TextBox.Text == "" || FacilityCityTextBox.Text == "" ||
                FacilityStateTextBox.Text == "" || FacilityZipCodeTextBox.Text == "")
            {
                MessageBox.Show("* field cannot be empty!");
            }

            else
            {
                AddFacility(FacilityAddress1TextBox.Text,
                FacilityAddress2TextBox.Text,
                FacilityCityTextBox.Text,
                FacilityStateTextBox.Text,
                FacilityZipCodeTextBox.Text,
                FacilityFacilityPhoneTextBox.Text); ;
            }
        }


        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
