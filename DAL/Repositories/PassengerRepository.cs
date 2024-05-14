using DAL.Context;
using DAL.Mappers;
using DAL.Model;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class PassengerRepository
    {
        public static DTO.Model.Passenger GetPassenger(int id)
        {
            using (DataBaseContext context = new DataBaseContext())
            {
                return PassengerMapper.Map(context.Passengers.Find(id));
            }
        }

        public static void AddPassenger(DTO.Model.Passenger gæst)
        {
            using (DataBaseContext context = new DataBaseContext())
            {
                Passenger addedPassenger = context.Passengers.Add(PassengerMapper.Map(gæst));
                context.SaveChanges();

                gæst.PassengerID = addedPassenger.PassengerID;
            }
        }

        public static void RemovePassenger(DTO.Model.Passenger passenger)
        {
            using (DataBaseContext context = new DataBaseContext())
            {
                Passenger pToRemove = PassengerMapper.Map(GetPassenger(passenger.PassengerID));
                context.Passengers.Remove(pToRemove);

                context.SaveChanges ();
            }
        }

        /*public static void EditGæst(Gæst gæst)
        {
            using (FærgeContext context = new FærgeContext())
            {
                Gæst dataGæst = context.Gæster.Find(gæst.ID);
                GæstMapper.UpdateFærge(gæst, dataGæst);

                context.SaveChanges();
            }
        }*/
    }
}
