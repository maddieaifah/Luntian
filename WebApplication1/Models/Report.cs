using System.ComponentModel.DataAnnotations;
using NetTopologySuite.Geometries;

public class Report
{
    public int Id { get; set; }

    [Required]
    public int CitizenId { get; set; }  // Reporter FK

    [Required]
    public string Category { get; set; } = string.Empty;

    [Required]
    public string Priority { get; set; } = string.Empty;

    [Required]
    public string Hazard { get; set; } = string.Empty;

    [Required]
    public string Description { get; set; } = string.Empty;

    public string Address { get; set; } = string.Empty;  // formerly "Location" (human-readable)

    public string ImagePath { get; set; } = string.Empty;

    public DateTime SubmittedAt { get; set; } = DateTime.UtcNow;

    public double Latitude { get; set; }

    public double Longitude { get; set; }

    // 🌐 Geometry-based location
    public Point? GeoPoint { get; set; }  // for NetTopologySuite

    // 💡 FK to Barangay via spatial query
    public int? BarangayId { get; set; }
    public Barangay? Barangay { get; set; }

    // ✅ AI/Machine Learning Tags
    public bool IsBlurry { get; set; }
    public bool IsNSFW { get; set; }

    public string AutoTags { get; set; } = string.Empty;  // e.g., "trash, sewage"

    [Required]
    public string Status { get; set; } = "Pending";  // "Pending", "In Progress", "Resolved"

    
}
