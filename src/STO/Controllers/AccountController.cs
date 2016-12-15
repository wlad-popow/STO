using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using STO.Models;
using STO.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STO.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IdentityContext _context;

        public AccountController(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IdentityContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        [HttpGet]
        public IActionResult UserRegister()
        {
            return View();
        }

        [HttpGet]
        public IActionResult STORegister()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UserRegister(UserRegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User { Email = model.Email, UserName = model.Email, Role = "user" };

                UserModel us = new UserModel()
                {
                    ModelCar = model.Car,
                    Name = model.Email,
                    PhoneNumber = model.PhoneNumber,
                    Id = user.Id
                };

                _context.User.Add(us);
                _context.SaveChanges();

                // добавляем пользователя
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "user");
                }
                if (result.Succeeded)
                {
                    // установка куки
                    await _signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> STORegister(STORegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                User userSTO = new User { UserName = model.Name,  Name = model.Name, Role = "STO" };
                STOModel sto = new STOModel()
                {
                    Adres = model.Adres,
                    Close = model.Close,
                    Name = model.Name,
                    Open = model.Open,
                    Services = model.Services,
                    Contacts = model.Contacts,
                    Description = model.Description,
                    Rajon = model.Rajon,
                    Id = userSTO.Id
                };

                _context.STO.Add(sto);
                _context.SaveChanges();

                // добавляем пользователя
                var result = await _userManager.CreateAsync(userSTO, model.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(userSTO, "STO");
                }
                if (result.Succeeded)
                {
                    // установка куки
                    await _signInManager.SignInAsync(userSTO, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            return View(new LoginViewModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result =
                    await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    // проверяем, принадлежит ли URL приложению
                    if (!String.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Неправильный логин и (или) пароль");
                }
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogOff()
        {
            // удаляем аутентификационные куки
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        
        [HttpGet]
        public IActionResult Edit()
        {
            var user = _userManager.Users.FirstOrDefault(u=>u.UserName == Request.HttpContext.User.Identity.Name);            
            if (user.Role == "user")
            {
                var context = _context.User.FirstOrDefault(u=>u.Id==user.Id);
                UserEditViewModel model = new UserEditViewModel()
                {
                    Car = context.ModelCar,
                    Email = context.Name,
                    PhoneNumber = context.PhoneNumber
                };

                return View("UserEdit",model);
            }
            else
            {
                if (user.Role == "STOEdit")
                {
                    var context = _context.STO.FirstOrDefault(u => u.Id == user.Id);
                    STOEditViewModel model = new STOEditViewModel()
                    {
                        Adres = context.Adres,
                        Close = context.Close,
                        Name = context.Name,
                        Contacts = context.Contacts,
                        Description = context.Description,
                        Open = context.Open,
                        Rajon = context.Rajon,
                        Services = context.Services
                    };
                    return View("STOEdit",model);
                }
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult EditSTO(STOEditViewModel model)
        {
            var user = _userManager.Users.FirstOrDefault(u => u.UserName == Request.HttpContext.User.Identity.Name);
            var context = _context.STO.FirstOrDefault(u => u.Id == user.Id);
            if (ModelState.IsValid)
            {
                if (!string.IsNullOrEmpty(model.Adres))
                {
                    context.Adres = model.Adres;
                 }
                if (!string.IsNullOrEmpty(model.Name))
                {
                    context.Name = model.Name;
                    user.Name = model.Name;
                }
                if (!string.IsNullOrEmpty(model.Rajon))
                {
                    context.Rajon = model.Rajon;
                }
                if (!string.IsNullOrEmpty(model.Services))
                {
                    context.Services = model.Services;
                }
                if (!string.IsNullOrEmpty(model.Description))
                {
                    context.Description = model.Description;
                }
                if (!string.IsNullOrEmpty(model.Contacts))
                {
                    context.Contacts = model.Contacts;
                }

                _context.STO.Update(context);
                _context.SaveChanges();                

                _userManager.UpdateAsync(user);
                
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult EditUser(UserEditViewModel model)
        {
            var user = _userManager.Users.FirstOrDefault(u => u.UserName == Request.HttpContext.User.Identity.Name);
            var context = _context.User.FirstOrDefault(u => u.Id == user.Id);
            if (!string.IsNullOrEmpty(model.Car))
            {
                context.ModelCar = model.Car;
            }
            if (!string.IsNullOrEmpty(model.Email))
            {
                context.Name = model.Email;
                user.Name = model.Email;
            }
            if (!string.IsNullOrEmpty(model.PhoneNumber))
            {
                context.PhoneNumber = model.PhoneNumber;
            }

            _context.User.Update(context);
            _context.SaveChanges();

            _userManager.UpdateAsync(user);

            return RedirectToAction("Index");
        }
    }
}
