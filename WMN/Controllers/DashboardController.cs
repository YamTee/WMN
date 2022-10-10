using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WMN.Attributes;

namespace WMN.Controllers
{
    [SessionExpire]
    public class DashboardController : Controller
    {
        [HttpGet]
        //[Route("dashboard")]
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}

