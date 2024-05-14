using DTO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DAL.Mappers
{
    internal class PassengerMapper
    {
        public static DTO.Model.Passenger Map(Passenger passenger)
        {
            return new DTO.Model.Passenger {
                            PassengerID = passenger.PassengerID,
                            FerryID = passenger.FerryID,
                            Name = passenger.Name,
                            Gender=  passenger.Gender,
                            Age= passenger.Age,
                            Birthday=  passenger.Birthday
                        };
        }

        public static Passenger Map(DTO.Model.Passenger passenger)
        {
            return new Passenger
            {
                PassengerID = passenger.PassengerID,
                FerryID = passenger.FerryID,
                Name = passenger.Name,
                Gender = passenger.Gender,
                Age = passenger.Age,
                Birthday = passenger.Birthday
            };
        }
    }
}
