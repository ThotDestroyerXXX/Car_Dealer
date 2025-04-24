using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using ProjectRefresh.Data;
using ProjectRefresh.Models;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace ProjectRefresh.Controllers
{
    [Authorize]
    public class HistoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HistoryController(ApplicationDbContext context)
        {
            _context = context;
        }



        public IActionResult Index()
        {
            var emailClaim = User.FindFirst(ClaimTypes.Email)?.Value;

            // Check if the email claim is not null
            if (emailClaim != null)
            {
                // Retrieve the rentals for the customer with the specified email
                List<TrRental> rentals = _context.TrRentals
                    .Include(c => c.MsCustomer)
                    .Include(b => b.MsCar)
                    .Where(d => d.MsCustomer.email == emailClaim)
                    .ToList();

                return View(rentals);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
