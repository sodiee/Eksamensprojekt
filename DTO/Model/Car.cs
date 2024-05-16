using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Model
{
    public class Car
    {
        public int CarID { get; set; }
        public int NumberOfPassengers { get; set; }
        public ICollection<Passenger> Passengers { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public string LicensePlate { get; set; }
        public int FerryID { get; set; }

        public Car()
        {
            Passengers = new List<Passenger>();
        }

        public Car(string name, string model, string licensePlate)
        {
            this.Passengers = new List<Passenger>();
            this.NumberOfPassengers = Passengers.Count;
            this.Name = name;
            this.Model = model;
            this.LicensePlate = licensePlate;

        }

        public Car(int id, string name, string model, string licensePlate)
        {
            this.CarID = id;
            this.Passengers = new List<Passenger>();
            this.NumberOfPassengers = Passengers.Count;
            this.Name = name;
            this.Model = model;
            this.LicensePlate = licensePlate;

        }

        public override string ToString()
        {
            return Name + " " + Model + " : " + LicensePlate;
        }
    }
}
