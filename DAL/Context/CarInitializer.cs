using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Model;

namespace DAL.Context
{
    internal class CarInitializer : CreateDatabaseIfNotExists<CarContext> //CreateDatabaseIfNotExists<FærgeContext> DropCreateDatabaseIfModelChanges<FærgeContext>
    {
        protected override void Seed(CarContext context)
        {
            context.Cars.Add(new Car(null, 0, "Mazda", "3", "AM12345"));

            context.SaveChanges();
        }

        private void dummy()
        {
            string result = System.Data.Entity.SqlServer.SqlFunctions.Char(65);
        }
    }
}
