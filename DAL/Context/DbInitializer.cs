using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Security;
using System.Net;
using System.Security.Cryptography.X509Certificates;
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
            Ferry f1 = new Ferry("Molslinjen", 40, 10, 99, 197, new List<Passenger>(), new List<Car>());
            Ferry f2 = new Ferry("Scandlines", 40, 10, 99, 197, new List<Passenger>(), new List<Car>());
            Ferry f3 = new Ferry("Stenaline", 40, 10, 99, 197, new List<Passenger>(), new List<Car>());

            Passenger passenger = new Passenger("Mathias", "Dreng", 23, new DateTime(2001, 2, 17));

            Car car = new Car("Mazda", "3", "AM12345");

            car.Passengers.Add(passenger);
            car.NumberOfPassengers++;
            f1.Passengers.Add(passenger);
            f1.Cars.Add(car);

            context.Passengers.Add(passenger) ;
            context.Cars.Add(car);
            context.Ferries.Add(f1 );
            context.Ferries.Add(f2);
            context.Ferries.Add(f3);

            context.SaveChanges();
        }

        private void dummy()
        {
            string result = System.Data.Entity.SqlServer.SqlFunctions.Char(65);
        }
    }
    }
