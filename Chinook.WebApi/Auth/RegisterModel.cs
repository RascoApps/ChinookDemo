using System.ComponentModel.DataAnnotations;

namespace Chinook.WebApi.Auth
{
    public class RegisterModel
    {
        public string? Username { get; set; }

        [EmailAddress]
        public string? Email { get; set; }
        
        public string? Password { get; set; }
    }
}
