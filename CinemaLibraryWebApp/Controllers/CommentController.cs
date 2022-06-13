using System;
using System.Linq;
using CinemaLibraryWebApp.Data;
using CinemaLibraryWebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CinemaLibraryWebApp.Controllers
{
    public class CommentController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CommentController(ApplicationDbContext db)
        {
            _db = db;
        }
    
        [HttpPost]
        public IActionResult PostComment(string text, int movieId, string url)
        {
            Movie movie = _db.Movies.FirstOrDefault(x => x.Id == movieId);
            User user = _db.Users.FirstOrDefault(x => x.Id == HttpContext.Session.GetInt32("userId"));
            Comment comment = new Comment {CommentDate = DateTime.Now, Movie = movie, Text = text, User = user};
            
            _db.Comments.Add(comment);
            _db.SaveChanges();
            
            return Redirect(url);
        }
        
        public IActionResult Delete(int id,int movieId)
        {
            if (HttpContext.Session.GetString("userRole") != "admin") RedirectToAction("Index","Auth");
            Comment comment = _db.Comments.Include(e=>e.Movie).FirstOrDefault(x=> x.CommentId == id);
            if (comment == null) RedirectToAction("index", "Actor");
            
            _db.Comments.Remove(comment);
            _db.SaveChanges();
            
            return Redirect("https://localhost:5001/movie/details/"+comment.Movie.Id);
        }

        [HttpPost]
        public IActionResult Edit(int id,string text)
        {
            if (HttpContext.Session.GetString("userRole") != "admin") RedirectToAction("Index","Auth");
            Comment comment = _db.Comments.Include(e=>e.Movie).FirstOrDefault(x=> x.CommentId == id);
            if (comment == null) RedirectToAction("index", "Actor");
            comment.Text = text;
            
            _db.Comments.Update(comment);
            _db.SaveChanges();
            
            return Redirect("https://localhost:5001/movie/details/"+comment.Movie.Id);
        }
    }
}