using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using STO.Models;

namespace STO.Services
{
    public class UserService : IUserService
    {
        private UserManager<User> _userManager;

        public UserService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public User Get(string id)
        {
            var user = _userManager.Users.FirstOrDefault(i => i.Id == id);
            if (user != null)
            {
                return user;
            }
            else
            {
                throw new Exception("User not found");
            }
        }

        public void Create(UserViewModel user)
        {
            User newUser = new User()
            {
                CarModel = user.CarModel,
                PhoneNumber = user.PhoneNumber
            };

            _userManager.CreateAsync(newUser);
        }

        public void Update(UserViewModel user)
        {
            var newUser = Get(user.Id);
            if (newUser != null)
            {
                newUser.CarModel = user.CarModel;
                newUser.CarModel = user.PhoneNumber;
                if (!string.IsNullOrWhiteSpace(user.NewPassword))
                {
                    Task<IdentityResult> changePasswordResult = _userManager.ChangePasswordAsync(newUser, user.CurrentPassword, user.NewPassword);

                    if (changePasswordResult.Exception != null)
                    {
                        throw new Exception(changePasswordResult.Exception.Message);
                    }
                }
                _userManager.UpdateAsync(newUser);
            }
            else
            {
                throw new Exception("User id not found");
            }
        }

        public void Delete(string id)
        {
            if (_userManager.FindByIdAsync(id) != null)
            {
                var user = Get(id);
                _userManager.DeleteAsync(user);
            }
            else
            {
                throw new Exception("User id not found");
            }
        }
    }
}
