using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STO.Models
{
    public class IdentityContext : IdentityDbContext
    {
        public DbSet<STOModel> STO { get; set; }
        public DbSet<User> IdentityUser { get; set; }
        public DbSet<UserModel> User { get; set; }
        public IdentityContext(DbContextOptions<IdentityContext> options)
            : base(options)
        {
        }
    }
}
