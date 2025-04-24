using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectRefresh.Models
{
    [Table("MsCustomer")]
    public class MsCustomer
    {
        [Key]
        [Required]
        [StringLength(36)]
        public string Customer_id { get; set; }

        [Required]
        [StringLength (100)]
        public string email { get; set; }

        [Required]
        [StringLength(100)]
        public string password { get; set; }

        [Required]
        [StringLength(200)]
        public string name { get; set; }

        [StringLength(50)]
        public string? phone_number { get; set; }

        [StringLength(500)]
        public string? address { get; set; }

        [StringLength(100)]
        public string? driver_license_number { get; set; }

        public ICollection<TrRental> TrRentals { get; set; }
    }
}
