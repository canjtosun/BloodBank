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
    
    public partial class MainForm : Form
    {
        

        private const string INSERT_PERSON_COMMAND =
            "INSERT INTO Person (FirstName, MiddleName, LastName, PhoneNumber) VALUES ('{0}', '{1}', '{2}', '{3}');";

        private const string INSERT_DONOR_COMMAND =
            "INSERT INTO Donor (PersonID, BloodID) VALUES ('{0}', (SELECT Blood.ID FROM Blood WHERE Blood.Type = '{1}'));";

        private const string INSERT_NURSE_COMMAND =
            "INSERT INTO Nurse (PersonID) VALUES ('{0}');";

        private const string INSERT_FACILITY_COMMAND =
            "INSERT INTO Facility (Address1, Address2, City, State, ZipCode, FacilityPhone) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');";

        private const string INSERT_INVENTORY_COMMAND =
            "INSERT INTO Inventory (ID) VALUES(last_insert_id());";

        private const string INSERT_DONATION_COMMAND =
            "INSERT INTO Donation (DonorID, NurseID, DateTime, FacilityID, BloodBagId) " + 
            "values ({0}, {1}, now(), {2}, {3});";

        private const string INSERT_DONATIONTYPE_COMMAND =
            "INSERT INTO DonationType (Description) VALUES ('{0}');";

        private const string INSERT_BLOODBAG_COMMAND =
            "INSERT INTO BloodBag (Status, DonationTypeID) VALUES ('{0}', {1});";

        private const string GET_BLOODBAG_COMMAND =
            "SELECT * FROM BloodBag WHERE Status = '{0}' AND DonationTypeID = {1};";

        private const string GET_PERSON_COMMAND =
            "SELECT * FROM Person WHERE FirstName = '{0}' and MiddleName = '{1}' " +
            "and LastName = '{2}' and PhoneNumber = '{3}';";

        private const string GET_FACILITY_COMMAND =
            "SELECT * FROM Facility WHERE Address1 = '{0}' and Address2 = '{1}' and City = '{2}' and State = '{3}' and ZipCode = '{4}' and FacilityPhone = '{5}';";

        private const string GET_DONOR_COMMAND =
       "SELECT Donor.ID, Donor.PersonID, BloodID FROM Donor JOIN Person ON (Person.ID = Donor.PersonID) JOIN Blood ON (Blood.ID = Donor.BloodID) WHERE Person.ID = '{0}' and Blood.Type = '{1}';";

        private const string GET_NURSE_COMMAND =
        "SELECT Nurse.ID, Nurse.PersonID FROM Nurse JOIN Person ON (Person.ID = Nurse.PersonID) WHERE Person.ID = '{0}';";

        private const string GET_DONATION_COMMAND =
            "SELECT * FROM Donation WHERE DonorID = {0} AND NurseID = {1} AND FacilityID = {2};";

        private const string GET_DONATION_TYPE_COMMAND =
            "SELECT * FROM DonationType WHERE Description = '{0}';";

        //private const string GET_INVENTORY_COMMAND =
        //"SELECT Inventory.ID, Nurse.PersonID FROM Nurse JOIN Person ON (Person.ID = Nurse.PersonID) WHERE Person.ID = '{0}';";

        private const string UPDATE_FACILIY_COMMAND =
            "UPDATE Facility SET InventoryID = (last_insert_id()) WHERE ID = (last_insert_id());";

        //private const string UPDATE_DONOR_COMMAND =
        //"UPDATE Facility SET InventoryID = (last_insert_id()) WHERE ID = (last_insert_id())";

        

        //View blood donation information
        private const string VIEW_DONATION_INFO =
            "SELECT DInfo.*, NInfo.* " +
            "FROM " +
            "( " +
                "SELECT Donation.DateTime DateTime, BloodBag.Status Status, " +
                    "DonationType.Description Description, Blood.Type BloodType, " +
                    "Person.FirstName DonorFirstName, " +
                    "Person.LastName DonorLastName, " +
                    "Person.PhoneNumber DonorPhone " +
                "FROM Donation " +
                    "JOIN Donor ON (Donation.DonorID = Donor.ID) " +
                    "JOIN Person ON(Donor.PersonID = Person.ID) " +
                    "JOIN Blood ON(Donor.BloodID = Blood.ID) " +
                    "JOIN BloodBag ON(Donation.BloodBagID = BloodBag.ID) " +
                    "JOIN DonationType ON(BloodBag.DonationtypeID = DonationType.ID) " +
            ")DInfo, " +
            "( " +
                "SELECT Person.FirstName NurseFirstName, " +
                    "Person.LastName NurseLastName, " +
                    "Person.PhoneNumber NursePhone, " +
                    "Facility.City City, Facility.State State " +
                "FROM Donation " +
                    "JOIN Nurse ON(Donation.NurseID = Nurse.ID) " +
                    "JOIN Person ON(Nurse.PersonID = Person.ID) " +
                    "JOIN Facility ON(Donation.FacilityID = Facility.ID) " +
            ")NInfo " +
            "ORDER BY DInfo.Description;";


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




        //View inventory at all facilities
        private const string VIEW_FACILITY_INVENTORY =
            "SELECT COUNT(DonationType.Description) Count, Blood.Type BloodType, " +
                "DonationType.Description Description, " +
                "BloodBag.Status Status, Facility.Address1 Address1, " +
                "Facility.Address2 Address2, Facility.City City, " +
                "Facility.State State, Facility.ZipCode ZipCode, " +
                "Facility.FacilityPhone FacilityPhone " +
            "FROM Facility " +
                "JOIN Inventory ON(Facility.InventoryID = Inventory.ID) " +
                "LEFT JOIN BloodBag ON(Inventory.BloodBagID = BloodBag.ID) " +
                "LEFT JOIN DonationType ON(BloodBag.DonationTypeID = DonationType.ID) " +
                "LEFT JOIN Donation ON(BloodBag.ID = Donation.BloodBagID) " +
                "LEFT JOIN Donor ON(Donation.DonorID = Donor.ID) " +
                "LEFT JOIN Blood ON(Donor.BloodID = Blood.ID) " +
            "GROUP BY Facility.ID, Blood.Type, DonationType.Description, DonationType.Description;";

        //****** END View Button Queries  ********* 


        //private const string GET_BLOOD_COMMAND =
        //    "SELECT * FROM Blood WHERE ID = '{0}' and Type = '{1}';";

        static string connectionString = "SERVER=sql3.freemysqlhosting.net;PORT=3306;DATABASE=sql3326494;UID=sql3326494;PASSWORD=qwlhf4VVam";

        private MySqlConnection dbConnection;
        private MySqlCommand sqlCommand;

        public MainForm()
        {
            InitializeComponent();
            //Default Values fdor dropdown menus
            DonorBloodTypeBox.Text = "Select Blood Type";
            FacilityStateTextBox.Text = "Select State";
            BloodTypeViewTextBox.Text = "Select Blood Type";
            DescriptionViewTextBox.Text = "Select Description";
            BloodTypeViewTextBox6.Text = "Select Blood Type";
            DonationDonationTypeTextBox.Text = "Select Description";
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

            else
            {

                Donor donor = GetDonor(firstName, middleName, lastName, phoneNumber, bloodType);
                if (donor.ID != 0)
                {
                    MessageBox.Show("This donor already exists!");
                }
                else
                {
                    SQLCommand.CommandText = string.Format(INSERT_DONOR_COMMAND, person.ID, bloodType);
                    SQLCommand.ExecuteNonQuery();
                    MessageBox.Show("Successfully added a donor");
                }
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

            else {

                Nurse nurse = GetNurse(firstName, middleName, lastName, phoneNumber);
                if (nurse.ID != 0)
                {
                    MessageBox.Show("This nurse already exists!");
                }
                else {
                    SQLCommand.CommandText = string.Format(INSERT_NURSE_COMMAND, person.ID);
                    SQLCommand.ExecuteNonQuery();
                    MessageBox.Show("Successfully added a nurse");
                }
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
            }

            return nurse;
        }


        //end of person/donor/nurse relationship



        private int AddFacility(string Address1, string Address2, string City, string State, string ZipCode, string FacilityPhone)
        {
            Facility facility = GetFacility(Address1, Address2, City, State, ZipCode, FacilityPhone);

            if (facility.ID == 0)
            {
                SQLCommand.CommandText = string.Format(INSERT_FACILITY_COMMAND, Address1, Address2, City, State, ZipCode, FacilityPhone);
                SQLCommand.ExecuteNonQuery();
                SQLCommand.CommandText = string.Format(INSERT_INVENTORY_COMMAND, facility.ID);        
                SQLCommand.ExecuteNonQuery();
                MessageBox.Show("Success");
            }
            else
            {
                MessageBox.Show("This Facility already exists!");
            }

            return facility.ID;
        }


        private Facility GetFacility(string Address1, string Address2, string City, string State, string ZipCode, string FacilityPhone)
        {
            Facility facility = new Facility();
            SQLCommand.CommandText = string.Format(GET_FACILITY_COMMAND, Address1, Address2, City, State, ZipCode, FacilityPhone);

            using (MySqlDataReader rows = SQLCommand.ExecuteReader())
            {
                while (rows.Read())
                {
                    facility.ID = (int)rows["ID"];
                    facility.Address1 = rows["Address1"].ToString();
                    facility.Address2 = rows["Address2"].ToString();
                    facility.City = rows["City"].ToString();
                    facility.State = rows["State"].ToString();
                    facility.ZipCode = rows["ZipCode"].ToString();
                    facility.FacilityPhone = rows["FacilityPhone"].ToString();
                }
            }
            return facility;
        }

        private Donation GetDonation(int donorID, int nurseID, int facilityID)
        {
            Donation result = new Donation();

            int rowCount = 0;

            SQLCommand.CommandText = string.Format(GET_DONATION_COMMAND, donorID, nurseID, facilityID);

            using (MySqlDataReader rows = SQLCommand.ExecuteReader())
            {
                while (rows.Read())
                {
                    rowCount++;

                    if (rowCount > 1)
                    {
                        throw new Exception("GetDonation returned too many rows");
                    }

                    result.ID = (int)rows["ID"];
                    result.DonorID = (int)rows["DonorID"];
                    result.NurseID = (int)rows["NurseID"];
                    result.DateTime = DateTime.Parse(rows["DateTime"].ToString());
                    result.FacilityID = (int)rows["FacilityID"];
                    result.BloodBagID = (int)rows["BloodBagID"];
                }
            }

            return result;
        }

        //private int AddInventory(string Address1, string Address2, string City, string State, string ZipCode, string FacilityPhone)
        //{

        //    Facility facility = GetFacility(Address1, Address2, City, State, ZipCode, FacilityPhone);

        //    if (facility.ID == 0)
        //    {
        //        SQLCommand.CommandText = string.Format(INSERT_FACILITY_COMMAND, Address1, Address2, City, State, ZipCode, FacilityPhone);
        //        SQLCommand.ExecuteNonQuery();
        //        facility = GetFacility(Address1, Address2, City, State, ZipCode, FacilityPhone);
        //        SQLCommand.CommandText = string.Format(INSERT_INVENTORY_COMMAND, facility.ID);
        //        SQLCommand.ExecuteNonQuery();
        //        MessageBox.Show("Success");
        //    }

        //    return facility.ID;
        //}

        //private Inventory GetInventory(int ID, int BLoodBagID)
        //{
        //    Inventory inventory = new Inventory();
        //    int rowCount = 0;

        //    SQLCommand.CommandText = string.Format(GET_INVENTORY_COMMAND, ID);

        //    using (MySqlDataReader rows = SQLCommand.ExecuteReader())
        //    {
        //        while (rows.Read())
        //        {
        //            rowCount++;

        //            if (rowCount > 1)
        //            {
        //                throw new Exception("GetInventory returned too many rows");
        //            }

        //            inventory.ID = (int)rows["ID"];
        //        }
        //    }

        //    return inventory;
        //}

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
                    MessageBox.Show("Look up of DonorID is successful. See the output box.");
                    Result.Items.Clear();
                    Result.Items.Add("Donor ID: " + donorID).ToString();
                }
                else {
                    MessageBox.Show("Couldn't find this donor in the database. Please try again!");
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

        private void DonorUpdateButton_Click(object sender, EventArgs e)
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
                    Form2 f2 = new Form2();
                    f2.ShowDialog();  
                    
                   
                }
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
                    MessageBox.Show("Look up of NurseID is successful. See the output box.");
                    Result.Items.Clear();
                    Result.Items.Add("Nurse ID: " + nurseID).ToString();
                }
                else {
                    MessageBox.Show("Couldn't find this nurse in the database. Please try again!");
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

        private void FacilityLookUpIdButton_Click(object sender, EventArgs e)
        {
            if (FacilityAddress1TextBox.Text == "" || FacilityCityTextBox.Text == "" ||
               FacilityStateTextBox.Text == "" || FacilityZipCodeTextBox.Text == "")
            {
                MessageBox.Show("* field cannot be empty!");
            }

            else
            {
                Facility facility = GetFacility(FacilityAddress1TextBox.Text,
                FacilityAddress2TextBox.Text,
                FacilityCityTextBox.Text,
                FacilityStateTextBox.Text,
                FacilityZipCodeTextBox.Text,
                FacilityFacilityPhoneTextBox.Text);

                int facilityID = facility.ID;
                if (facilityID != 0)
                {
                    Result.Items.Add("Facility ID: " + facilityID).ToString();
                }
            }
        }





        //view Buttons

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void Explanation1View_Click(object sender, EventArgs e)
        {
            var value = BloodTypeViewTextBox.SelectedItem.ToString();


            string get_all_donors_info_with_blood_type =
            "SELECT Donor.ID DonorID, Blood.Type BloodType, Person.FirstName FirstName, Person.MiddleName MiddleName, " +
            "Person.LastName LastName,Person.PhoneNumber PhoneNumber" +
            " FROM Donor" +
            " JOIN Person ON(Donor.PersonID = Person.ID) JOIN Blood ON(Donor.BloodID = Blood.ID)" +
            " WHERE Blood.Type = '" + value + "';";

            SQLCommand.CommandText = string.Format(get_all_donors_info_with_blood_type);
      

            if (BloodTypeViewTextBox.Text == "")
                MessageBox.Show("Please choose blood type!");

            else
            {   
                using (MySqlDataReader rows = SQLCommand.ExecuteReader())
                {
                    Result.Items.Clear();

                    while (rows.Read())
                    {
                        
                        Result.Items.Add("Donor ID : " + rows["DonorID"]).ToString();
                        Result.Items.Add("First Name : " +rows["FirstName"]).ToString();
                        Result.Items.Add("Middle Name : " + rows["MiddleName"]).ToString();
                        Result.Items.Add("Last Name : " + rows["LastName"]).ToString();
                        Result.Items.Add("Phone Number : " + rows["PhoneNumber"]).ToString();
                        Result.Items.Add("Blood Type : " + rows["BloodType"]).ToString();
                        Result.Items.Add("---------------------------").ToString();
                        
                    }
                    
                }
            }
        }

        private void ShowAllDonorsButton_Click(object sender, EventArgs e)
        {
            string view_all_donors_command =
                    "SELECT Blood.ID BloodID, Blood.Type BloodType, Person.FirstName FirstName, " +
                        "Person.MiddleName MiddleName, Person.LastName LastName, " +
                        "Person.PhoneNumber PhoneNumber " +
                    "FROM Donor " +
                        "JOIN Person ON(Donor.PersonID = Person.ID) " +
                        "JOIN Blood ON(Donor.BloodID = Blood.ID) " +
                        "ORDER BY Blood.ID";

            SQLCommand.CommandText = string.Format(view_all_donors_command);

            using (MySqlDataReader rows = SQLCommand.ExecuteReader())
            {
                Result.Items.Clear();

                while (rows.Read())
                {
                    Result.Items.Add("First Name: " + rows["FirstName"]).ToString();
                    Result.Items.Add("Middle Name: " + rows["MiddleName"]).ToString();
                    Result.Items.Add("Last Name: " + rows["LastName"]).ToString();
                    Result.Items.Add("Phone Number: " + rows["PhoneNumber"]).ToString();
                    Result.Items.Add("Blood Type : " + rows["BloodType"]).ToString();
                    Result.Items.Add("---------------------------").ToString();

                }
            }
        }

        private void ShowAllNursesButton_Click(object sender, EventArgs e)
        {
            string view_all_nurses_command =
                    "SELECT Person.FirstName FirstName, " +
                        "Person.MiddleName MiddleName, Person.LastName LastName, " +
                        "Person.PhoneNumber PhoneNumber " +
                    "FROM Nurse " +
                        "JOIN Person ON(Nurse.PersonID = Person.ID) ";

            SQLCommand.CommandText = string.Format(view_all_nurses_command);

            using (MySqlDataReader rows = SQLCommand.ExecuteReader())
            {
                Result.Items.Clear();

                while (rows.Read())
                {
                    Result.Items.Add("First Name: " + rows["FirstName"]).ToString();
                    Result.Items.Add("Middle Name: " + rows["MiddleName"]).ToString();
                    Result.Items.Add("Last Name: " + rows["LastName"]).ToString();
                    Result.Items.Add("Phone Number: " + rows["PhoneNumber"]).ToString();
                    Result.Items.Add("---------------------------").ToString();
                }
            }
        }

        private void ShowAllFacilitiesButton_Click(object sender, EventArgs e)
        {
            string blood_donation_facilities =
                "SELECT Facility.ID ID, Facility.Address1 Address1, Facility.Address2 Address2, Facility.City City," +
                " Facility.State State, Facility.ZipCode ZipCode,Facility.FacilityPhone FacilityPhone " +
                "From Facility; ";

            SQLCommand.CommandText = string.Format(blood_donation_facilities);

            using (MySqlDataReader rows = SQLCommand.ExecuteReader())
            {
                Result.Items.Clear();

                while (rows.Read())
                {
                    Result.Items.Add("Facility ID: " + rows["ID"]).ToString();
                    Result.Items.Add("Adress1: " + rows["Address1"]).ToString();
                    Result.Items.Add("Adress2: " + rows["Address2"]).ToString();
                    Result.Items.Add("City: " + rows["City"]).ToString();
                    Result.Items.Add("ZipCode: " + rows["ZipCode"]).ToString();
                    Result.Items.Add("Facility Phone: " + rows["FacilityPhone"]).ToString();
                    Result.Items.Add("---------------------------").ToString();
                }
            }
        }

        private void DonationAddButton_Click(object sender, EventArgs e)
        {
            int donorID = int.Parse(DonationDonorIDTextBox.Text);
            int nurseID = int.Parse(DonationNurseIdTextBox.Text);
            int facilityID = int.Parse(DonationFacilityIdTextBox.Text);
            string donationTypeName = DonationDonationTypeTextBox.Text;

            if (donorID < 1 || nurseID < 1 || facilityID < 1 ||
                donationTypeName == string.Empty || donationTypeName == "Select Description") 
            {
                MessageBox.Show("* field cannot be empty!");
            }
            else
            {
                AddDonation(donorID, nurseID, facilityID, donationTypeName);
            }
        }

        private int AddDonation(int donorID, int nurseID, int facilityID, string donationTypeName)
        {
            Donation result = GetDonation(donorID, nurseID, facilityID);

            if (result.ID == 0)
            {
                DonationType donationType = AddOrGetDonationType(donationTypeName);
                BloodBag bloodBag = AddBloodBag(donationType.ID);
                SQLCommand.CommandText = string.Format(INSERT_DONATION_COMMAND, donorID, nurseID, facilityID, 
                    bloodBag.ID);
                SQLCommand.ExecuteNonQuery();
                result = GetDonation(donorID, nurseID, facilityID);
            }

            return result.ID;
        }

        private BloodBag AddBloodBag(int donationTypeID)
        {
            BloodBag result = new BloodBag();

            string status = Guid.NewGuid().ToString().Substring(0, 20);
            SQLCommand.CommandText = string.Format(INSERT_BLOODBAG_COMMAND, status, donationTypeID);
            SQLCommand.ExecuteNonQuery();

            result = GetBloodBag(status, donationTypeID);

            return result;
        }

        private BloodBag GetBloodBag(string status, int donationTypeID)
        {
            BloodBag result = new BloodBag();

            int rowCount = 0;
            SQLCommand.CommandText = string.Format(GET_BLOODBAG_COMMAND, status, donationTypeID);

            using (MySqlDataReader rows = SQLCommand.ExecuteReader())
            {
                while (rows.Read())
                {
                    rowCount++;

                    if (rowCount > 1)
                    {
                        throw new Exception("BloodBag returned too many rows");
                    }

                    result.ID = (int)rows["ID"];
                    result.Status = rows["Status"].ToString();
                    result.DonationTypeID = (int)rows["DonationTypeID"];
                }
            }

            return result;
        }

        private DonationType AddOrGetDonationType(string donationTypeName)
        {
            DonationType result = new DonationType();

            result = GetDonationType(donationTypeName);

            if (result.ID == 0)
            {
                SQLCommand.CommandText = string.Format(INSERT_DONATIONTYPE_COMMAND, donationTypeName);
                SQLCommand.ExecuteNonQuery();
                result = GetDonationType(donationTypeName);
                MessageBox.Show("Success");
            }

            return result;
        }

        private DonationType GetDonationType(string donationTypeName)
        {
            DonationType result = new DonationType();

            int rowCount = 0;
            SQLCommand.CommandText = string.Format(GET_DONATION_TYPE_COMMAND, donationTypeName);

            using (MySqlDataReader rows = SQLCommand.ExecuteReader())
            {
                while (rows.Read())
                {
                    rowCount++;

                    if (rowCount > 1)
                    {
                        throw new Exception("DonationType returned too many rows");
                    }

                    result.ID = (int)rows["ID"];                    
                    result.Description = rows["Description"].ToString();
                }
            }

            return result;
        }
    }
}