using DAL.Model;
using DTO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappers
{
    internal class FerryMapper
    {
        public static DTO.Model.Ferry Map(Ferry ferry)
        {
            List<DTO.Model.Passenger> ferryPassengers = new List<DTO.Model.Passenger>();

            if (ferry.Passengers.Count != 0)
            {
                foreach (var DALPassenger in ferry.Passengers)
                {
                    ferryPassengers.Add(new DTO.Model.Passenger(DALPassenger.Name, DALPassenger.Gender, DALPassenger.Age, DALPassenger.Birthday));
                }
            }

            List<DTO.Model.Car> ferryCars = new List<DTO.Model.Car>();

            if (ferry.Cars.Count != 0)
            {
                foreach (var DALCar in ferry.Cars)
                {
                    ferryCars.Add(new DTO.Model.Car(DALCar.NumberOfPassengers, DALCar.Name, DALCar.Model, DALCar.LicensePlate));
                }
            }

            return new DTO.Model.Ferry {
                            FerryID = ferry.FerryID,
                            Name = ferry.Name,
                            MaxNumberOfPassengers = ferry.MaxNumberOfPassengers,
                            MaxNumberOfCars = ferry.MaxNumberOfCars,
                            PricePassengers = ferry.PricePassengers,
                            PriceCars = ferry.PriceCars,
                            Passengers = ferryPassengers,
                            Cars= ferryCars
                        };
        }

        public static Ferry Map(DTO.Model.Ferry ferry)
        {
            List<Passenger> ferryPassengers = new List<Passenger>();

            if (ferry.Passengers.Count != 0)
            {
                foreach (var DTOPassenger in ferry.Passengers)
                {
                    ferryPassengers.Add(new Passenger(DTOPassenger.Name, DTOPassenger.Gender, DTOPassenger.Age, DTOPassenger.Birthday));
                }
            }
            List<DAL.Model.Car> ferryCars = new List<DAL.Model.Car>();

            if (ferry.Cars.Count != 0)
            {
                foreach (var DTObil in ferry.Cars)
                {
                    ferryCars.Add(new DAL.Model.Car(
                        DTObil.NumberOfPassengers, DTObil.Name, DTObil.Model, DTObil.LicensePlate));
                }
            }

            return new Ferry
            {
                FerryID = ferry.FerryID,
                Name = ferry.Name,
                MaxNumberOfPassengers = ferry.MaxNumberOfPassengers,
                MaxNumberOfCars = ferry.MaxNumberOfCars,
                PricePassengers = ferry.PricePassengers,
                PriceCars = ferry.PriceCars,
                Passengers = ferryPassengers,
                Cars = ferryCars
            };
        }
    }
}
