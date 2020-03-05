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
        public Form1()
        {
            InitializeComponent();
            
            try
            {
                MySqlConnection cnn;
                string connetionString = "SERVER=remotemysql.com;PORT=3306;DATABASE=N0hLjLJLCL;UID=N0hLjLJLCL;PASSWORD=oKQxuqRKgj";
                cnn = new MySqlConnection(connetionString);
                cnn.Open();
                MessageBox.Show("Connection Open ! ");
                cnn.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show("Can not open connection ! ");
            }
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
    }
}
