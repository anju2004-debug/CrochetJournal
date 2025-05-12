using Microsoft.AspNetCore.Mvc;
using CrochetJournal.Models;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using CrochetJournal.Data;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
namespace CrochetJournal.Controllers
{
    public class UserController : Controller
    {
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    public UserController(UserManager<User> userManager, SignInManager<User> signInManager ,BlogDbContext context)
    {
        _userManager = userManager;
        _signInManager = signInManager;
                    _context = context;

    }
        private readonly BlogDbContext _context;
        
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
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
             if(ModelState.IsValid)//if form credentials are correct
             {
                var user = new User//create a new user
                {
                    Username=model.Email,
                    Email=model.Email
                };
                var result = await _userManager.CreateAsync(user, model.Password);//user created in database

                if(result.Succeeded)//login the user automatically after registering
                {
                    await _signInManager.SignInAsync(user ,isPersistent:false);
                    return RedirectToAction("Index","Home");
                }
                //for error during the registration
                foreach(var Error in result.Errors)
                {
                    ModelState.AddModelError("",Error.Description);
                }

             }
             //redisplay the form
             return View(model);
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if(!ModelState.IsValid)//if form is not validated throw errors
            {
                return View(model);

            }
            //first we find user by name
            var user = await _userManager.FindByNameAsync(model.LoginIdentifier);
            if(user == null)
            {
                user = await _userManager.FindByEmailAsync(model.LoginIdentifier);//in case not found then check by email
            }
            if(user == null)
            {
                ModelState.AddModelError("","User not found,Invalid attempt");
            }
            //password check
            var result = await _signInManager.PasswordSignInAsync(user, model.Password,isPersistent:false,lockoutOnFailure:false);
            if(result.Succeeded)
             {
                 return RedirectToAction("Index","Home");
             }
             ModelState.AddModelError("","Wrong Password");
             return View(model);
            
        }
        //to showusers
        public IActionResult UserList()
        {
            var users = _context.Users.ToList();
            Console.WriteLine($"Found{users.Count}users");
            return View(users);
        }

    }
}