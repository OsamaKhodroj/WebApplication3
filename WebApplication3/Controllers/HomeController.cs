using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;
using System.IO;


namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;

        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }



        [HttpGet]
        public IActionResult Index()
        {  
            return View();
        }


        [HttpGet]
        public IActionResult Privacy()
        {
            return View();
        }




        public IActionResult AboutUs()
        { 
            return View();
        }




        [HttpPost]
        public IActionResult AddNewUser(string userName, string address)
        {
            return View("Index");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
