using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaLibraryWebApp.Models
{
    public class Director
    {
        [Key] public int Id { get; set; }
        [Required] public string Name { get; set; }
        [Required] public string LastName { get; set; }
        [Required] public DateTime BirthDate { get; set; }
        [Required] public float Rating { get; set; }
        public string Portrait { get; set; }
    }
}