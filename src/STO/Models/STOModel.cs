using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STO.Models
{
    public class STOModel : IdentityUser
    {
        public string Name { get; set; }
        public string Services { get; set; }
        public string Adres { get; set; }
        public DateTime Open { get; set; }
        public DateTime Close { get; set; }
    }
}
