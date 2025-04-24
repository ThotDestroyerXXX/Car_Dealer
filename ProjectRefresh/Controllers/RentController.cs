using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectRefresh.Data;
using ProjectRefresh.Models;
using System.Diagnostics;
using System.Globalization;
using System.Security.Claims;
using System.Text.RegularExpressions;

namespace ProjectRefresh.Controllers
{
    [Authorize]
    public class RentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RentController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult Index(string carId, DateTime pickupDate, DateTime returnDate)
        {
            var emailClaim = User.FindFirst(ClaimTypes.Email)?.Value;
            var nameClaim = User.FindFirst(ClaimTypes.Name)?.Value;
            MsCar? cars = _context.MsCars.Include(a => a.MsCarImages).FirstOrDefault(a => a.Car_id.Equals(carId));
            if(cars == null)
            {
                return NotFound();
            }
            else
            {
                ViewBag.PickupDate = pickupDate.ToString("dd MMMM yyyy");
                ViewBag.ReturnDate = returnDate.ToString("dd MMMM yyyy"); 
                ViewBag.emailClaims = emailClaim;
                ViewBag.nameClaims = nameClaim;
                decimal totalPrice = (decimal)((decimal)(returnDate - pickupDate).TotalDays * cars.price_per_day);
                ViewBag.TotalPrice = totalPrice.ToString("C");
                ViewBag.TotalPriceRaw = totalPrice;
                return View(cars);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Sewa(string CarId, DateTime PickupDate, DateTime ReturnDate, decimal TotalPrice, int PaymentStatus) {
            var highestRentalId = _context.TrRentals
            .OrderByDescending(c => c.Rental_id)
            .Select(c => c.Rental_id)
            .FirstOrDefault();

            int highestNumericId = 0;
            if (!string.IsNullOrEmpty(highestRentalId))
            {
                var match = Regex.Match(highestRentalId, @"\d+");
                if (match.Success)
                {
                    highestNumericId = int.Parse(match.Value);
                }
            }

            int newNumericId = highestNumericId + 1;
            string newRentalId = $"RTD{newNumericId}";

            var customerIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (customerIdClaim != null)
            {
                bool paymentStatusBool = PaymentStatus == 1;

                var newRental = new TrRental()
                {
                    Rental_id = newRentalId,
                    rental_date = PickupDate,
                    return_date = ReturnDate,
                    total_price = TotalPrice,
                    payment_status = paymentStatusBool,
                    Customer_id = customerIdClaim,
                    Car_id = CarId,
                };
                await _context.TrRentals.AddAsync(newRental);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "History");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
