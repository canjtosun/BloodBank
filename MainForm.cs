﻿using System;
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

        private const string INSERT_DONOR_COMMAND =
            "INSERT INTO Donor (PersonID, BloodID) VALUES ('{0}', (SELECT Blood.ID FROM Blood WHERE Blood.Type = '{1}'));";

        private const string INSERT_NURSE_COMMAND =
            "INSERT INTO Nurse (PersonID) VALUES ('{0}');";

        private const string GET_FACILITY_COMMAND =
            "SELECT * FROM Facility WHERE Address1 = '{0}' and Address2 = '{1}' and City = '{2}' and State = '{3}' and ZipCode = '{4}' and FacilityPhone = '{5}';";

        private const string GET_DONOR_COMMAND =
       "SELECT Donor.ID, Donor.PersonID, BloodID FROM Donor JOIN Person ON (Person.ID = Donor.PersonID) JOIN Blood ON (Blood.ID = Donor.BloodID) WHERE Person.ID = '{0}' and Blood.Type = '{1}';";

        private const string GET_NURSE_COMMAND =
        "SELECT Nurse.ID, Nurse.PersonID FROM Nurse JOIN Person ON (Person.ID = Nurse.PersonID) WHERE Person.ID = '{0}';";

        //****** BEGIN View Button Queries  ********* 

        //View blood donation information (WORKS BUT CAN BE REFACTORED)
        private const string VIEW_DONATION_INFO =
            "SELECT BInfo.*, DInfo.*, NInfo.*, FInfo.* " +
            "FROM " +
            "( " +
                "SELECT  Donation.DateTime DateTime, BloodBag.Status Status, " +
                    "DonationType.Description Description " +
                "FROM Donation " +
                    "JOIN BloodBag ON (Donation.BloodBagID = BloodBag.ID) " +
                    "JOIN DonationType ON (BloodBag.DonationtypeID = DonationType.ID) " +
            ")BInfo, " +
            "( " +
                "SELECT  Blood.Type BloodType, Person.FirstName DonorFirstName, " +
                    "Person.LastName DonorLastName, " +
                    "Person.PhoneNumber DonorPhone " +
                "FROM Donation " +
                    "JOIN Donor ON (Donation.DonorID = Donor.ID) " +
                    "JOIN Person ON (Donor.PersonID = Person.ID) " +
                    "JOIN Blood ON (Donor.BloodID = Blood.ID) " +
            ")DInfo, " +
            "( " +
                "SELECT  Person.FirstName NurseFirstName, " +
                    "Person.LastName NurseLastName, " +
                    "Person.PhoneNumber NursePhone " +
                "FROM Donation " +
                    "JOIN Nurse ON (Donation.NurseID = Nurse.ID) " +
                    "JOIN Person ON (Nurse.PersonID = Person.ID) " +
            ")NInfo, " +
            "( " +
            "SELECT  Facility.City City, Facility.State State " +
            "FROM Donation " +
            "JOIN Facility ON (Donation.FacilityID = Facility.ID) " +
            ")FInfo; ";


        // View blood donations by type (we can add more information as needed, whatever makes sense) 
        private const string VIEW_DONATIONS_BY_TYPE =
            "SELECT Blood.Type BloodType, DonationType.Description Description, " +
                "BloodBag.Status Status, Donation.DateTime DateTime, " +
                "Person.FirstName, Person.LastName, Person.PhoneNumber, " +
                "Facility.City City, Facility.State State " +
            "FROM Donation " +
                "JOIN Donor ON(Donation.DonorID = Donor.ID) " +
                "JOIN Person ON(Donor.PersonID = Person.ID) " +
                "JOIN Blood ON(Donor.BloodID = Blood.ID) " +
                "JOIN BloodBag ON(Donation.BloodBagID = BloodBag.ID) " +
                "JOIN DonationType ON(BloodBag.DonationTypeID = DonationType.ID) " +
                "JOIN Facility ON(Donation.FacilityID = Facility.ID) " +
            "ORDER BY Blood.Type;";


        // View donors by type of blood with phone number (ordered by bloodType).
        private const string VIEW_DONORS_BY_BLOODTYPE =
            "SELECT Blood.Type BloodType, Person.FirstName FirstName, " +
                "Person.MiddleName MiddleName, Person.LastName LastName, " +
                "Person.PhoneNumber PhoneNumber " +
            "FROM Donor " +
                "JOIN Person ON(Donor.PersonID = Person.ID) " +
                "JOIN Blood ON(Donor.BloodID = Blood.ID) " +
             "ORDER BY BloodType;";


        // View blood donation Facilities
        private const string VIEW_FACILITIES =
            "SELECT Facility.Address1 Address1, Facility.Address2 Address2, Facility.City City, " +
                "Facility.State State, Facility.ZipCode ZipCode, " +
                "Facility.FacilityPhone FacilityPhone " +
            "FROM Facility; ";


        //View inventory at all facilities (in-progress)


        //****** END View Button Queries  ********* 


        //private const string GET_BLOOD_COMMAND =
        //    "SELECT * FROM Blood WHERE ID = '{0}' and Type = '{1}';";

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
                MessageBox.Show("Success");
            }

            return result.ID;
        }

        private int AddDonor(string firstName, string middleName, string lastName, string phoneNumber, string bloodType)
        {
            Person person = GetPerson(firstName, middleName, lastName, phoneNumber);

            if (person.ID == 0)
            {
                SQLCommand.CommandText = string.Format(INSERT_PERSON_COMMAND, firstName, middleName, lastName, phoneNumber);
                SQLCommand.ExecuteNonQuery();
                person = GetPerson(firstName, middleName, lastName, phoneNumber);
                SQLCommand.CommandText = string.Format(INSERT_DONOR_COMMAND, person.ID, bloodType);
                SQLCommand.ExecuteNonQuery();
                MessageBox.Show("Success");
            }

            return person.ID;
        }

        private int AddNurse(string firstName, string middleName, string lastName, string phoneNumber)
        {
            Person person = GetPerson(firstName, middleName, lastName, phoneNumber);

            if (person.ID == 0)
            {
                SQLCommand.CommandText = string.Format(INSERT_PERSON_COMMAND, firstName, middleName, lastName, phoneNumber);
                SQLCommand.ExecuteNonQuery();
                person = GetPerson(firstName, middleName, lastName, phoneNumber);
                SQLCommand.CommandText = string.Format(INSERT_NURSE_COMMAND, person.ID);
                SQLCommand.ExecuteNonQuery();
                MessageBox.Show("Success");
            }

            return person.ID;
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

        private Donor GetDonor(string firstName, string middleName, string lastName, string phoneNumber, string bloodType)
        {
            Donor donor = new Donor();
            int rowCount = 0;
            Person person = GetPerson(firstName, middleName, lastName, phoneNumber);

            if (person.ID != 0)
            {
                SQLCommand.CommandText = string.Format(GET_DONOR_COMMAND, person.ID, bloodType);

                using (MySqlDataReader rows = SQLCommand.ExecuteReader())
                {
                    while (rows.Read())
                    {
                        rowCount++;

                        if (rowCount > 1)
                        {
                            throw new Exception("GetDonorID returned too many rows");
                        }

                        donor.ID = (int)rows["ID"];
                        donor.PersonID = (int)rows["PersonID"];
                        donor.BloodID = (int)rows["BloodID"];
                    }
                }
                MessageBox.Show("Look up of DonorID is successful. See the output box.");
            }
            else
            {
                MessageBox.Show("Couldn't find this donor in the database. Please try again!");
            }

            return donor;
        }

        private Nurse GetNurse(string firstName, string middleName, string lastName, string phoneNumber)
        {
            Nurse nurse = new Nurse();
            int rowCount = 0;
            Person person = GetPerson(firstName, middleName, lastName, phoneNumber);

            if(person.ID != 0)
            {
                SQLCommand.CommandText = string.Format(GET_NURSE_COMMAND, person.ID);

                using (MySqlDataReader rows = SQLCommand.ExecuteReader())
                {
                    while (rows.Read())
                    {
                        rowCount++;

                        if (rowCount > 1)
                        {
                            throw new Exception("GetNurseID returned too many rows");
                        }

                        nurse.ID = (int)rows["ID"];
                        nurse.PersonID = (int)rows["PersonID"];                    
                    }
                }
                MessageBox.Show("Look up of NurseID is successful. See the output box.");
            }
            else
            {
                MessageBox.Show("Couldn't find this nurse in the database. Please try again!");
            }

            return nurse;
        }
        



        private int AddFacility(string Address1, string Address2, string City, string State, string ZipCode, string FacilityPhone)
        {
            string insert_facility_command =
            "INSERT INTO Facility (Address1, Address2, City, State, ZipCode, FacilityPhone) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');";




            INSERT INTO Inventory(ID)
            VALUES(last_insert_rowid());

            UPDATE Facility
            SET InventoryID = (last_insert_rowid())
            WHERE ID = last_insert_rowid();


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

            else
            {
                AddDonor(DonorFirstNameTextBox.Text,
                DonorMiddleNameTextBox.Text,
                DonorLastNameTextBox.Text,
                DonorPhoneNumberTextBox.Text,
                DonorBloodTypeBox.Text);
            }
            
        }

        private void DonorLookUpIdButton_Click(object sender, EventArgs e)
        {
            if (DonorFirstNameTextBox.Text == "" || DonorLastNameTextBox.Text == "" ||
                DonorPhoneNumberTextBox.Text == "")
                MessageBox.Show("* field cannot be empty!");

            else
            {
                Donor donor = GetDonor(DonorFirstNameTextBox.Text,
                DonorMiddleNameTextBox.Text,
                DonorLastNameTextBox.Text,
                DonorPhoneNumberTextBox.Text,
                DonorBloodTypeBox.Text);

                int donorID = donor.ID;
                if (donorID != 0)
                {
                    Result.Items.Add("Donor ID: " + donorID).ToString();
                }
            }

        }

        private void NurseAddButton_Click(object sender, EventArgs e)
        {

            if (NurseFirstNameTextBox.Text == "" || NurseLastNameTextBox.Text == "" ||
                NursePhoneNumberTextBox.Text == "")
                MessageBox.Show("* field cannot be empty!");

            else
            {
                AddNurse(NurseFirstNameTextBox.Text,
                NurseMiddleNameTextBox.Text,
                NurseLastNameTextBox.Text,
                NursePhoneNumberTextBox.Text);
            }

        }

        private void NurseLookUpIdButton_Click(object sender, EventArgs e)
        {
            if (NurseFirstNameTextBox.Text == "" || NurseLastNameTextBox.Text == "" ||
                NursePhoneNumberTextBox.Text == "")
                MessageBox.Show("* field cannot be empty!");

            else
            {
                Nurse nurse = GetNurse(NurseFirstNameTextBox.Text,
                NurseMiddleNameTextBox.Text,
                NurseLastNameTextBox.Text,
                NursePhoneNumberTextBox.Text);

                int nurseID = nurse.ID;
                if (nurseID != 0)
                {
                    Result.Items.Add("Nurse ID: " + nurseID).ToString();
                }
            }
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
