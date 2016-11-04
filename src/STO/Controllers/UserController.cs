using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STO.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Create()
        {
            return RedirectToAction("Index");
        }

        public IActionResult Get()
        {
            return RedirectToAction("Index");
        }

        public IActionResult Update()
        {
            return RedirectToAction("Index");
        }

        public IActionResult Delete()
        {
            return RedirectToAction("Index");
        }
    }
}
