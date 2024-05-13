using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Model
{
    public class Car
    {
        private List<Passenger> passengers = new List<Passenger>();
        public int CarID { get; set; }
        public Passenger Driver { get; set; }
        public int NumberOfPassengers { get; set; }
        public List<Passenger> Passenger { get { return passengers; } set { } }
        public string Name { get; set; }
        public string Model { get; set; }
        public string LicensePlate { get; set; }

        public Car() { }

        public Car(Passenger driver, int numberOfPassengers, string name, string model, string licensePlate)
        {
            this.Driver = driver;
            this.NumberOfPassengers = numberOfPassengers;
            this.passengers = new List<Passenger>();
            this.Name = name;
            this.Model = model;
            this.LicensePlate = licensePlate;

            passengers.Add(driver);
        }

        public Car(int id, Passenger driver, int numberOfPassengers, string name, string model, string licensePlate)
        {
            this.CarID = id;
            this.Driver = driver;
            this.NumberOfPassengers = numberOfPassengers;
            this.passengers = new List<Passenger>();
            this.Name = name;
            this.Model = model;
            this.LicensePlate = licensePlate;

            passengers.Add(driver);
        }
    }
}
