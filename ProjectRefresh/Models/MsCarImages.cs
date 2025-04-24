using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectRefresh.Models
{
    public class MsCarImages
    {
        [Key]
        [StringLength(36)]
        [Required]
        public string Image_car_id { get; set; }

        [ForeignKey("MsCar")]
        [StringLength(36)]
        public string? Car_id { get; set; }
        public MsCar MsCar { get; set; }

        [StringLength(2000)]
        public string? image_link { get; set; }

    }
}
