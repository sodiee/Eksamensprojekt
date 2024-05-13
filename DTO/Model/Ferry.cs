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
        private List<Passenger> passengers = new List<Passenger>();
        private List<Car> cars = new List<Car>();
        public int FerryID { get; set; }
        public string Name { get; set; }
        public int MaxNumberOfPassengers { get; set; }
        public int MaxNumberOfCars { get; set; }
        public List<Passenger> Passengers { get { return passengers; } set { } }
        public List<Car> Cars { get { return cars; } set { } }

        public Ferry() { }

        public Ferry(string name, int maxNumberOfPassengers, int maxNumberOfCars, List<Passenger> passengers, List<Car> cars)
        {
            this.Name = name;
            this.MaxNumberOfPassengers = maxNumberOfPassengers;
            this.MaxNumberOfCars = maxNumberOfCars;

            this.passengers = passengers;
            this.cars = cars;
        }

        public Ferry(int id, string name, int maxNumberOfPassengers, int maxNumberOfCars, List<Passenger> passengers, List<Car> cars)
        {
            this.FerryID = id;
            this.Name = name;
            this.MaxNumberOfPassengers = maxNumberOfPassengers;
            this.MaxNumberOfCars = maxNumberOfCars;

            this.passengers = passengers;
            this.cars = cars;
        }
    }
}
