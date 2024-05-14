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
            var passengers = new List<Passenger>
                {
                    new Passenger("Mathias", "Dreng", 23, new DateTime(2001, 2, 17)),
                    new Passenger("Laura", "Pige", 25, new DateTime(1999, 5, 8)),
                    new Passenger("Thomas", "Mand", 30, new DateTime(1994, 10, 15)),
                    new Passenger("Emma", "Pige", 28, new DateTime(1996, 7, 20)),
                    new Passenger("Jonas", "Dreng", 22, new DateTime(2002, 3, 12)),
                };

            foreach (var passenger in passengers)
            {
                context.Passengers.Add(passenger);
            }

            context.SaveChanges();
        }


        private void dummy()
        {
            string result = System.Data.Entity.SqlServer.SqlFunctions.Char(65);
        }
    }
}
