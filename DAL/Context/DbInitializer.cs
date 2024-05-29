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
            // Creating Ferries
            Ferry f1 = new Ferry("Molslinjen", 40, 10, 99, 197, new List<Passenger>(), new List<Car>());
            Ferry f2 = new Ferry("Scandlines", 200, 50, 99, 197, new List<Passenger>(), new List<Car>());
            Ferry f3 = new Ferry("Stenaline", 400, 80, 99, 197, new List<Passenger>(), new List<Car>());
            Ferry f4 = new Ferry("Color Line", 600, 120, 99, 197, new List<Passenger>(), new List<Car>());
            Ferry f5 = new Ferry("DFDS", 300, 60, 99, 197, new List<Passenger>(), new List<Car>());

            // Creating Passengers
            Passenger p1 = new Passenger("Mathias", "Dreng", 23, new DateTime(2001, 2, 17));
            Passenger p2 = new Passenger("Sophie", "Pige", 30, new DateTime(1994, 5, 24));
            Passenger p3 = new Passenger("Oliver", "Dreng", 45, new DateTime(1979, 9, 13));
            Passenger p4 = new Passenger("Emilia", "Pige", 20, new DateTime(2003, 1, 8));
            Passenger p5 = new Passenger("Lucas", "Dreng", 36, new DateTime(1988, 7, 21));

            // Creating Cars
            Car car1 = new Car("Mazda", "3", "AM12345");
            Car car2 = new Car("Toyota", "Corolla", "XY98765");
            Car car3 = new Car("Ford", "Focus", "FG56789");
            Car car4 = new Car("Volkswagen", "Golf", "VW12367");
            Car car5 = new Car("BMW", "X3", "BM87654");

            // Adding passengers to cars
            car1.Passengers.Add(p1);
            car1.NumberOfPassengers++;
            car2.Passengers.Add(p2);
            car2.NumberOfPassengers++;
            car3.Passengers.Add(p3);
            car3.NumberOfPassengers++;
            car4.Passengers.Add(p4);
            car4.NumberOfPassengers++;
            car5.Passengers.Add(p5);
            car5.NumberOfPassengers++;

            // Assigning cars and passengers to ferries
            f1.Passengers.Add(p1);
            f1.Cars.Add(car1);
            f2.Passengers.Add(p2);
            f2.Cars.Add(car2);
            f3.Passengers.Add(p3);
            f3.Cars.Add(car3);
            f4.Passengers.Add(p4);
            f4.Cars.Add(car4);
            f5.Passengers.Add(p5);
            f5.Cars.Add(car5);

            // Adding entities to context
            context.Passengers.Add(p1);
            context.Passengers.Add(p2);
            context.Passengers.Add(p3);
            context.Passengers.Add(p4);
            context.Passengers.Add(p5);
            context.Cars.Add(car1);
            context.Cars.Add(car2);
            context.Cars.Add(car3);
            context.Cars.Add(car4);
            context.Cars.Add(car5);
            context.Ferries.Add(f1);
            context.Ferries.Add(f2);
            context.Ferries.Add(f3);
            context.Ferries.Add(f4);
            context.Ferries.Add(f5);

            context.SaveChanges();
        }

        private void dummy()
        {
            string result = System.Data.Entity.SqlServer.SqlFunctions.Char(65);
        }
    }
    }
