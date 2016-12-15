using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using STO.Models;
using STO.ViewModels;
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
            double rating = 0;
            int i = 0;
            foreach (var e in _db.Evaluation)
            {
                if (e.STOId == id)
                {
                    rating = rating + e.Eval;
                    i++;
                }
            }

            rating = rating / i;

            List<Comment> coment = new List<Comment>();

            foreach (var c in _db.Comment)
            {
                if (c.STOId == id)
                {
                    coment.Add(c);
                }
            }

            STOCardModel model = new STOCardModel()
            {
                Adres = sto.Adres,
                Close = sto.Close,
                Coments = coment,
                Contacts = sto.Contacts,
                Description = sto.Description,
                Name = sto.Name,
                Open = sto.Open,
                Services = sto.Services,
                Rating = rating,
                Id = sto.Id
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult List()
        {
            var servises = Request.Form;
            HashSet<STOModel> sto = new HashSet<STOModel>();
            
            var r = servises.FirstOrDefault(s=>s.Key=="Rajon");

            if (servises.Count == 2)
            {
                foreach (var s in _db.STO)
                {
                    if (s.Rajon.Contains(r.Value))
                    {
                        sto.Add(s);
                    }
                }
                return View(sto);
            }

            foreach (var service in servises)
            {
                if (service.Key== "__RequestVerificationToken" || service.Key == "Rajon")
                {
                    continue;
                }
                
                foreach (var s in _db.STO)
                {
                    if (s.Services.Contains(service.Value) && s.Rajon.Contains(r.Value))
                    {
                        sto.Add(s);
                    }
                }
            }      
            return View(sto);
        }

        [HttpGet]
        public IActionResult Coments(STOCardModel stoModel)
        {            
            CommentViewModel model = new CommentViewModel()
            {
                STOId = stoModel.Id
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Coments(CommentViewModel model)
        {
            var s = Request.HttpContext.User.Identity.Name;
            if (s == null)
            {
                return RedirectToAction("Error");
            }
            var user = _db.User.FirstOrDefault(u => u.Name == s);
            string stoId = Request.Path.ToString().Remove(0,13);
            Comment coment = new Comment()
            {
                Coment = model.Coment,
                STOId = stoId,
                UserId = user.Id
            };

            _db.Comment.Add(coment);
            _db.SaveChanges();
            return RedirectToAction("Index",new RouteValueDictionary(new { controller = "STO", action = "Index", Id = coment.STOId }));
        }
    }
}
