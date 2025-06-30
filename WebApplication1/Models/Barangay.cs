using NetTopologySuite.Geometries;
using System.ComponentModel.DataAnnotations;
public class Barangay
{
    public int BarangayId { get; set; }

    [Required]
    public string Name { get; set; } = string.Empty;

    public string Address { get; set; } = string.Empty;
    [Required]
    public MultiPolygon? GeoBoundary { get; set; }  // Polygon boundary
    public ICollection<Report> Reports { get; set; } = new List<Report>();
}
