using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaLibraryWebApp.Models
{
    public class Genre
    {
        [Key]public int Id { get; set; }
        [Required] public string Name { get; set; }
    }
}