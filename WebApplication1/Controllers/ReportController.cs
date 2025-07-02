using Microsoft.AspNetCore.Mvc;
using NetTopologySuite.Geometries;
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
        if (Request.Form.TryGetValue("Latitude", out var lat) &&
            Request.Form.TryGetValue("Longitude", out var lon) &&
            double.TryParse(lat, out double latitude) &&
            double.TryParse(lon, out double longitude))
        {
            report.LocationGeom = new Point(longitude, latitude) { SRID = 4326 }; // long first!
        }

        if (ModelState.IsValid)
        {
            _context.Reports.Add(report);
            await _context.SaveChangesAsync();
            return RedirectToAction("ThankYou");
        }

        return View("~/Views/Home/ReportIssue.cshtml", report);// or however you named the view
    }
}
