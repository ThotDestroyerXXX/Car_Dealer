using System.ComponentModel.DataAnnotations;

namespace ProjectRefresh.Models
{
    public class MsEmployee
    {
        [Key]
        [Required]
        [StringLength(36)]
        public string Employee_id { get; set; }

        [Required]
        [StringLength(200)]
        public string name { get; set;}

        [StringLength (4000)]
        public string? position { get; set;}

        [StringLength(200)]
        public string? email { get; set;}

        [Required]
        [StringLength(36)]
        public string phone_number { get; set;}

        public ICollection<TrMaintenance> TrMaintenances { get; set;}
    }
}
