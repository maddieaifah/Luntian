using WebApplication1.Models;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models{
    public class Citizen
{
    public int CitizenId { get; set; }

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

    public ICollection<Report> Reports { get; set; } = new List<Report>();
    public ICollection<Notification> Notifications { get; set; } = new List<Notification>();
}
}

