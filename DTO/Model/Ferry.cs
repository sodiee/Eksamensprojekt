using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DTO.Model
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
        public double TotalPricePassengers{get{return Passengers.Count * PricePassengers;}}
        public double TotalPriceCars{get { return Cars.Count * PriceCars;}}
        public double TotalPrice { get { return TotalPriceCars + TotalPricePassengers;} }


        public Ferry() {
            Passengers = new List<Passenger>();
            Cars = new List<Car>();
        }

        public Ferry(string name, int maxNumberOfPassengers, int maxNumberOfCars, int pricePassenger, int priceCars)
        {
            this.Name = name;
            this.MaxNumberOfPassengers = maxNumberOfPassengers;
            this.MaxNumberOfCars = maxNumberOfCars;
            this.PricePassengers = pricePassenger;
            this.PriceCars = priceCars;

            this.Passengers = new List<Passenger>();
            this.Cars = new List<Car>();
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

        public override string ToString()
        {
            return "ID: " + this.FerryID + " " + this.Name + ", Cars: " + this.Cars.Count + "/" + this.MaxNumberOfCars + ", passengers: " + this.Passengers.Count + "/" + this.MaxNumberOfPassengers;
        }

        public override string ToString()
        {
            return this.FerryID + "";
        }
    }
}
