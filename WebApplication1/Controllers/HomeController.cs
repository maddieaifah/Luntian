using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Models; // Add this if ErrorViewModel is in the Models folder

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
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

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public IActionResult ForgotPassword() => View();

    public IActionResult CitizenHome()
    {
        return View();
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

    [HttpPost]
    public IActionResult UpdateProfile(ProfileViewModel model)
    {
        // For now, just return to the profile view for testing
        return RedirectToAction("Profile");
    }

    public class ProfileViewModel
    {
        public string? Name { get; set; }
        public string? Sex { get; set; }
        public int Age { get; set; }
        public string? Address { get; set; }
        public IFormFile? Photo { get; set; }
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

    public IActionResult VolunteerBoard()
    {
        return View();
    }

        public IActionResult AdminProfile()
    {
        return View();
    }

}
