using System.ComponentModel.DataAnnotations;

namespace OnlineShoppingApp.WebApi.Models
{
    public class LoginRequest
    {
        // LoginRequest property definition
        [Required]
        [EmailAddress]

        public string Email { get; set; }

        public string Password { get; set; }
    }
}
