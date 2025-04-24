using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectRefresh.Data;
using ProjectRefresh.Models;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authorization;

namespace ProjectRefresh.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index(int? selectedYear, DateTime? pickupDate, DateTime? returnDate, int? selectedSort)
        {
            List<MsCar> cars = _context.MsCars.Include(a => a.MsCarImages).ToList();

            List<int?> years = cars.Select(c => c.year).Distinct().OrderBy(y => y).ToList();

            if (!pickupDate.HasValue || !returnDate.HasValue)
            {
                cars.Clear();
            }
            else if (pickupDate.HasValue && returnDate.HasValue && !selectedYear.HasValue)
            {
                cars = _context.MsCars.Include(a => a.MsCarImages).ToList();
            }
            else if (pickupDate.HasValue && returnDate.HasValue && selectedYear.HasValue)
            {
                cars = cars.Where(c => c.year == selectedYear.Value).ToList();
            }
            else
            {
                cars.Clear();
            }

            if (selectedSort.HasValue)
            {
                if (selectedSort.Value == 1)
                {
                    cars = cars.OrderByDescending(c => c.price_per_day).ToList();
                }
                else if (selectedSort.Value == 2)
                {
                    cars = cars.OrderBy(c => c.price_per_day).ToList();
                }
            }

            List<SelectListItem> sortOptions = new()
        {
            new SelectListItem { Text = "Tinggi ke rendah", Value = "1" },
            new SelectListItem { Text = "Rendah ke tinggi", Value = "2" }
        };

            ViewBag.Years = new SelectList(years);
            ViewBag.PickupDate = pickupDate?.ToString("yyyy-MM-dd") ?? null;
            ViewBag.ReturnDate = returnDate?.ToString("yyyy-MM-dd") ?? null;
            ViewBag.SortOption = sortOptions; 
            ViewBag.SelectedYear = selectedYear;
            ViewBag.SelectedSort = selectedSort;

            return View(cars);
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Login");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}