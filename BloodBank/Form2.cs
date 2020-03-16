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
using Microsoft.VisualBasic;

namespace BloodBank
{
    public partial class Form2 : Form
    {

        static string connectionString = "SERVER=sql3.freemysqlhosting.net;PORT=3306;DATABASE=sql3326494;UID=sql3326494;PASSWORD=qwlhf4VVam";

        private MySqlConnection dbConnection;
        private MySqlCommand sqlCommand;

        public Form2()
        {
            InitializeComponent();
        }

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

        private void Form2DonorChangeButton_Click(object sender, EventArgs e)
        {

            string update_donor_command =
            "UPDATE Donor" +
            " SET FirstName = " + DonorFirstNameTextBox.Text + " , " +
            " MiddleName = " + DonorMiddleNameTextBox.Text + " , " +
            " LastName = " + DonorLastNameTextBox.Text + " , " +
            " PhoneNumber = " + DonorPhoneNumberTextBox.Text + ";";




            SQLCommand.CommandText = string.Format(update_donor_command);
            SQLCommand.ExecuteNonQuery();




        }
    }
}
