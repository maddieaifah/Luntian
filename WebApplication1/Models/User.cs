public class User
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;         // from signup.cshtml
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Sex { get; set; } = string.Empty;               // from Profile.cshtml
    public int Age { get; set; }
    public string Address { get; set; } = string.Empty;
    public string PhotoPath { get; set; } = string.Empty;
}
