using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WRKT.Models;
using System.Data.SqlClient;

namespace WRKT.Controllers
{
    public class HomeController : Controller
    {
        static public string connectionString = "workstation id=WRKTAPP.mssql.somee.com;packet size=4096;user id=RomanPG_SQLLogin_1;pwd=2u9ukyu3ge;" +
                                                "data source=WRKTAPP.mssql.somee.com;persist security info=False;initial catalog=WRKTAPP";
        static public SqlConnection connection;
        static public SqlCommand scommand;

        public IActionResult Index()
        {
            using(connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                }
                catch (Exception)
                {

                    throw;
                }

                using (scommand = new SqlCommand())
                {
                    scommand.Connection = connection;
                    scommand.CommandText = "Select Email FROM EMPLOYEE_DATA";

                    SqlDataReader sdatareader = scommand.ExecuteReader();

                    while (sdatareader.Read())
                    {
                        string employeeEmail = sdatareader["Email"].ToString();
                        ViewData["UserMail"] = employeeEmail;
                    }

                    sdatareader.Close();
                }

            }
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "WRKT is all about teams";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Please contact your Admin";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
