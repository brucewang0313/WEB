using System.ComponentModel.DataAnnotations;

namespace JwtExercise.API.DTOs
{
    public class LoginRequest
    {
        [Required]
        public string Username { get; init; } = string.Empty;

        [Required]
        public string Password { get; init; } = string.Empty;
    }
}
