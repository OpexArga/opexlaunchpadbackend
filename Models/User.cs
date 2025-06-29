using System.ComponentModel.DataAnnotations;

namespace OpexShowcase.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required, EmailAddress]
        public required string Email { get; set; }

        [Required]
        public required string PasswordHash { get; set; }

        public ICollection<UserProduct> UserProducts { get; set; } = new List<UserProduct>();
    }
}
