using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Data.SqlClient;

namespace WRKT.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        static public SqlConnection connection;
        static public SqlCommand scommand;
        static public string connectionString = "workstation id=WRKTAPP.mssql.somee.com;packet size=4096;user id=RomanPG_SQLLogin_1;pwd=2u9ukyu3ge;" +
                                                "data source=WRKTAPP.mssql.somee.com;persist security info=False;initial catalog=WRKTAPP";


        public RegisterModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public class InputModel
        {
            [Required]
            [Display(Name = "FirstName")]
            public string FirstName { get; set; }

            [Required]
            [Display(Name = "LastName")]
            public string LastName { get; set; }

            [Required]
            [Phone]
            [Display(Name = "PhoneNumber")]
            [RegularExpression(@"^(\d{10})$", ErrorMessage = "Please provide a valid phone number")]
            public string PhoneNumber { get; set; }

            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
            
            [Required]
            [Display(Name = "EmployerID")]
            public int EmployerID { get; set; }

            [Required]
            [Display(Name = "Employer")]
            public bool Administrator { get; set; }
            
        }

        public void OnGet(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = Input.FirstName, Email = Input.Email };
                var result = await _userManager.CreateAsync(user, Input.Password);

                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    // Save in DB **************************************************************
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

                            if (Input.Administrator)
                            {
                                scommand.CommandText = "INSERT INTO EMPLOYER_DATA (EmployerID,FirstName,LastName,EmployeeCount,PhoneNumber,Email,Password) " +
                                                   " VALUES(@id,@firstname,@lastname,@employercount,@phonenumber,@mail,@password)";

                                scommand.Parameters.AddWithValue("@id", 55);
                                scommand.Parameters.AddWithValue("@firstname", Input.FirstName);
                                scommand.Parameters.AddWithValue("@lastname", Input.LastName);
                                scommand.Parameters.AddWithValue("@employercount", 0);
                                scommand.Parameters.AddWithValue("@phonenumber", Input.PhoneNumber);
                                scommand.Parameters.AddWithValue("@mail", Input.Email);
                                scommand.Parameters.AddWithValue("@password", Input.Password);

                            }
                            else
                            {
                                scommand.CommandText = "INSERT INTO EMPLOYEE_DATA (EmployeeID,FirstName,LastName,PhoneNumber,Email,EmployerID,Password) " +
                                                   " VALUES(@id,@firstname,@lastname,@phonenumber,@mail,@employerid,@password)";

                                scommand.Parameters.AddWithValue("@id", 105);
                                scommand.Parameters.AddWithValue("@firstname", Input.FirstName);
                                scommand.Parameters.AddWithValue("@lastname", Input.LastName);
                                scommand.Parameters.AddWithValue("@phonenumber", Input.PhoneNumber);
                                scommand.Parameters.AddWithValue("@mail", Input.Email);
                                scommand.Parameters.AddWithValue("@employerid", Input.EmployerID);
                                scommand.Parameters.AddWithValue("@password", Input.Password);

                            }
                            
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
                    //*****************************************************************

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { userId = user.Id, code = code },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return LocalRedirect(returnUrl);
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
