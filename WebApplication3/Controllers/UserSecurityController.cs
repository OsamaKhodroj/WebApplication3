using Domains.DTOs.Users;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace WebApplication3.Controllers
{
    public class UserSecurityController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        [HttpGet]
        public IActionResult CreateUser()
        {
            return View();
        }


        [HttpPost]
        public IActionResult LoginPost()
        { 
            var loginRequest = new LoginRequest();
            loginRequest.Username = "admin";
            loginRequest.Password = "password123";
             
            var userService = new UserService();
            var response = userService.Login(loginRequest);
            if (response != null)
            {
                //sucess
            }
            else
            {
                //error
            } 
            return View();
        }
    }
}
