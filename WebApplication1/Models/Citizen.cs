using WebApplication1.Models;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models{
    public class Citizen
{
    public int CitizenId { get; set; }

    //Foreign key to User table
    [Required]
    public int UserId { get; set; }
    public User User { get; set; } = null!;

    [Required]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    public string LastName { get; set; } = string.Empty;

    public string? Sex { get; set; } // "Male", "Female", etc.

    public int? Age { get; set; }

    public string? Address { get; set; }

    public string? ProfilePictureUrl { get; set; }

    //Foreign key to barangay table
    // ✅ New Foreign Key to Barangay
    public int? BarangayId { get; set; }  // Nullable to avoid breaking old data
    public Barangay? Barangay { get; set; }

    public ICollection<Report> Reports { get; set; } = new List<Report>();
    public ICollection<Notification> Notifications { get; set; } = new List<Notification>();
}
}

