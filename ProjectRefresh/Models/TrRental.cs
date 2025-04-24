using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectRefresh.Models
{
    [Table("TrRental")]
    public class TrRental
    {
        [Key]
        [Required]
        [StringLength(36)]
        public string Rental_id { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required]
        public DateTime rental_date { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? return_date { get; set; }

        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal? total_price { get; set; }

        public bool? payment_status { get; set; }

        [ForeignKey("MsCustomer")]
        [StringLength(36)]
        public string? Customer_id { get; set; }
        public MsCustomer MsCustomer { get; set; }

        [ForeignKey("MsCar")]
        [StringLength(36)]
        public string? Car_id { get; set; }
        public MsCar MsCar { get; set; }

        public ICollection<TrPayment> TrPayments { get; set; }
    }
}
