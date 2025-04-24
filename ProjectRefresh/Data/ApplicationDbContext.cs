using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProjectRefresh.Models;

namespace ProjectRefresh.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<MsCar> MsCars { get; set; }
        public DbSet<MsCarImages> MsCarImages { get; set; }
        public DbSet<MsCustomer> MsCustomers { get; set; }
        public DbSet<MsEmployee> MsEmployees { get; set; }
        public DbSet<TrMaintenance> TrMaintenances { get; set; }
        public DbSet<TrPayment> TrPayments { get; set; }
        public DbSet<TrRental> TrRentals { get; set; }
    }
}
