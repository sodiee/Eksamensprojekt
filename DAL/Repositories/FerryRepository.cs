using DAL.Context;
using DAL.Mappers;
using DAL.Model;
using DTO.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class FerryRepository
    {
        public static DTO.Model.Ferry GetFerry(int id)
        {
            using (DataBaseContext context = new DataBaseContext())
            {
                return FerryMapper.Map(context.Ferries.Find(id));
            }
        }

        public static List<DTO.Model.Ferry> GetFerryList()
        {
            using (DataBaseContext context = new DataBaseContext())
            {
                List<DTO.Model.Ferry> result = new List<DTO.Model.Ferry>();
                foreach (var ferry in context.Ferries)
                {
                    var dtoFerry = FerryMapper.Map(ferry);
                    dtoFerry.Passengers = GetPassengers(dtoFerry);
                    result.Add(dtoFerry);
                }
                return result;
            }
        }

        public static List<DTO.Model.Passenger> GetPassengers(DTO.Model.Ferry ferry)
        {
            using (var ferryContext = new DataBaseContext())
            {
                List<DTO.Model.Passenger> resList = new List<DTO.Model.Passenger>();
                var passengersOnFerry = (from f in ferryContext.Ferries
                                         where f.FerryID == ferry.FerryID
                                         from passenger in f.Passengers
                                         select passenger).ToList();
                foreach (var passengers in passengersOnFerry)
                {
                    resList.Add(PassengerMapper.Map(passengers));
                }
                return resList;
            }
        }

        public static void AddFerry(DTO.Model.Ferry færge)
        {
            using (DataBaseContext context = new DataBaseContext())
            {
                context.Ferries.Add(FerryMapper.Map(færge));
                context.SaveChanges();
            }
        }

        public static List<DTO.Model.Ferry> GetFerrys()
        {
            using (DataBaseContext context = new DataBaseContext())
            {
                List<DTO.Model.Ferry> result = new List<DTO.Model.Ferry>();
                foreach (var Ferry in context.Ferries)
                {
                    result.Add(FerryMapper.Map(Ferry));
                }
                return result;
            }
        }

       

        public static void UpdateFerry(DTO.Model.Ferry dtoFerry)
        {
            using (DataBaseContext context = new DataBaseContext())
            {
                Ferry ferryToEdit = context.Ferries.Find(dtoFerry.FerryID);
                
                if (ferryToEdit != null)
                {
                    ferryToEdit.Name = dtoFerry.Name;
                }
                else
                {
                    throw new DbUpdateException();
                }

                context.SaveChanges();
            }
        }
        
        public static void AddPassengerToFerry(DTO.Model.Ferry ferry, DTO.Model.Passenger passenger)
        {
            using (DataBaseContext context = new DataBaseContext())
            {
                //!find færge i db
                Ferry temp = context.Ferries.Find(ferry.FerryID);

                //!tilføj passageren til færgen
                temp.Passengers.Add(PassengerMapper.Map(passenger));

                //!gem ændringerne i databasen
                context.SaveChanges();
            }
           }
    }
}
