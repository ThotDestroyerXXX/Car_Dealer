using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectRefresh.Data;
using ProjectRefresh.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;

namespace ProjectRefresh.Controllers
{
    public class LoginController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LoginController(ApplicationDbContext context)
        {
            _context = context;
        }



        public IActionResult Index()
        {
            ClaimsPrincipal claimUser = HttpContext.User;

            if (claimUser.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(MsCustomer customerModel)
        {
            MsCustomer? customer = _context.MsCustomers.FirstOrDefault(a => a.email == customerModel.email && a.password == customerModel.password);
            if(customer != null)
            {
                List<Claim> claims = new()
                {
                    new Claim(ClaimTypes.Email, customer.email),
                    new Claim(ClaimTypes.Name, customer.name),
                    new Claim(ClaimTypes.NameIdentifier, customer.Customer_id.ToString())
                };
                ClaimsIdentity claimsIdentity = new(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                AuthenticationProperties properties = new()
                {
                    AllowRefresh = true,
                    IsPersistent = true
                };
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), properties);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewData["ValidateMessage"] = "user not found";
                return View(customerModel);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
