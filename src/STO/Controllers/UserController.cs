using Microsoft.AspNetCore.Mvc;
using STO.Models;
using STO.Services;

namespace STO.Controllers
{
    public class UserController : Controller
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View("UserRegistrationView");
        }

        [HttpPost]
        public IActionResult Create(User model)
        {
            _userService.Create(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Get()
        {
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update()
        {
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete()
        {
            return RedirectToAction("Index");
        }
    }
}
