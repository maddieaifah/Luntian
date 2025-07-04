using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;

var builder = WebApplication.CreateBuilder(args);

// ---------- Services Configuration ----------
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        x => x.UseNetTopologySuite()
    ));
builder.Services.AddSession(); // Add session support
builder.Services.AddHttpContextAccessor(); // Optional but helpful

// ---------- Build App ----------
var app = builder.Build();

// ---------- Middleware Pipeline ----------
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles(); // Needed for serving CSS/JS/images

app.UseRouting();

app.UseSession();        // ✅ SESSION comes after routing
app.UseAuthorization();  // ✅ Authorization after session

// ---------- Routing ----------
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=RoleSelection}/{id?}");

app.Run();
