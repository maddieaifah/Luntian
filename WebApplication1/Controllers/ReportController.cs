using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data; // replace with your actual namespace
using WebApplication1.Models;

public class ReportController : Controller
{
    private readonly AppDbContext _context;

    public ReportController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> Submit(Report report)
    {
        if (ModelState.IsValid)
        {
            // Insert report to DB
            _context.Reports.Add(report);
            await _context.SaveChangesAsync();

            // Redirect or return a response
            return RedirectToAction("ThankYou");
        }

        // If invalid
        return View("ReportIssue", report); // or however you named the view
    }
}
