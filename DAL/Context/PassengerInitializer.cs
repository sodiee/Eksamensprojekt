using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Model;

namespace DAL.Context
{
    internal class PassengerInitializer : CreateDatabaseIfNotExists<PassengerContext> //CreateDatabaseIfNotExists<FærgeContext> DropCreateDatabaseIfModelChanges<FærgeContext>
    {
        protected override void Seed(PassengerContext context)
        {
            context.Passengers.Add(new Passenger("Mathias", "Dreng", 23, new DateTime(2001, 2, 17)));

            context.SaveChanges();
        }


        private void dummy()
        {
            string result = System.Data.Entity.SqlServer.SqlFunctions.Char(65);
        }
    }
}
