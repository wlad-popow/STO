using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using STO.Models;
using STO.ViewModels;

namespace STO.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<User> _userManager;

        IdentityContext _db;
        
        public HomeController(UserManager<User> userManager, IdentityContext db)
        {
            _userManager = userManager;
            _db = db;
        }

        public IActionResult Index()
        {
            List<STORatingViewModel> stos = new List<STORatingViewModel>();
            List<Evaluation> eval = new List<Evaluation>();
            foreach (var s in _db.Evaluation)
            {
                eval.Add(s);
            }

            foreach (var s in _db.STO)
            {
                double rating = 0;
                int i = 0;
                foreach (var e in eval)
                {
                    if (e.STOId == s.Id)
                    {
                        rating = rating + e.Eval;
                        i++;
                    }
                }

                STORatingViewModel model = new STORatingViewModel()
                {
                    Id = s.Id,
                    Name = s.Name,
                    Raiting = rating / i
                };

                stos.Add(model);
            }
           
            return View(stos);
        }        

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
