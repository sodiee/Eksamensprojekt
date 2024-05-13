using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DAL.Model;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DAL.Context
{
    internal class FerryContext : DbContext
    {
        public FerryContext() : base("Ferries") { }
        public DbSet<Ferry> Ferries { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
