using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Model;

namespace DAL.Mappers
{
    internal class CarMapper
    {
        public static DTO.Model.Car Map(Car bil)
        {
            List<DTO.Model.Passenger> resList = new List<DTO.Model.Passenger>();
            foreach (var passenger in bil.Passengers)
            {
                resList.Add(PassengerMapper.Map(passenger));
            }
            return new DTO.Model.Car {
                CarID = bil.CarID,
                FerryID = bil.FerryID,
                Passengers = resList,
                            NumberOfPassengers= bil.NumberOfPassengers,
                            Name = bil.Name,
                            Model=bil.Model,
                            LicensePlate = bil.LicensePlate
                        };
        }

        public static Car Map(DTO.Model.Car bil)
        {
            List<Passenger> resList = new List<Passenger>();
            foreach (var passenger in bil.Passengers)
            {
                resList.Add(PassengerMapper.Map(passenger));
            }
            return new Car
            {
                CarID = bil.CarID,
                FerryID = bil.FerryID,
                Passengers = resList,
                NumberOfPassengers = bil.NumberOfPassengers,
                Name = bil.Name,
                Model = bil.Model,
                LicensePlate = bil.LicensePlate
            };
        }
    }
}
