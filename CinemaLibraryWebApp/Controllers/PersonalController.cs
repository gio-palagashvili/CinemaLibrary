using System.Linq;
using CinemaLibraryWebApp.Data;
using CinemaLibraryWebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CinemaLibraryWebApp.Controllers
{
    public class PersonalController : Controller
    {
        private readonly ApplicationDbContext _db;
        public PersonalController(ApplicationDbContext db)
        {
            _db = db;
        }       
        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("userId") == null) return RedirectToAction("Index", "Auth");
            User user = _db.Users.FirstOrDefault(x => x.Id == HttpContext.Session.GetInt32("userId"));
            
            ViewBag.user = user;
            ViewBag.userRole = user.Role;
            ViewBag.comments = _db.Comments.Include(x=> x.Movie).Where(x => x.User.Id == user.Id).ToList();
            
            return View(ViewBag);
        }

        public IActionResult Account(int id)
        {
            if (HttpContext.Session.GetInt32("userId") == null) RedirectToAction("Index", "Auth");
            if (HttpContext.Session.GetInt32("userId") == id) return RedirectToAction("Index");
            
            User account = _db.Users.FirstOrDefault(x => x.Id == id);
            
            ViewBag.account = account;
            ViewBag.userRole = HttpContext.Session.GetString("userRole");
            ViewBag.comments = _db.Comments.Include(x=> x.Movie).Where(x => x.User.Id == account.Id);

            return View(ViewBag);
        }
    }
}