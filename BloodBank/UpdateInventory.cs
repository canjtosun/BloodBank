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
    public partial class UpdateInventory : Form
    {
        static string connectionString = "SERVER=sql3.freemysqlhosting.net;PORT=3306;DATABASE=sql3326494;UID=sql3326494;PASSWORD=qwlhf4VVam";

        private const string GET_DONATED_BLOODBAG_IDS =
            "SELECT BloodBag.ID as BloodBagId, Blood.Type BloodType, DonationType.Description DonationType, BloodBag.Status AS Status " +
            "FROM Facility " +
            "JOIN Inventory ON(Facility.InventoryID = Inventory.ID) " +
            "LEFT JOIN Donation ON(Donation.FacilityID = Facility.ID) " +
            "LEFT JOIN BloodBag ON(Donation.BloodBagId = BloodBag.ID) " +
            "LEFT JOIN DonationType ON(BloodBag.DonationTypeID = DonationType.ID) " +
            "LEFT JOIN Donor ON(Donation.DonorID = Donor.ID) " +
            "LEFT JOIN Blood ON(Donor.BloodID = Blood.ID) " +
            "WHERE Facility.ID = '{0}' AND DonationType.Description = '{1}' AND BloodBag.Status = 'Donated' AND Blood.Type = '{2}';";


        static int FacilityID;

        private MySqlConnection dbConnection;
        private MySqlCommand sqlCommand;

        public UpdateInventory()
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public void setFacilityID(int facilityID) {

            FacilityID = facilityID;

        }

        private void UpdateInventoryFormFinalButton_Click(object sender, EventArgs e)
        {
            int number_of_units_used = int.Parse(InputUnitsUsedTextBox.Text);

            int total_deleted = 0;
            for (int i = 0; i < number_of_units_used; i ++)
            {
                int bloodbagid = GetBloodBagIdToDelete();
                if (bloodbagid == 0)
                {
                    MessageBox.Show("No more blood bags of this blood type and donation type left, could use only " + total_deleted + " bloodbags.");
                }
                else
                {
                    SetBloodBagAsUsed(bloodbagid);
                    total_deleted++;
                }
                
            }

        }

        private int GetBloodBagIdToDelete()
        {
            int facility_id = FacilityID;
            string blood_type_used = InventorySelectBloodTypeBox.Text;
            string donation_type_used = InventorySelectDonationTypeBox.Text;
            SQLCommand.CommandText = string.Format(GET_DONATED_BLOODBAG_IDS, facility_id, donation_type_used, blood_type_used);

            int blood_bag_id_result = 0;
            int rowCount = 0;
            using (MySqlDataReader rows = SQLCommand.ExecuteReader())
            {

                while (rows.Read())
                {
                    rowCount++;

                    if (rowCount > 1)
                    {
                        break;
                    }

                    blood_bag_id_result = (int)rows["BloodBagId"];
                }
            }
            return blood_bag_id_result;
        }

        private void SetBloodBagAsUsed(int bloodbagid)
        {
            string UPDATE_BLOODBAG_COMMAND =
            "UPDATE BloodBag " +
            "SET Status=('Used') " +
            "WHERE ID = {0}; ";

            SQLCommand.CommandText = string.Format(UPDATE_BLOODBAG_COMMAND, bloodbagid);
            SQLCommand.ExecuteNonQuery();
        }
    }
}
