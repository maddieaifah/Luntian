public class VolunteerEvent
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public DateTime DateTime { get; set; } 
    public string Description { get; set; } = string.Empty;
    public string ImagePath { get; set; } = string.Empty; // Path to the event image
    public int OrganizerId { get; set; }          // Foreign key to Official or Admin
}
