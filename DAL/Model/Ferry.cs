using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Ferry
    {
        public int FerryID { get; set; }
        public string Name { get; set; }
        public int MaxNumberOfPassengers { get; set; }
        public int MaxNumberOfCars { get; set; }
        public int PricePassengers { get; set; }
        public int PriceCars { get; set; }
        public ICollection<Passenger> Passengers { get; set; }
        public List<Car> Cars { get; set; }

        public Ferry()
        {
            Passengers = new List<Passenger>();
            Cars = new List<Car>();
        }

        public Ferry(string name, int maxNumberOfPassengers, int maxNumberOfCars, int pricePassenger, int priceCars, List<Passenger> passengers, List<Car> cars)
        {
            this.Name = name;
            this.MaxNumberOfPassengers = maxNumberOfPassengers;
            this.MaxNumberOfCars = maxNumberOfCars;
            this.PricePassengers = pricePassenger;
            this.PriceCars = priceCars;

            this.Passengers = passengers;
            this.Cars = cars;
        }

        public Ferry(int id, string name, int maxNumberOfPassengers, int maxNumberOfCars, int pricePassenger, int priceCars, List<Passenger> passengers, List<Car> cars)
        {
            this.FerryID = id;
            this.Name = name;
            this.MaxNumberOfPassengers = maxNumberOfPassengers;
            this.MaxNumberOfCars = maxNumberOfCars;
            this.PricePassengers = pricePassenger;
            this.PriceCars = priceCars;

            this.Passengers = passengers;
            this.Cars = cars;
        }

        public void AddPassenger(Passenger passenger)
        {
            Passengers.Add(passenger);
        }

        public void DeletePassenger(Passenger passenger)
        {
            Passengers.Remove(passenger);
        }

       
    }
}
