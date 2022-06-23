using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using CinemaLibraryWebApp.Data;
using CinemaLibraryWebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CinemaLibraryWebApp.Controllers
{
    public class AuthController : Controller
    {
        private readonly ApplicationDbContext _db;
        public AuthController(ApplicationDbContext db)
        {
            _db = db;
        }

        private static string ComputeMd5Hash(string message)
        {
            using MD5 md5 = MD5.Create();
            byte[] input = Encoding.ASCII.GetBytes(message);
            byte[] hash = md5.ComputeHash(input);
	
            var sb = new StringBuilder();
            foreach (var t in hash)
            {
                sb.Append(t.ToString("X2"));
            }
            return sb.ToString();
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("userId") != null) return RedirectToAction("Index", "Home");
            ViewBag.url = Request.Headers["Referer"];
            
            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            if (HttpContext.Session.GetInt32("userId") != null) return RedirectToAction("Index", "Home");
            return View();
        }
        
        [HttpPost]
        public IActionResult Register(string mail, string password)
        {
                password = ComputeMd5Hash(password);
            
                if (_db.Users.FirstOrDefault(x => x.Mail == mail) != null)
                {
                    return RedirectToAction("Register","Auth");
                }
                
                User user = new User { Mail = mail, Password = password, Role = "user" };
                _db.Users.Add(user);
                _db.SaveChanges();

                return RedirectToAction("Index");
        }
        
        [HttpPost]
        public IActionResult Login(string mail, string password,string url)
        {
            password = ComputeMd5Hash(password);

            var user = _db.Users.FirstOrDefault(x => x.Password == password && x.Mail == mail);
            if (user != null)
            {
                HttpContext.Session.SetInt32("userId",user.Id);
                HttpContext.Session.SetString("userRole", user.Role);
                if (url == null) return RedirectToAction("index", "Home");
                return Redirect(url);
            }

            return RedirectToAction("index", "Auth");
        }

        public IActionResult LogOut()
        {
            if (HttpContext.Session.GetInt32("userId") != null) HttpContext.Session.Remove("userId");
            if (HttpContext.Session.GetInt32("userRole") != null) HttpContext.Session.Remove("userRole");
            
            return RedirectToAction("index", "Auth");
        }
    }
}