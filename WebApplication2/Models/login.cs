using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class login
    {
        [Key]
        public string Email { get; set; }
        public string Password { get; set; }

    }
}
