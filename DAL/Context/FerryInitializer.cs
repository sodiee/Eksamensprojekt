using DAL.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Context
{
    internal class FerryInitializer : CreateDatabaseIfNotExists<FerryContext> //CreateDatabaseIfNotExists<FærgeContext> DropCreateDatabaseIfModelChanges<FærgeContext>
    {
        protected override void Seed(FerryContext context)
        {
            context.Ferries.Add(new Ferry("Morslinjen", 100, 40, new List<Passenger>(), new List<Car>()));

            context.SaveChanges();
        }

        private void dummy()
        {
            string result = System.Data.Entity.SqlServer.SqlFunctions.Char(65);
        }
    }
}
