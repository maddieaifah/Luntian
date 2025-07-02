using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models{
    public class ReportHistory
{
    [Key]
    public int HistoryId { get; set; }

    [Required]
    public int ReportId { get; set; }
    public Report Report { get; set; } = null!;

    public int? OfficialId { get; set; }
    public Official? Official { get; set; }

    public DateTime Timestamp { get; set; } = DateTime.UtcNow;

    public string? OldStatus { get; set; }

    [Required]
    public string NewStatus { get; set; } = string.Empty;

    public string? ActionTaken { get; set; }

    public string? SolutionImageUrl { get; set; }
}
}

