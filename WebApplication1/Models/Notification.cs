using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models{
    public class Notification
{
    public int NotificationId { get; set; }

    [Required]
    public int CitizenId { get; set; }
    public Citizen Citizen { get; set; } = null!;

    public int? ReportId { get; set; }
    public Report? Report { get; set; }

    public int? EventId { get; set; }
    public VolunteerEvent? Event { get; set; }

    [Required]
    public string Type { get; set; } = string.Empty;

    [Required]
    public string Message { get; set; } = string.Empty;

    public DateTime Timestamp { get; set; } = DateTime.UtcNow;

    public bool IsRead { get; set; } = false;
}
}