using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace WRKT.Controllers
{
    public class EmployeeController : Controller
    {

        static public DateTime date2DB;

        public IActionResult Index()
        {
            return View("EmployeeHome");
        }

        public IActionResult postWorkedHours(string startHour, string endHour, string venue)
        {
            SqlConnection connection;
            SqlCommand scommand;
            string connectionString = "workstation id=WRKTAPP.mssql.somee.com;packet size=4096;user id=RomanPG_SQLLogin_1;pwd=2u9ukyu3ge;" +
                                                    "data source=WRKTAPP.mssql.somee.com;persist security info=False;initial catalog=WRKTAPP";
            
            ClaimsPrincipal currentUser = this.User;
            string usermaildb = currentUser.Identity.Name;
            int userEmployeeID = 0;
            int userEmployerID = 0;

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
                    scommand.CommandText = "SELECT * FROM EMPLOYEE_DATA WHERE Email = '" + usermaildb + "'";

                    SqlDataReader userReader;

                    try
                    {
                        userReader = scommand.ExecuteReader();
                    }
                    catch (Exception)
                    {

                        throw;
                    }

                    bool x = userReader.Read();

                    userEmployeeID = Int32.Parse(userReader["EmployeeID"].ToString());
                    userEmployerID = Int32.Parse(userReader["EmployerID"].ToString());
                    
                    userReader.Close();

                    //******************************

                    scommand.CommandText = "INSERT INTO TIMESHEET_DATA (TimesheetID,EmployeeID,VenueID,StartHour,FinishHour,Date,EmployerID) " +
                                           " VALUES(@timesheetid,@employeeid,@venueid,@starthour,@finishhour,@date,@employerid)";
                    
                    //UserManager.GetUserName(User)
                    scommand.Parameters.AddWithValue("@timesheetid", 38);
                    scommand.Parameters.AddWithValue("@employeeid", userEmployeeID);
                    scommand.Parameters.AddWithValue("@venueid", venue);
                    scommand.Parameters.AddWithValue("@starthour", startHour);
                    scommand.Parameters.AddWithValue("@finishhour", endHour);
                    scommand.Parameters.AddWithValue("@date", date2DB);
                    scommand.Parameters.AddWithValue("@employerid", userEmployerID);

                    try
                    {
                        scommand.ExecuteNonQuery();
                    }
                    catch (Exception)
                    {

                        throw; //Parameters error
                    }
                }
            }
            return View("EmployeeHome");
        }

        public IActionResult calendarClick(string day)
        {
            int dayToPost = Int32.Parse(day);
            DateTime dateaux = DateTime.Now;
            date2DB = new DateTime(dateaux.Year, dateaux.Month, dayToPost);
            
            return View("PostHour", date2DB);
        }
    }
}