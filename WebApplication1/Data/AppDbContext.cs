using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Citizen> Citizens { get; set; }
        public DbSet<Official> Officials { get; set; }
        public DbSet<Barangay> Barangays { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<ReportHistory> ReportHistories { get; set; }
        public DbSet<VolunteerEvent> VolunteerEvents { get; set; }
        public DbSet<Notification> Notifications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Relationships
            modelBuilder.Entity<User>()
                .HasOne(u => u.CitizenProfile)
                .WithOne(c => c.User)
                .HasForeignKey<Citizen>(c => c.UserId);

            modelBuilder.Entity<User>()
                .HasOne(u => u.OfficialProfile)
                .WithOne(o => o.User)
                .HasForeignKey<Official>(o => o.UserId);

            // Spatial columns config
            modelBuilder.Entity<Barangay>()
                .Property(b => b.Geom)
                .HasColumnType("geometry");

            modelBuilder.Entity<Report>()
                .Property(r => r.LocationGeom)
                .HasColumnType("geometry");

            modelBuilder.Entity<VolunteerEvent>()
                .Property(v => v.LocationGeom)
                .HasColumnType("geometry");

            modelBuilder.Entity<ReportHistory>()
                .HasKey(rh => rh.HistoryId);

            // ✅ Seed Data
            modelBuilder.Entity<Barangay>().HasData(new Barangay
            {
                BarangayId = 1,
                BarangayName = "Barangay 630",
                SubLocality = "Sta. Mesa",
                FullAddress = "Sta. Mesa, Manila",
                ContactNumber = "09123456789",
                Email = "barangay630@manila.gov.ph",
                Geom = null
            });

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    UserId = 1,
                    Email = "citizen@example.com",
                    PasswordHash = "citizen123",
                    Role = "Citizen",
                    CreatedAt = new DateTime(2024, 1, 1)
                },
                new User
                {
                    UserId = 2,
                    Email = "official@example.com",
                    PasswordHash = "official123",
                    Role = "Official",
                    CreatedAt = new DateTime(2024, 1, 1)
                }
            );

            modelBuilder.Entity<Citizen>().HasData(new Citizen
            {
                CitizenId = 1,
                UserId = 1,
                FirstName = "Juan",
                LastName = "Dela Cruz",
                Sex = "Male",
                Age = 25,
                Address = "Sample Street, Manila"
            });

            modelBuilder.Entity<Official>().HasData(new Official
            {
                OfficialId = 1,
                UserId = 2,
                FirstName = "Maria",
                LastName = "Santos",
                BarangayId = 1,
                Position = "Barangay Captain",
                ContactNumber = "09999999999"
            });

            base.OnModelCreating(modelBuilder); // 👈 Put this last
        }
    }
}
