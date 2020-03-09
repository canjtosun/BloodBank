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
            "SELECT * FROM Person where FirstName = '{0}' and MiddleName = '{1}' " + 
            "and LastName = '{2}' and PhoneNumber = '{3}';";

        private const string INSERT_PERSON_COMMAND = 
            "INSERT INTO Person (FirstName, MiddleName, LastName, PhoneNumber) VALUES ('{0}', '{1}', '{2}', '{3}');";

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
                        throw new Exception("GetPerson resturned too many rows");
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

        private void DonorAddButton_Click(object sender, EventArgs e)
        {
            AddPerson(DonorFirstNameTextBox.Text, 
                DonorMiddleNameTextBox.Text, 
                DonorLastNameTextBox.Text, 
                DonorPhoneNumberTextBox.Text);

            //AddDonor(DonorFirstNameTextBox.Text,
            //    DonorMiddleNameTextBox.Text,
            //    DonorLastNameTextBox.Text,
            //    DonorPhoneNumberTextBox.Text,
            //    DonorBloodTypeBox)
        }

        private void NurseAddButton_Click(object sender, EventArgs e)
        {

        }

        private void FacilityAddButton_Click(object sender, EventArgs e)
        {

        }
    }
}
