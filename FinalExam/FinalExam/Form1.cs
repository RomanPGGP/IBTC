using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalExam
{
    public partial class Form1 : Form
    {

        private const string connStr = "workstation id=ibtcollege.mssql.somee.com;packet size=4096;user id = ibtcollege_SQLLogin_1; pwd=dd69kxzi3m;data source = ibtcollege.mssql.somee.com; persist security info=False;initial catalog = ibtcollege";
        private const string PATH_TO_FILE = @"C:\TeamList.txt";
        private List<string> dataBaseFields;
        private List<TextBox> inFields;
        private List<CheckBox> fieldsCheckBoxes;

        public Form1()
        {
            InitializeComponent();

            fieldsCheckBoxes = new List<CheckBox>
            {
                teamNameCB,
                coachNameCB,
                directorNameCB,
                emailCB
            };

            inFields = new List<TextBox>() {
                inTeamName,
                inCoachName,
                inDirectorName,
                inAddressLine1,
                inAddressLine2,
                inPostCode,
                inCity,
                inContactNumber,
                inEmail
            };

            dataBaseFields = new List<string>
            {
                "TeamName",
                "CoachName",
                "DirectorName",
                "AddressLine1",
                "AddressLine2",
                "PostCode",
                "City",
                "ContactNumber",
                "EmailAddress"
            };
        }

        public static void WriteToFile(string text)
        {
            if (File.Exists(PATH_TO_FILE) == false)
            {
                File.Create(PATH_TO_FILE);
            }
            
            using (StreamWriter writer = new StreamWriter(PATH_TO_FILE, true))
            {
                writer.WriteLine(text);
                writer.Close();
            }
        }

        private void validateUserInput()
        {
            int counter = 0;

            if ((inFields[7].Text.Length > 0) && (inFields[7].Text.Length < 10))
            {
                warningLb.Text = "Please insert a 10 digits number.";

                throw new InvalidOperationException("Please insert a 10 digits number");
            }

            if (inFields[8].Text != "" && !inFields[8].Text.Contains("@"))
            {
                warningLb.Text = "Please insert a valid email address.";
                throw new InvalidOperationException("Please insert a valid email address");
            }

            foreach(var s in inFields)
            {
                if(s.Text.Contains("'"))
                {
                    warningLb.Text = $"invalid Field {dataBaseFields[counter]}";
                    throw new InvalidOperationException($"invalid Field {dataBaseFields[counter]}");
                }

                counter++;
            }
        }


        private void ShowData()
        {
            DBShow.Items.Clear();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlDataReader reader;

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT * FROM TEAMS";

                    try
                    {
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            string usdata = reader["Teamid"] + " ";

                            foreach(string x in dataBaseFields)
                            {
                                usdata += reader[x] + " ";
                            }

                            DBShow.Items.Add(usdata);
                            //WriteToFile(usdata);
                        }
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }

                }
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ShowData();
        }

        private void InsertButton_Click(object sender, EventArgs e)
        {
            string fullCmd;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    fullCmd = "INSERT INTO TEAMS (";

                    foreach(string x in dataBaseFields)
                    {
                        fullCmd += x;

                        if (x != "EmailAddress") fullCmd += ",";
                        else fullCmd += ",Createdby) VALUES (";
                    }

                    foreach(var y in inFields)
                    {
                        fullCmd += $"'{y.Text}'";

                        if (!y.Text.Contains("@")) fullCmd += ", ";
                        else fullCmd += ",'Roman Perez')";
                    }

                    cmd.CommandText = fullCmd;

                    try
                    {
                        validateUserInput();
                        cmd.ExecuteNonQuery();
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                }
            }

            ShowData();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            string fullCmd;
            int counter = 0;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    fullCmd = "DELETE FROM TEAMS ";

                    foreach(var x in fieldsCheckBoxes)
                    {
                        if (counter == 3) counter = 8;

                        if (x.Checked)
                        {
                            fullCmd += $"WHERE {dataBaseFields[counter]} = '{inFields[counter].Text}'";
                            break;
                        }

                        counter++;
                    }
                    
                    cmd.CommandText = fullCmd;

                    try
                    {
                        validateUserInput();
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                }
            }

            ShowData();
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            string fullCmd;
            int counter = 0;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    fullCmd = "UPDATE TEAMS SET ";
                    counter = 0;
                    foreach (var f in inFields)
                    {
                        if(f.Text != "")
                        {
                            fullCmd += $"{dataBaseFields[counter]} =  '{inFields[counter].Text}',";
                        }

                        counter++;
                    }

                    fullCmd = fullCmd.Remove(fullCmd.Length - 1);

                    counter = 0;
                    foreach (var x in fieldsCheckBoxes)
                    {
                        if (counter == 3) counter = 8;

                        if (x.Checked)
                        {
                            fullCmd += $" WHERE {dataBaseFields[counter]} = '{inFields[counter].Text}'";
                            break;
                        }

                        counter++;
                    }

                    cmd.CommandText = fullCmd;

                    try
                    {
                        validateUserInput();
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                }
            }

            ShowData();
        }
    }
}
