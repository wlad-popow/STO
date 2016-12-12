using Microsoft.AspNetCore.Mvc;
using STO.Models;
using System;
using System.Collections.Generic;
using System.Linq;

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

        [HttpPost]
        public IActionResult List()
        {
            var servises = Request.Form;
            List<STOModel> sto = new List<STOModel>();
            foreach (var service in servises)
            {
                if (service.Key== "__RequestVerificationToken")
                {
                    continue;
                }
                foreach (var s in _db.STO)
                {
                    if (s.Services.Contains(service.Value))
                    {
                        sto.Add(s);
                    }
                }
            }      
            return View(sto);
        }
    }
}
