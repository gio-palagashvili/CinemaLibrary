using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaLibraryWebApp.Models
{
    public class Actor
    {
        [Key] public int Id { get; set; }
        [Required] public string Name { get; set; }
        [Required] public string LastName { get; set; }
        [Required] public DateTime BirthDate { get; set; }
        [Required] public float Rating { get; set; }
        [Required] public string Portrait { get; set; }
        public List<Movie> Movies { get; set; }

    }
}