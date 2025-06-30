using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Geometries;
using WebApplication1.Models; // Replace with actual namespace

namespace WebApplication1.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

        public DbSet<Report> Reports { get; set; }
        public DbSet<Barangay> Barangays { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Barangay>()
                .Property(b => b.GeoBoundary)
                .HasColumnType("geography");

            base.OnModelCreating(modelBuilder);
        }
    }
}
