using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WMN.Models;
using WMNDataAccess.Models;
using WMNDataAccess.DataAccess;
using Microsoft.AspNetCore.Identity;
using WMN.Attributes;

namespace WMN.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDBContext _db;

        public HomeController(ILogger<HomeController> logger, AppDBContext db)
        {
            _logger = logger;
            _db = db;
        }

        [HttpGet]
        [Route("sign-in")]
        public IActionResult Index()
        {
            Login user = new Login();
            return View(user);
        }

        [HttpPost]
        [Route("sign-in")]
        [ValidateAntiForgeryToken]
        public IActionResult Index(Login user)
        {
            if (user.EmailID != null && user.Password != null)
            {
                User validateUser = new User();

                if (_db.Users.FirstOrDefault(x => x.EmailID == user.EmailID) != null)
                {
                    var newUser = _db.Users.First(x => x.EmailID == user.EmailID);
                    var passwordHasher = new PasswordHasher<Login>();
                    if (passwordHasher.VerifyHashedPassword(user, newUser.Password, user.Password) == PasswordVerificationResult.Success)
                    {
                        HttpContext.Session.SetInt32("UserID", newUser.UserID);
                        HttpContext.Session.SetString("UserName", newUser.UserName);
                        return RedirectToAction("Dashboard", "Dashboard");
                    }
                    else ModelState.AddModelError("Password", "Password is wrong!");
                }
                else ModelState.AddModelError("EmailID", "Email Address is wrong!");
            }

            return View(user);
        }

        [HttpGet]
        [Route("register-user")]
        public IActionResult CreateUser()
        {
            User user = new User();
            return View(user);
        }

        [HttpPost]
        [Route("register-user")]
        [ValidateAntiForgeryToken]
        public IActionResult CreateUser(User user)
        {
            if (ModelState.IsValid)
            {
                var passwordHasher = new PasswordHasher<User>();
                user.Password = passwordHasher.HashPassword(user, user.Password);
                _db.Users.Add(user);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}