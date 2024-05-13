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
    internal class BilContext : DbContext
    {
        public BilContext() : base("Biler") { }


        public DbSet<Bil> Biler { get; set; }
        public DbSet<Gæst> Gæster { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        /*public void UpdateBil(int bilId, BilModel bil)
        {
            var oldBil = Biler.FirstOrDefault(b => b.ID == bilId);

            if (oldBil != null)
            {
                oldBil.ID = bil.ID;
                oldBil.Model = bil.Model;
                oldBil.Mærke = bil.Mærke;

                SaveChanges();
            }
        }*/
    }
}
