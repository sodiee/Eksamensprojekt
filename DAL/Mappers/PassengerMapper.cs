using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappers
{
    internal class PassengerMapper
    {
        public static DTO.Model.Passenger Map(Passenger gæst)
        {
            return new DTO.Model.Passenger(
                            gæst.Name,
                            gæst.Gender,
                            gæst.Age,
                            gæst.Birthday
                        );
        }

        public static Passenger Map(DTO.Model.Passenger gæst)
        {
            return new Passenger(
                            gæst.Name,
                            gæst.Gender,
                            gæst.Age,
                            gæst.Birthday
                        );
        }
    }
}
