using Microsoft.AspNetCore.Mvc;
using CrochetJournal.Models;
using System.Linq;
using CrochetJournal.Data;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
namespace CrochetJournal.Controllers
{
    public class UserController : Controller
    {
        private readonly BlogDbContext _context;
        public UserController(BlogDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                user.CreatedOn = DateTime.Now;
                _context.Users.Add(user);
                _context.SaveChanges();
                return RedirectToAction("Login");

            }
            return View(user);
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == username);
            if (username != null && user.PasswordHash == password)
            {
                HttpContext.Session.SetInt32("UserId", user.UserId);
                return RedirectToAction("Index", "Blog");
            }
            ViewBag.ErrorMessage = "Incorrect username or password!";
            return View("Login");
        }
        //to showusers
        public IActionResult ShowUsers()
        {
            var users = _context.Users.ToList();
            return Json(users);
        }

    }
}