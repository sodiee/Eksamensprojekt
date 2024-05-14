using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DTO.Model
{
    public class Ferry
    {
        private ICollection<Passenger> passengers = new List<Passenger>();
        private List<Car> cars = new List<Car>();
        public int FerryID { get; set; }
        public string Name { get; set; }
        public int MaxNumberOfPassengers { get; set; }
        public int MaxNumberOfCars { get; set; }
        public ICollection<Passenger> Passengers { get { return passengers; } set { } }
        public List<Car> Cars { get { return cars; } set { } }

        public Ferry() { }

        public Ferry(string name, int maxNumberOfPassengers, int maxNumberOfCars, List<Car> cars)
        {
            this.Name = name;
            this.MaxNumberOfPassengers = maxNumberOfPassengers;
            this.MaxNumberOfCars = maxNumberOfCars;

            //this.Passengers = new List<Passenger>();
            this.cars = cars;
        }

        public Ferry(int id, string name, int maxNumberOfPassengers, int maxNumberOfCars,List<Car> cars)
        {
            this.FerryID = id;
            this.Name = name;
            this.MaxNumberOfPassengers = maxNumberOfPassengers;
            this.MaxNumberOfCars = maxNumberOfCars;

            //this.Passengers = new List<Passenger>();
            this.cars = cars;
        }

        public void AddPassenger(Passenger passenger)
        {
            Passengers.Add(passenger);
        }

        public void DeletePassenger(Passenger passenger)
        {
            Passengers.Remove(passenger);
        }

        public override string ToString()
        {
            return "ID: " + this.FerryID + " " + this.Name + ", Cars: " + this.Cars.Count + "/" + this.MaxNumberOfCars + ", passengers: " + this.Passengers.Count + "/" + this.MaxNumberOfPassengers;
        }
    }
}
