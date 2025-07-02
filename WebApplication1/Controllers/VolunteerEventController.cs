using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;
using Microsoft.EntityFrameworkCore;


public class VolunteerEventController : Controller
{
    private readonly AppDbContext _context;

    public VolunteerEventController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> Add(VolunteerEvent evt, IFormFile? imageFile)
    {
        var userId = HttpContext.Session.GetInt32("UserId");
        if (userId == null) return RedirectToAction("Login", "Home");

        var official = await _context.Officials.FirstOrDefaultAsync(o => o.UserId == userId);
        if (official == null) return Unauthorized();

        if (imageFile != null)
        {
            var fileName = Guid.NewGuid() + Path.GetExtension(imageFile.FileName);
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/events", fileName);
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await imageFile.CopyToAsync(stream);
            }
            evt.ImagePath = "/images/events/" + fileName;
        }

        // Set official and barangay info
        evt.OfficialId = official.OfficialId;
        evt.BarangayId = official.BarangayId;
        evt.CreatedAt = DateTime.UtcNow;
        evt.LastUpdated = DateTime.UtcNow;

        _context.VolunteerEvents.Add(evt);
        await _context.SaveChangesAsync();

        return RedirectToAction("AdminProfile", "Home");
    }
    [HttpPost]
    [HttpPost]
    public async Task<IActionResult> Edit(VolunteerEvent updatedEvent)
    {
        var existing = await _context.VolunteerEvents.FindAsync(updatedEvent.EventId);
        if (existing == null) return NotFound();

        existing.Title = updatedEvent.Title;
        existing.Description = updatedEvent.Description;
        existing.LocationText = updatedEvent.LocationText;
        existing.EventDateTime = updatedEvent.EventDateTime;
        existing.LastUpdated = DateTime.UtcNow;

        await _context.SaveChangesAsync();
        return RedirectToAction("AdminProfile", "Home");
    }

    [HttpPost]
    [Route("VolunteerEvent/Delete/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var evt = await _context.VolunteerEvents.FindAsync(id);
        if (evt == null) return NotFound();

        _context.VolunteerEvents.Remove(evt);
        await _context.SaveChangesAsync();

        return RedirectToAction("AdminProfile", "Home");
    }
}
