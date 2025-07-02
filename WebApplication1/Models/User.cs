using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models{
    public class User
{
    public int UserId { get; set; }

    [Required, EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required]
    public string PasswordHash { get; set; } = string.Empty;

    [Required]
    public string Role { get; set; } = "Citizen"; // "Citizen", "Official"

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime? LastLogin { get; set; }

    public Citizen? CitizenProfile { get; set; }
    public Official? OfficialProfile { get; set; }
}
}

