using Microsoft.AspNetCore.Identity;

namespace ProiectColectiv.Data
{
    public class ApplicationUser : IdentityUser
    {
      
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? PhoneNumber { get; set; }
        public Credential? Credential { get; set; }
        public string? Email { get; set; }
        public List<Review>? Review { get; set; }
    }

    public class Credential : EntityBase
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
        public bool? IsAdmin { get; set; }
    }

    public class Review : EntityBase
    {
        public decimal? Grade { get; set; }
        public string? Description { get; set; }
    }
}

