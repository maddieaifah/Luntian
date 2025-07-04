using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; // Needed for FirstOrDefaultAsync and ToListAsync
using System.Diagnostics;
using WebApplication1.Data;
using WebApplication1.Models;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly AppDbContext _context;

    public HomeController(ILogger<HomeController> logger, AppDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult RoleSelection()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Login(string role)
    {
        ViewBag.SelectedRole = role;
        return View();
    }

    public IActionResult Signup(string role)
    {
        ViewBag.SelectedRole = role;
        return View();
    }

    [HttpPost]
    public IActionResult UpdateProfile(ProfileViewModel model)
    {
        // Profile saving logic placeholder
        return RedirectToAction("Profile");
    }

    public IActionResult ForgotPassword() => View();

    [HttpGet]
    public async Task<IActionResult> CitizenHome()
    {
        var citizenId = HttpContext.Session.GetInt32("CitizenId");

        if (citizenId == null)
        {
            return RedirectToAction("Login", "Home");
        }

        var citizen = await _context.Citizens
            .Include(c => c.Barangay)
            .FirstOrDefaultAsync(c => c.CitizenId == citizenId);

        if (citizen == null || citizen.BarangayId == null)
        {
            TempData["Error"] = "No barangay assigned to your account.";
            return View(new List<VolunteerEvent>());
        }

        var events = await _context.VolunteerEvents
            .Where(e => e.BarangayId == citizen.BarangayId)
            .OrderByDescending(e => e.EventDateTime)
            .ToListAsync();

        return View(events); // Pass events to the view
    }


    public IActionResult ReportIssue()
    {
        return View();
    }

    public IActionResult Profile()
    {
        return View();
    }

    public IActionResult Notification()
    {
        return View();
    }

    public IActionResult Dashboard()
    {
        return View();
    }

    public IActionResult ViewReport()
    {
        return View();
    }

    public IActionResult SolveIssue()
    {
        return View();
    }

    public IActionResult InProgress()
    {
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> VolunteerBoard()
    {
        var events = await _context.VolunteerEvents
            .OrderByDescending(e => e.EventDateTime)
            .ToListAsync();

        return View(events);
    }


    [HttpGet]
    public async Task<IActionResult> AdminProfile()
    {
        var userId = HttpContext.Session.GetInt32("UserId");

        if (userId == null)
            return RedirectToAction("Login");

        var official = await _context.Officials
            .Include(o => o.Barangay)
            .FirstOrDefaultAsync(o => o.UserId == userId);

        if (official == null)
            return RedirectToAction("Login");

        var events = await _context.VolunteerEvents
            .Where(e => e.BarangayId == official.BarangayId)
            .OrderByDescending(e => e.EventDateTime)
            .ToListAsync();

        ViewBag.Official = official;
        return View(events); // AdminProfile.cshtml will receive List<VolunteerEvent>
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public class ProfileViewModel
    {
        public string? Name { get; set; }
        public string? Sex { get; set; }
        public int Age { get; set; }
        public string? Address { get; set; }
        public IFormFile? Photo { get; set; }
    }
}
