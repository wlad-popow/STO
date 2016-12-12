using Microsoft.AspNetCore.Mvc;
using STO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STO.Controllers
{
    public class STOController : Controller
    {
        IdentityContext _db;

        public STOController(IdentityContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Index(string id)
        {
            var sto = _db.STO.FirstOrDefault(s => s.Id == id);
            return View(sto);
        }
    }
}
