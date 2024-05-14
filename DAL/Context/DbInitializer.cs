using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Mappers;
using DAL.Model;
using DAL.Repositories;

namespace DAL.Context
{
    public class DbInitializer : CreateDatabaseIfNotExists<DataBaseContext> //CreateDatabaseIfNotExists<FærgeContext> DropCreateDatabaseIfModelChanges<FærgeContext>
    {
        protected override void Seed(DataBaseContext context)
        {
            //Ferry
            context.Ferries.Add(new Ferry("Molslinjen", 100, 400, new List<Car>()));
            context.Ferries.Add(new Ferry("Scandlines", 10, 40, new List<Car>()));
            context.Ferries.Add(new Ferry("Stenaline", 50, 200, new List<Car>()));



            //Passengers
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

            //Car
            context.Cars.Add(new Car(null, 0, "Mazda", "3", "AM12345"));

            context.SaveChanges();
        }


        private void dummy()
        {
            string result = System.Data.Entity.SqlServer.SqlFunctions.Char(65);
        }
    }
    }
