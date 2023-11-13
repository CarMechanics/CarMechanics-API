using Microsoft.EntityFrameworkCore;

namespace ProiectColectiv.Data
{
    public class ApplicationDbContext : DbContext 
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<AutoPart> AutoParts { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Labour> Labours { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<Worker> Workers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer("Server=localhost,1433;Database=ProiectColectiv;User Id=sa;Password=ProgramatorLife1623!.;TrustServerCertificate=true;");
    }
}
