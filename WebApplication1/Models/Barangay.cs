using NetTopologySuite.Geometries;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models{
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

    public ICollection<Official> Officials { get; set; } = new List<Official>();
    public ICollection<Report> Reports { get; set; } = new List<Report>();
    public ICollection<VolunteerEvent> VolunteerEvents { get; set; } = new List<VolunteerEvent>();
}
}


