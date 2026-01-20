using Domains.DTOs;
using Domains.DTOs.Users;
using Domains.Interfaces;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication3.Controllers
{
    public class UserController : Controller
    {

        private readonly IUser _userService;

        public UserController(IUser userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }


        [HttpPost]
        public IActionResult AddNewUser(AddUserRequest request)
        {
            request.UserType = Domains.Enums.UserTypeEnum.Admin;

            var result = _userService.Add(request);

            var opResult = new OpResult();
            switch (result)
            {
                case Domains.Enums.OpStatus.Success:
                    opResult.Status = Domains.Enums.OpStatus.Success;
                    opResult.Message = "User added successfully";
                    break;
                case Domains.Enums.OpStatus.Failed:
                    opResult.Message = "Failed to add user";
                    opResult.Status = Domains.Enums.OpStatus.Failed;
                    break;
                case Domains.Enums.OpStatus.AlreadyExists:
                    opResult.Message = "User already exists";
                    opResult.Status = Domains.Enums.OpStatus.AlreadyExists;
                    break;
                default:
                    break;
            }
            return View("Add", opResult);
        }


        [HttpGet]
        public IActionResult Manage()
        {
            var users = _userService.GetAll();

            return View(users);
        }


        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var user = _userService.GetById(id);

            var result = new OpResult();
            result.EditUserRequest = user.Adapt<EditUserRequest>();

            return View(result);
        }


        [HttpPost]
        public IActionResult EditUser(EditUserRequest request)
        {
            var result = _userService.Update(request);


            var opResult = new OpResult();
            switch (result)
            {
                case Domains.Enums.OpStatus.Success:
                    opResult.Status = Domains.Enums.OpStatus.Success;
                    opResult.Message = "User updated successfully";
                    break;
                case Domains.Enums.OpStatus.Failed:
                    opResult.Message = "Failed to update user";
                    opResult.Status = Domains.Enums.OpStatus.Failed;
                    break;
                case Domains.Enums.OpStatus.AlreadyExists:
                    opResult.Message = "User already exists";
                    opResult.Status = Domains.Enums.OpStatus.AlreadyExists;
                    break;
                default:
                    break;
            }
            return Redirect($"Edit/{request.Id}");
        }


        [HttpGet]
        public IActionResult Search(string? query)
        {
            var result = _userService.Search(query);

            return View(result);
        }
    }
}
