using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace mockTest
{
    public partial class UserManager : Form
    {
        private Login lg;
        private string uname;
        private const string connStr = "workstation id=ibtcollege.mssql.somee.com;packet size=4096;user id=ibtcollege_SQLLogin_1;pwd=dd69kxzi3m;data source=ibtcollege.mssql.somee.com;persist security info=False;initial catalog=ibtcollege";
        private const string PATH_TO_FILE = @"C:\backup.txt";
        private string uLastName;
        private string uEmail;
        private string unName;


        public UserManager()
        {
            InitializeComponent();
            lg = new Login();
            lg.ShowDialog();
            uname = lg.getUsername();
        }

        public static void WriteToFile(string text)
        {
            // always check whether file exists
            if (File.Exists(PATH_TO_FILE) == false)
            {
                File.Create(PATH_TO_FILE);
            }
            // Use Directory or DirectoryInfo for directories

            // use a stream class - ALWAYS CLOSE/DISPOSE STREAM CLASSES!
            // set append to true to add to the file instead of destroying it every time
            using (StreamWriter writer = new StreamWriter(PATH_TO_FILE, true))
            {
                writer.WriteLine(text);
                writer.Close();
            }
        }

        public void ShowData()
        {
            usersList.Items.Clear();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT * FROM STUDENTS";

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string usdata = reader["id"] + " " + reader["FirstName"] + " " + reader["LastName"] + " " + reader["EmailAddress"];
                        usersList.Items.Add(usdata);
                        //WriteToFile(usdata);
                    }
                }
            }

        }

        private void UserManager_Load(object sender, EventArgs e)
        {
            lUsername.Text = $"Welcome {uname}";

            ShowData();
        }

        private void LogoutButton_Click(object sender, EventArgs e)
        {
            lg.ShowDialog();
        }

        private void InsertButton_Click(object sender, EventArgs e)
        {
            unName = inName.Text;
            uLastName = inLastName.Text;
            uEmail = inEmail.Text;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = $"INSERT INTO STUDENTS (FirstName, LastName, EmailAddress) VALUES ('{unName}','{uLastName}','{uEmail}')";

                    cmd.ExecuteNonQuery();
                }
            }
            ShowData();
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            unName = inName.Text;
            uLastName = inLastName.Text;
            uEmail = inEmail.Text;
            
            string fullCmd;
            bool exe = true;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    //cmd.CommandText = $"UPDATE STUDENTS";
                    fullCmd = $"UPDATE STUDENTS ";

                    if (uNameChecked.Checked)
                    {
                        fullCmd += "SET ";

                        if (inLastName.Text != "")
                        {
                            fullCmd += $"LASTNAME='{uLastName}'";

                            if (inEmail.Text != "") fullCmd += ", ";
                        }

                        if(inEmail.Text != "")
                        {
                            fullCmd += $"EMAILADDRESS='{uEmail}'";
                        }

                        fullCmd += $" WHERE FIRSTNAME='{unName}'";
                    }
                    else if(uLastNameChecked.Checked)
                    {
                        fullCmd += "SET ";

                        if (inName.Text != "")
                        {
                            fullCmd += $"FIRSTNAME='{unName}'";

                            if (inEmail.Text != "") fullCmd += ", ";
                        }

                        if (inEmail.Text != "")
                        {
                            fullCmd += $"EMAILADDRESS='{uEmail}'";
                        }

                        fullCmd += $" WHERE LASTNAME='{uLastName}'";
                    }
                    else if(uEmailChecked.Checked)
                    {

                        fullCmd += "SET ";

                        if (inName.Text != "")
                        {
                            fullCmd += $"FIRSTNAME='{unName}'";

                            if (inLastName.Text != "") fullCmd += ", ";
                        }

                        if (inLastName.Text != "")
                        {
                            fullCmd += $"LASTNAME='{uLastName}' ";
                        }

                        fullCmd += $" WHERE EMAILADDRESS='{uEmail}'";
                    }
                    else
                    {
                        exe = false;
                    }

                    if (exe)
                    {
                        cmd.CommandText = fullCmd;
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            ShowData();

        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            unName = inName.Text;
            uLastName = inLastName.Text;
            uEmail = inEmail.Text;

            string fullCmd;
            bool exe = true;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    //cmd.CommandText = $"UPDATE STUDENTS";
                    fullCmd = $"DELETE FROM STUDENTS ";

                    if (uNameChecked.Checked)
                    {
                        fullCmd += $"WHERE FIRSTNAME='{unName}'";
                    }
                    else if (uLastNameChecked.Checked)
                    {
                        fullCmd += $"WHERE LASTNAME='{uLastName}'";
                    }
                    else if (uEmailChecked.Checked)
                    {
                        fullCmd += $"WHERE EMAILADDRESS='{uEmail}'";
                    }

                    if (exe)
                    {
                        cmd.CommandText = fullCmd;
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            ShowData();
        }
    }
}
