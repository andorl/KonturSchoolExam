using System.ComponentModel.DataAnnotations;

namespace WorkManager.Models
{
    public class RegisterData
    {
        [Required] public string Name { get; set; }
        [Required] public string Email { get; set; }

        [Required] public string Password { get; set; }
    }

    public class LoginData
    {
        [Required] public string Name { get; set; }
        [Required] public string Password { get; set; }
    }
}