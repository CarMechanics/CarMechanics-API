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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(u => u.Credential)
                .WithOne()
                .HasForeignKey<Credential>(c => c.Id);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer("Data Source = BIA-PC\\SQLEXPRESS; Initial Catalog = ProiectColectiv; TrustServerCertificate=True;Integrated Security = True");
    }
}
