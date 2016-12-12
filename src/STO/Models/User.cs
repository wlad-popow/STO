using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STO.Models
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
        public string Role { get; set; }
    }
}
