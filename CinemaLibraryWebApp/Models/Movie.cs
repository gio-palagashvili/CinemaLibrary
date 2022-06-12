using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CinemaLibraryWebApp.Models
{
    public class Movie
    {
        [Key] public int Id { get; set; }
        [Required] public string Name { get; set; }
        [Required] public DateTime ReleaseDate { get; set; }
        [Required] public Genre Genre { get; set; }
        [Required] public Director Director { get; set; }
        public List<Actor> Actors { get; set; }
        [Required] public float IMDB { get; set; }
        [Required] public float RottenTomatoes { get; set; }
        [Required] public string Poster { get; set; }
        [Required] public string Description { get; set; }
    }
}