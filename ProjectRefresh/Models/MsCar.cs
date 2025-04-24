using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectRefresh.Models
{
    [Table("MsCar")]
    public class MsCar
    {
        [Key]
        [Required]
        [StringLength(36)]
        public string Car_id { get; set; }

        [StringLength(200)]
        public string? name { get; set;}

        [StringLength(100)]
        public string? model { get; set;}

        public int? year { get; set;}

        [StringLength(50)]
        public string? license_plate { get; set;}

        public int? number_of_car_seats { get; set;}

        [StringLength(100)]
        public string? transmission { get;set;}

        [DisplayFormat(DataFormatString ="{0:C2}", ApplyFormatInEditMode =false)]
        public decimal? price_per_day { get; set;}

        public bool? status { get; set;}

        public ICollection<MsCarImages> MsCarImages { get; set;}
        public ICollection<TrMaintenance> TrMaintenances { get; set;}
        public ICollection<TrRental> TrRentals { get; set;}

    }
}
