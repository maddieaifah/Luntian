using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NetTopologySuite.Geometries;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public class BarangayMaster
    {
        [Key]
        [MaxLength(20)]
        public string ADM4_PCODE { get; set; } = string.Empty;  // Used as PK

        public string ADM4_EN { get; set; } = string.Empty;
        public string? ADM4_REF { get; set; }
        public string ADM3_EN { get; set; } = string.Empty;
        public string ADM3_PCODE { get; set; } = string.Empty;
        public string ADM2_EN { get; set; } = string.Empty;
        public string ADM2_PCODE { get; set; } = string.Empty;
        public string ADM1_EN { get; set; } = string.Empty;
        public string ADM1_PCODE { get; set; } = string.Empty;
        public string ADM0_EN { get; set; } = string.Empty;
        public string ADM0_PCODE { get; set; } = string.Empty;

        public DateTime? Date { get; set; }
        public DateTime? ValidOn { get; set; }
        public DateTime? ValidTo { get; set; }

        public double Shape_Leng { get; set; }
        public double Shape_Area { get; set; }
        public double Area_SQKM { get; set; }

        public string? WKT { get; set; }  // Optional temporary column

        public Geometry? geom { get; set; }

        // One-to-many relationship
        public ICollection<Barangay> Barangays { get; set; } = new List<Barangay>();
    }
}
