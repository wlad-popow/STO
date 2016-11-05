using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STO.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View("UserRegistrationView");
        }

        [HttpGet]
        public IActionResult Create()
        {
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
