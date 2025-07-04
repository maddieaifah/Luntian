using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Geometries;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ReportController : Controller
    {
        private readonly AppDbContext _context;

        public ReportController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
    [HttpPost]
public async Task<IActionResult> Submit(Report model, double Latitude, double Longitude)
{
    var citizenId = HttpContext.Session.GetInt32("CitizenId");
    Console.WriteLine("📌 Session CitizenId: " + citizenId);

    if (citizenId == null)
    {
        Console.WriteLine("⚠️ No citizen logged in. Redirecting to login...");
        return RedirectToAction("Login", "Home");
    }

    // Create WKT Point
    var wkt = $"POINT ({Longitude} {Latitude})";
    Console.WriteLine($"🌍 Received coordinates: ({Latitude}, {Longitude})");
    Console.WriteLine($"🔍 Using WKT for spatial query: {wkt}");

    // Raw SQL to get BarangayId via join
    var barangay = await _context.Barangays
        .FromSqlRaw(@"
            SELECT TOP 1 b.*
            FROM BarangayMasters bm
            JOIN Barangays b ON b.BarangayMasterPCode = bm.ADM4_PCODE
            WHERE bm.Geom.STContains(geometry::STGeomFromText({0}, 4326)) = 1
        ", wkt)
        .FirstOrDefaultAsync();

    if (barangay == null)
    {
        Console.WriteLine("❌ No barangay found for given location.");
        ModelState.AddModelError("", "No barangay found for your location.");
        return View("~/Views/Home/ReportIssue.cshtml", model);
    }

    // Assign report data
    model.CitizenId = citizenId.Value;
    model.LocationGeom = new NetTopologySuite.Geometries.Point(Longitude, Latitude) { SRID = 4326 };
    model.BarangayId = barangay.BarangayId;
    model.SubmittedDate = DateTime.UtcNow;
    model.LastUpdated = DateTime.UtcNow;

    _context.Reports.Add(model);
    await _context.SaveChangesAsync();

    Console.WriteLine("✅ Report successfully saved.");
    return RedirectToAction("CitizenHome", "Home");
}


    }
}
