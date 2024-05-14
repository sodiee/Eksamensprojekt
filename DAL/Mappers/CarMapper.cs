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
            return new DTO.Model.Car(
                            bil.CarID,
                            new DTO.Model.Passenger(bil.Driver.Name, bil.Driver.Gender, bil.Driver.Age, bil.Driver.Birthday),
                            bil.NumberOfPassengers,
                            bil.Name,
                            bil.Model,
                            bil.LicensePlate
                        );
        }

        public static Car Map(DTO.Model.Car bil)
        {
            return new Car(
                bil.CarID,
                new Passenger(bil.Driver.Name, bil.Driver.Gender, bil.Driver.Age, bil.Driver.Birthday),
                bil.NumberOfPassengers,
                bil.Name,
                bil.Model,
                bil.LicensePlate
                );
        }
    }
}
