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
    internal class FærgeContext : DbContext
    {
        public FærgeContext() : base("Færger") { }

        public DbSet<Bil> Biler { get; set; }
        public DbSet<Gæst> Gæster { get; set; }
        public DbSet<Færge> Færger { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
