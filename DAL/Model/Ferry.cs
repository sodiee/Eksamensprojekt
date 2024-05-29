using DAL.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Ferry
    {
        public int FerryID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int MaxNumberOfPassengers { get; set; }
        [Required]
        public int MaxNumberOfCars { get; set; }
        [Required]
        public int PricePassengers { get; set; }
        [Required]
        public int PriceCars { get; set; }
        public ICollection<Passenger> Passengers { get; set; }
        public ICollection<Car> Cars { get; set; }

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
    }
}
