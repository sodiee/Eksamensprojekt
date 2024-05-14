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

            foreach (var DALPassenger in ferry.Passengers)
            {
                ferryPassengers.Add(new DTO.Model.Passenger(DALPassenger.Name, DALPassenger.Gender, DALPassenger.Age, DALPassenger.Birthday));
            }

            List<DTO.Model.Car> ferryCars = new List<DTO.Model.Car>();

            foreach (var DALCar in ferry.Cars)
            {
                ferryCars.Add(new DTO.Model.Car(new DTO.Model.Passenger(DALCar.Driver.Name, DALCar.Driver.Gender, DALCar.Driver.Age, DALCar.Driver.Birthday), 
                    DALCar.NumberOfPassengers, DALCar.Name, DALCar.Model, DALCar.LicensePlate));
            }

            return new DTO.Model.Ferry(
                            ferry.FerryID,
                            ferry.Name,
                            ferry.MaxNumberOfPassengers,
                            ferry.MaxNumberOfCars,
                            ferry.PricePassengers,
                            ferry.PriceCars,
                            ferryPassengers,
                            ferryCars
                        );
        }

        public static Ferry Map(DTO.Model.Ferry ferry)
        {
            List<Passenger> ferryPassengers = new List<Passenger>();

            foreach (var DTOPassenger in ferry.Passengers)
            {
                ferryPassengers.Add(new Passenger(DTOPassenger.Name, DTOPassenger.Gender, DTOPassenger.Age, DTOPassenger.Birthday));
            }

            List<DAL.Model.Car> ferryCars = new List<DAL.Model.Car>();

            foreach (var DTObil in ferry.Cars)
            {
                ferryCars.Add(new DAL.Model.Car(new Passenger(DTObil.Driver.Name, DTObil.Driver.Gender, DTObil.Driver.Age, DTObil.Driver.Birthday),
                    DTObil.NumberOfPassengers, DTObil.Name, DTObil.Model, DTObil.LicensePlate));
            }

            return new Ferry(
                            ferry.FerryID,
                            ferry.Name,
                            ferry.MaxNumberOfPassengers,
                            ferry.MaxNumberOfCars,
                            ferry.PricePassengers,
                            ferry.PriceCars,
                            ferryPassengers,
                            ferryCars
                        );
        }
    }
}
