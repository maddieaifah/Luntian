using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NetTopologySuite.Geometries;

namespace WebApplication1.Models
{
    public class Barangay
    {
        public int BarangayId { get; set; }

        [Required]
        public string BarangayName { get; set; } = string.Empty;

        public string? SubLocality { get; set; }
        public string? FullAddress { get; set; }
        public string? ContactNumber { get; set; }
        public string? Email { get; set; }

        public Polygon? Geom { get; set; }

        // Foreign key to BarangayMaster.ADM4_PCODE
        [Required]
        [MaxLength(20)]
        public string? BarangayMasterPCode { get; set; } // Make it nullable

        [ForeignKey("BarangayMasterPCode")]
        public BarangayMaster? BarangayMaster { get; set; }


        public ICollection<Official> Officials { get; set; } = new List<Official>();
        public ICollection<Report> Reports { get; set; } = new List<Report>();
        public ICollection<VolunteerEvent> VolunteerEvents { get; set; } = new List<VolunteerEvent>();
    }
}