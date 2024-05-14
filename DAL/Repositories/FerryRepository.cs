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
            using (FerryContext context = new FerryContext())
            {
                return FerryMapper.Map(context.Ferries.Find(id));
            }
        }

        public static void AddFerry(DTO.Model.Ferry færge)
        {
            using (FerryContext context = new FerryContext())
            {
                context.Ferries.Add(FerryMapper.Map(færge));
                context.SaveChanges();
            }
        }

        public static List<DTO.Model.Ferry> getFerrys()
        {
            using (FerryContext context = new FerryContext())
            {
                List<DTO.Model.Ferry> result = new List<DTO.Model.Ferry>();
                foreach (var Ferry in context.Ferries)
                {
                    result.Add(FerryMapper.Map(Ferry));
                }
                return result;
            }
        }

        public static List<DTO.Model.Passenger> GetPassengers(DTO.Model.Ferry ferry)
        {
            using (var ferryContext = new FerryContext())
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

        public static void UpdateFerry(DTO.Model.Ferry dtoFerry)
        {
            using (FerryContext context = new FerryContext())
            {
                Ferry ferryToEdit = context.Ferries.Find(dtoFerry.FerryID);
                
                if (ferryToEdit != null)
                {
                    ferryToEdit.Name = dtoFerry.Name;

                    // Tilføj nye passagerer
                    foreach (DTO.Model.Passenger dtoPassenger in dtoFerry.Passengers)
                    {
                        if (!ferryToEdit.Passengers.Any(p => p.PassengerID == dtoPassenger.PassengerID))
                        {
                            // Passageren findes ikke på færgen, tilføj den
                            ferryToEdit.Passengers.Add(PassengerMapper.Map(dtoPassenger));
                        }
                    }

                    // Fjern passagerer, der ikke længere er på færgen
                    var passengersToRemove = ferryToEdit.Passengers.Where(p => !dtoFerry.Passengers.Any(dp => dp.PassengerID == p.PassengerID)).ToList();
                    foreach (var passengerToRemove in passengersToRemove)
                    {
                        ferryToEdit.Passengers.Remove(passengerToRemove);
                    }
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
            using (FerryContext context = new FerryContext())
            {
                // Hent færgen fra databasen
                Ferry temp = context.Ferries.Find(ferry.FerryID);

                // Tilføj passageren til færgen
                temp.Passengers.Add(PassengerMapper.Map(passenger));

                // Gem ændringerne i databasen
                context.SaveChanges();
            }
           }
    }
}
