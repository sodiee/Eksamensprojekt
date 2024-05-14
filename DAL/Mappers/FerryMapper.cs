using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappers
{
    internal class FerryMapper
    {
        public static DTO.Model.Ferry Map(Ferry færge)
        {
            List<DTO.Model.Passenger> færgeGæster = new List<DTO.Model.Passenger>();
            List<DTO.Model.Car> færgeBiler = new List<DTO.Model.Car>();

            foreach (var DALgæst in færge.Passengers)
            {
                færgeGæster.Add(new DTO.Model.Passenger(DALgæst.Name, DALgæst.Gender, DALgæst.Age, DALgæst.Birthday));
            }

            foreach (var DALbil in færge.Cars)
            {
                færgeBiler.Add(new DTO.Model.Car(new DTO.Model.Passenger(DALbil.Driver.Name, DALbil.Driver.Gender, DALbil.Driver.Age, DALbil.Driver.Birthday), 
                    DALbil.NumberOfPassengers, DALbil.Name, DALbil.Model, DALbil.LicensePlate));
            }

            return new DTO.Model.Ferry(
                            færge.FerryID,
                            færge.Name,
                            færge.MaxNumberOfPassengers,
                            færge.MaxNumberOfCars,
                            færgeGæster,
                            færgeBiler
                        );
        }

        public static Ferry Map(DTO.Model.Ferry færge)
        {
            List<Passenger> færgeGæster = new List<Passenger>();
            List<Car> færgeBiler = new List<Car>();

            foreach (var DTOgæst in færge.Passengers)
            {
                færgeGæster.Add(new Passenger(DTOgæst.Name, DTOgæst.Gender, DTOgæst.Age, DTOgæst.Birthday));
            }

            foreach (var DTObil in færge.Cars)
            {
                færgeBiler.Add(new Car(new Passenger(DTObil.Driver.Name, DTObil.Driver.Gender, DTObil.Driver.Age, DTObil.Driver.Birthday),
                    DTObil.NumberOfPassengers, DTObil.Name, DTObil.Model, DTObil.LicensePlate));
            }

            return new Ferry(
                            færge.FerryID,
                            færge.Name,
                            færge.MaxNumberOfPassengers,
                            færge.MaxNumberOfCars,
                            færgeGæster,
                            færgeBiler
                        );
        }
    }
}
