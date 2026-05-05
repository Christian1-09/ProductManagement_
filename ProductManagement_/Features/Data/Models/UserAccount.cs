using ProductManagement_.Features.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace ProductManagement_.Features.Data.Models
{
    public class UserAccount
    {
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string FirstName { get; set; } = string.Empty;

        [Required, MaxLength(150)]
        public string Username { get; set; } = string.Empty; // Email

        [Required]
        public string Password { get; set; } = string.Empty;

        public Roles Role { get; set; } = Roles.User;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
