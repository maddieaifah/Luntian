using System.ComponentModel.DataAnnotations;
using NetTopologySuite.Geometries;

namespace WebApplication1.Models{
    public class Report
{
    // For the unique report ID
    public int ReportId { get; set; }

    // For citizen referencing the reporter
    [Required]
    public int CitizenId { get; set; }
    public Citizen Citizen { get; set; } = null!;

    public int? BarangayId { get; set; }
    public Barangay? Barangay { get; set; }

    [Required]
    public string Category { get; set; } = string.Empty;

    [Required]
    public string PriorityLevel { get; set; } = string.Empty;

    [Required]
    public string HazardLevel { get; set; } = string.Empty;

    [Required]
    public string Description { get; set; } = string.Empty;

    public string? LocationText { get; set; }

    [Required]
    public Point LocationGeom { get; set; } = null!;

    public DateTime SubmittedDate { get; set; } = DateTime.UtcNow;

    [Required]
    public string Status { get; set; } = "Pending";

    public string? ImageUrl { get; set; }

    public DateTime LastUpdated { get; set; } = DateTime.UtcNow;

    public ICollection<ReportHistory> ReportHistories { get; set; } = new List<ReportHistory>();
    public ICollection<Notification> Notifications { get; set; } = new List<Notification>();
}
}

