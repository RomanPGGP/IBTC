using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WRKT.Models;
using System.Data.SqlClient;
using System.Security.Claims;

namespace WRKT.Controllers
{
    public class EmployerController : Controller
    {
        public List<TimeSlots> timeSlots2bs = new List<TimeSlots>();
        public IActionResult Index()
        {
            SqlConnection connection;
            SqlCommand scommand;
            string connectionString = "workstation id=WRKTAPP.mssql.somee.com;packet size=4096;user id=RomanPG_SQLLogin_1;pwd=2u9ukyu3ge;" +
                                                    "data source=WRKTAPP.mssql.somee.com;persist security info=False;initial catalog=WRKTAPP";
            ClaimsPrincipal currentUser = this.User;
            string usermaildb = currentUser.Identity.Name;
            int EmployerID = 0;

            using (connection = new SqlConnection(connectionString))
            {

                try
                {
                    connection.Open();
                }
                catch (Exception)
                {

                    throw; //Connection error
                }

                using (scommand = new SqlCommand())
                {
                    scommand.Connection = connection;

                    /*RECEIVE USER DATA!!*/
                    scommand.CommandText = "SELECT EmployerID FROM EMPLOYER_DATA WHERE Email = '" + usermaildb + "'";

                    SqlDataReader employerIDReader;

                    try
                    {
                        employerIDReader = scommand.ExecuteReader();
                    }
                    catch (Exception)
                    {

                        throw;
                    }

                    while (employerIDReader.Read()) {

                        EmployerID = Int32.Parse(employerIDReader["EmployerID"].ToString());
                    }


                    employerIDReader.Close();

                    //******************************

                    scommand.CommandText = "SELECT * FROM TIMESHEET_DATA WHERE EmployerID = '" + EmployerID + "'";

                    SqlDataReader employerListReader;

                    try
                    {
                        employerListReader = scommand.ExecuteReader();
                    }
                    catch (Exception)
                    {

                        throw;
                    }


                    while (employerListReader.Read())
                    {
                        {
                            TimeSlots auxobj = new TimeSlots
                            {
                                EmployerID = Int32.Parse(employerListReader["EmployerID"].ToString()),
                                VenueID = Int32.Parse(employerListReader["VenueID"].ToString()),
                                StartHour = Convert.ToDateTime(employerListReader["StartHour"].ToString()),
                                //auxobj.StartHour = Convert.ToDateTime(employerListReader["Date"].ToString());
                                FinishHour = Convert.ToDateTime(employerListReader["FinishHour"].ToString()),
                                EmployeeID = Int32.Parse(employerListReader["EmployeeID"].ToString())
                            };
                            timeSlots2bs.Add(auxobj);
                        }
                    }


                    employerListReader.Close();
                }
            }

            return View(timeSlots2bs);
        }
    }
}