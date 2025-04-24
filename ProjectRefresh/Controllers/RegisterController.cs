using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using ProjectRefresh.Data;
using ProjectRefresh.Models;
using System.Diagnostics;
using System.Security.Claims;
using System.Text.RegularExpressions;
using System.Linq;

namespace ProjectRefresh.Controllers
{
    public class RegisterController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RegisterController(ApplicationDbContext context)
        {
            _context = context;
        }



        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string name, string email, string password, string phone_number, string address, string repassword)
        {
            ViewBag.NameError = null;
            ViewBag.EmailError = null;
            ViewBag.PasswordError = null;
            ViewBag.PhoneNumberError = null;
            ViewBag.AddressError = null;
            if (string.IsNullOrEmpty(name) || name.Trim().Length > 200)
            {
                ViewBag.NameError = "Name must be between 1 and 200 characters!";
            }

            if (string.IsNullOrEmpty(email) || email.Trim().Length > 100)
            {
                ViewBag.EmailError = "Email must be between 1 and 100 characters!";
            }
            else
            {
                int ad = 0;
                int dot = 0;
                int adPos = -1;
                int dotPos = -1;
                for (var i = 0; i < email.Length; i++)
                {
                    if (email[i] == '@')
                    {
                        ad++;
                        adPos = i;
                    }
                    else if (email[i] == '.')
                    {
                        dot++;
                        dotPos = i;
                    }
                }
                if (!email.Contains('@') || ad > 1)
                {
                    ViewBag.EmailError = "Email must contain exactly 1 @";
                }
                else if (dot <= 0)
                {
                    ViewBag.EmailError = "Email must contain .!";
                }
                else if (dotPos < adPos)
                {
                    ViewBag.EmailError = ". must come after @!";
                }
            }

            if (string.IsNullOrEmpty(password) || password.Trim().Length > 100)
            {
                ViewBag.PasswordError = "Password must be between 1 and 100 characters!";
            }
            else if (!password.Equals(repassword))
            {
                ViewBag.PasswordError = "Passwords do not match!";
            }

            if (string.IsNullOrEmpty(phone_number) || phone_number.Trim().Length > 50)
            {
                ViewBag.PhoneNumberError = "Phone number must be between 1 and 50 characters!";
            }
            else
            {
                for (var i = 0; i < phone_number?.Length; i++) 
                { 
                    if (phone_number[i] < '0' || phone_number[i] > '9') 
                    { 
                        ViewBag.PhoneNumberError = "Phone number must only contain numeric!"; 
                    } 
                    else if (phone_number[i] >= '0' && phone_number[i] <= '9' && i == phone_number.Length - 1) 
                    { 
                        ViewBag.PhoneNumberError = null; 
                    } 
                }
            }

            if (string.IsNullOrEmpty(address) || address.Trim().Length > 500)
            {
                ViewBag.AddressError = "Address must be between 1 and 500 characters!";
            }
            else
            {
                ViewBag.AddressError = null;
            }

            if (ViewBag.NameError != null || ViewBag.EmailError != null || ViewBag.PasswordError != null || ViewBag.PhoneNumberError != null || ViewBag.AddressError != null)
            {
                return View();
            }


            var highestCustomerId = _context.MsCustomers
            .OrderByDescending(c => c.Customer_id)
            .Select(c => c.Customer_id)
            .FirstOrDefault();

            int highestNumericId = 0;
            if (!string.IsNullOrEmpty(highestCustomerId))
            {
                var match = Regex.Match(highestCustomerId, @"\d+");
                if (match.Success)
                {
                    highestNumericId = int.Parse(match.Value);
                }
            }

            int newNumericId = highestNumericId + 1;
            string newCustomerId = $"CUS{newNumericId}";

            var newCustomer = new MsCustomer()
            {
                Customer_id = newCustomerId,
                name = name,
                email = email,
                phone_number = phone_number,
                address = address,
                password = password,
                driver_license_number = null
            };

            
            await _context.MsCustomers.AddAsync(newCustomer);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Login");

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
