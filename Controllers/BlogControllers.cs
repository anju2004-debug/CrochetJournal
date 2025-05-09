using CrochetJournal.Models;
using Microsoft.AspNetCore.Mvc;
using CrochetJournal.Data;
using System.ComponentModel.DataAnnotations;
namespace CrochetJournal.Controllers
{
    public class BlogController : Controller
    {
        private readonly BlogDbContext _context;
        public BlogController(BlogDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var posts = new List<BlogPost>
            {
                new BlogPost{Id=1,Title="Crochet tulip bag", Content="This is a content about crochet tulip bag", PostedOn=DateTime.Now},
                new BlogPost{Id=2,Title="summer cotton vest",Content="This isa paragraph on summer cotto vest", PostedOn=DateTime.Now.AddDays(-1)},
                new BlogPost{Id=3,Title="Crochet flower bouquet", Content="this is a paragraph on how i made a crochet flower bouquet", PostedOn=DateTime.Now.AddDays(-3)}
            };
            return View(posts);
        }
        public IActionResult Details(int id)
        {
            var post = new BlogPost
            {
                Id = id,
                Title = $"Post#{id}",
                Content = $"Content#{id}post",
                PostedOn = DateTime.Now
            };
            return View(post);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(BlogPost blogPost)
        {
            if (ModelState.IsValid)
            {
                _context.BlogPosts.Add(blogPost);
                _context.SaveChanges();
                return RedirectToAction("Index", "Blog");
            }
            return View(blogPost);
        }

    }
}