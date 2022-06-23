using System;
using System.Collections.Generic;
using System.Linq;
using CinemaLibraryWebApp.Data;
using CinemaLibraryWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CinemaLibraryWebApp.Controllers
{
    public class SearchController : Controller
    {
        private readonly ApplicationDbContext _db;
        public SearchController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult SearchMovie(string text)
        {
            IEnumerable<Movie> movies = _db.Movies.Where(movie => movie.Name.Contains(text));
            IEnumerable<Director> directors = _db.Directors.Where(director => director.Name.Contains(text));
            IEnumerable<Actor> actors = _db.Actors.Where(director => director.Name.Contains(text));
            IQueryable<User> users = _db.Users.Where(x => x.Mail.Contains(text));
            
            SearchList list = new SearchList {Movies = movies.ToList(), Directors = directors.ToList(),Actors = actors.ToList(),Users = users.ToList()};
            
            return View(list);
        }
    }
}
