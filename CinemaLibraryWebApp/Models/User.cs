using System.ComponentModel.DataAnnotations;

namespace CinemaLibraryWebApp.Models
{
    public class User
    {
        [Key] public int Id { get; set; }
        [Required] public string Mail { get; set; }
        [Required] public string Password { get; set; }
        [Required] public string Role { get; set; }
    }
}