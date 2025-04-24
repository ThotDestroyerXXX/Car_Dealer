using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectRefresh.Models
{
    public class TrMaintenance
    {
        [Key]
        [Required]
        [StringLength(36)]
        public int Maintenance_id { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? maintenance_date { get; set; }

        [StringLength(4000)]
        public string? description { get; set; }

        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal? cost { get; set; }

        [ForeignKey("MsCar")]
        [StringLength(36)]
        public string? Car_id { get; set; }
        public MsCar MsCar { get; set; }

        [ForeignKey("MsEmployee")]
        [StringLength(36)]
        public string? Employee_id { get; set; }
        public MsEmployee MsEmployee { get; set; }
    }
}
