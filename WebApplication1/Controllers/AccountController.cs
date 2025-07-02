using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;

public class AccountController : Controller
{
    private readonly AppDbContext _context;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public AccountController(AppDbContext context, IHttpContextAccessor httpContextAccessor)
    {
        _context = context;
        _httpContextAccessor = httpContextAccessor;
    }

    [HttpPost]
    public IActionResult Login(string email, string password, string role)
    {
        var user = _context.Users.FirstOrDefault(u =>
            u.Email == email &&
            u.PasswordHash == password &&  // In real apps, use a hasher
            u.Role == role);

        if (user != null)
        {
            // Store user ID and role in session
            HttpContext.Session.SetInt32("UserId", user.UserId);
            HttpContext.Session.SetString("Role", user.Role);

            return role switch
            {
                "Citizen" => RedirectToAction("CitizenHome", "Home"),
                "Official" => RedirectToAction("Dashboard", "Home"),
                _ => RedirectToAction("RoleSelection", "Home")
            };
        }

        TempData["Error"] = "Invalid login credentials.";
        return View(); // Rerender the view with error
    }

    [HttpGet]
    public IActionResult Login() => View();
}
