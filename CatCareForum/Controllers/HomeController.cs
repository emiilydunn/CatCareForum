using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace CatCareForum.Controllers
{
    public class HomeController : Controller
    {
        //Constructor
        public HomeController()
        {
            
        }
        //Home page
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }
}
