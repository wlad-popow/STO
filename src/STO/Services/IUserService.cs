using STO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STO.Services
{
    public interface IUserService
    {
        User Get(string id);
        void Create(User user);
        void Update(UserViewModel user);
        void Delete(string id);
    }
}
