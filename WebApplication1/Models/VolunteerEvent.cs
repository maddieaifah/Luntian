using System.ComponentModel.DataAnnotations;
using NetTopologySuite.Geometries;

namespace WebApplication1.Models{
    public class VolunteerEvent
{

    [Key]
    public int EventId { get; set; }

    [Required]
    public int BarangayId { get; set; }
    public Barangay Barangay { get; set; } = null!;

    public int? OfficialId { get; set; }
    public Official? Organizer { get; set; }

    [Required]
    public string Title { get; set; } = string.Empty;

    [Required]
    public string LocationText { get; set; } = string.Empty;

    public Point? LocationGeom { get; set; }

    public DateTime EventDateTime { get; set; }

    [Required]
    public string Description { get; set; } = string.Empty;

    public string? ImagePath { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime LastUpdated { get; set; } = DateTime.UtcNow;

    public ICollection<Notification> Notifications { get; set; } = new List<Notification>();
}

}
