using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    public class RegisterDto
    {
        [Required]
        public required string Username { get; set; }

        [Required]
        [EmailAddress]
        public required string Email { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 6)]
        public required string Password { get; set; }
    }
}