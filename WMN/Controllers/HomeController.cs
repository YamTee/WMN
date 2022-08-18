using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WMN.Models;
using WMNDataAccess.Models;
using WMNDataAccess.DataAccess;

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

        public IActionResult Index()
        {
            return View();
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
        public IActionResult CreateUser(User user)
        {
            if (ModelState.IsValid)
            {
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