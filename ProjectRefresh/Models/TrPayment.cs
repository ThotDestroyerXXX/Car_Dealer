using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectRefresh.Models
{
    public class TrPayment
    {
        [Key]
        [Required]
        [StringLength(36)]
        public string Payment_id { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? payment_date { get; set; }

        [DisplayFormat(DataFormatString = "{0:F2}", ApplyFormatInEditMode = true)]
        public double? amount { get; set; }

        [StringLength(100)]
        public string? payment_method { get; set; }

        [ForeignKey("TrRental")]
        [StringLength(36)]
        public string? Rental_id { get; set; }
        public TrRental TrRental { get; set; }
    }
}
