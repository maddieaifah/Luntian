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
    [HttpPost]
public IActionResult Login(string email, string password, string role)
{
    var user = _context.Users.FirstOrDefault(u =>
        u.Email == email &&
        u.PasswordHash == password &&  // 🔐 Replace with hash check in real app
        u.Role == role);

    if (user != null)
    {
        // Save UserId and Role in session
        HttpContext.Session.SetInt32("UserId", user.UserId);
        HttpContext.Session.SetString("Role", user.Role);

        if (role == "Citizen")
        {
            var citizen = _context.Citizens.FirstOrDefault(c => c.UserId == user.UserId);
            if (citizen != null)
            {
                HttpContext.Session.SetInt32("CitizenId", citizen.CitizenId);
            }
        }

        return role switch
        {
            "Citizen" => RedirectToAction("CitizenHome", "Home"),
            "Official" => RedirectToAction("Dashboard", "Home"),
            _ => RedirectToAction("RoleSelection", "Home")
        };
    }

    TempData["Error"] = "Invalid login credentials.";
    return View("~/Views/Home/Login.cshtml");
}


    [HttpGet]
    public IActionResult Login() => View();
}
