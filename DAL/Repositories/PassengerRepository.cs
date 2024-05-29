using DAL.Context;
using DAL.Mappers;
using DAL.Model;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
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
                context.Passengers.Attach(pToRemove);
                context.Passengers.Remove(pToRemove);

                context.SaveChanges ();
            }
        }

        public static void UpdatePassenger(DTO.Model.Passenger dtoPassenger)
        {
            using (DataBaseContext context = new DataBaseContext())
            {
                Passenger passengerToUpdate = context.Passengers.Find(dtoPassenger.PassengerID);

                if (passengerToUpdate != null)
                {
                    passengerToUpdate.Name = dtoPassenger.Name;
                    passengerToUpdate.Gender = dtoPassenger.Gender;
                    passengerToUpdate.Age = dtoPassenger.Age;
                    passengerToUpdate.Birthday = dtoPassenger.Birthday;
                }
                else
                {
                    throw new DbUpdateException();
                }

                context.SaveChanges();
            }
        }
    }
}
