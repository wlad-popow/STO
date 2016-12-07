using STOCore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STOCore
{
    class CoreContext : DbContext
    {

        public DbSet<User> Users { get; set; }

        public CoreContext()
            : this("STOEntities")
        {
        }

        public CoreContext(string connectionString)
            : base(connectionString)
        {
            Configuration.AutoDetectChangesEnabled = false;
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder mb)
        {
        }
    }
}
