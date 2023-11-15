using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace ProiectColectiv.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<AutoPartShop> AutoPartShop { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<AutoPart> AutoParts { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Labour> Labours { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {


        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
           
        }
        /*protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer("Server=DESKTOP-77BLGL2;Database=ProiectColectiv;TrustServerCertificate=true;");*/
    }
}
