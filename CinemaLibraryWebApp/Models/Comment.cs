using System;
using System.ComponentModel.DataAnnotations;

namespace CinemaLibraryWebApp.Models
{
    public class Comment
    {
        [Key] public int CommentId { get; set; }
        [Required] public string Text { get; set; }
        [Required] public DateTime CommentDate { get; set; }
        [Required] public User User { get; set; }
        [Required] public Movie Movie { get; set; }
    }
}