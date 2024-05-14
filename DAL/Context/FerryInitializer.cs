using DAL.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Context
{
    internal class FerryInitializer : DropCreateDatabaseIfModelChanges<FerryContext> //CreateDatabaseIfNotExists<FærgeContext> DropCreateDatabaseIfModelChanges<FærgeContext>
    {
        protected override void Seed(FerryContext context)
        {
            context.Ferries.Add(new Ferry("Molslinjen", 100, 40, new List<Passenger>(), new List<Car>()));
            context.Ferries.Add(new Ferry("Scandlines", 100, 40, new List<Passenger>(), new List<Car>()));

            context.SaveChanges();
        }

        private void dummy()
        {
            string result = System.Data.Entity.SqlServer.SqlFunctions.Char(65);
        }
    }
}
