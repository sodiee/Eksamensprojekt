using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Model
{
    public class Car
    {
        public int CarID { get; set; }
        //public Passenger Driver { get; set; }
        public int NumberOfPassengers { get; set; }
        public ICollection<Passenger> Passengers { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public string LicensePlate { get; set; }
        //public int PassengerID { get; set; }
        public int FerryID { get; set; }

        public Car()
        {
            Passengers = new List<Passenger>();
        }

        public Car(string name, string model, string licensePlate)
        {
            //this.Driver = driver;
            this.Passengers = new List<Passenger>();
            this.NumberOfPassengers = Passengers.Count;
            this.Name = name;
            this.Model = model;
            this.LicensePlate = licensePlate;

            //Passengers.Add(driver);
        }

        public Car(int id, string name, string model, string licensePlate)
        {
            this.CarID = id;
            //this.Driver = driver;
            this.Passengers = new List<Passenger>();
            this.NumberOfPassengers = Passengers.Count;
            this.Name = name;
            this.Model = model;
            this.LicensePlate = licensePlate;

            //Passengers.Add(driver);
        }

        public override string ToString()
        {
            return Name + " " + Model + " : " + LicensePlate;
        }
    }
}
