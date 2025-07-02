using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models{
    public class Official
{
    public int OfficialId { get; set; }

    [Required]
    public int UserId { get; set; }
    public User User { get; set; } = null!;

    [Required]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    public string LastName { get; set; } = string.Empty;

    [Required]
    public int BarangayId { get; set; }
    public Barangay Barangay { get; set; } = null!;

    public string? Position { get; set; }

    public string? ContactNumber { get; set; }

    public ICollection<ReportHistory> ReportHistories { get; set; } = new List<ReportHistory>();
}
}

