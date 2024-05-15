using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Model;
using DAL.Context;
using DAL.Mappers;
using DTO.Model;
using System.Data.Entity.Infrastructure;

namespace DAL.Repositories
{
    public class CarRepository
    {
        public static DTO.Model.Car GetCar(int id)
        { 
            using (DataBaseContext context = new DataBaseContext())
            {
                return CarMapper.Map(context.Cars.Find(id));
            }
        }

        public static void AddCar(DTO.Model.Car bilmodel)
        {
            try
            {
                using (DataBaseContext context = new DataBaseContext())
                {
                    context.Cars.Add(CarMapper.Map(bilmodel));
                    context.SaveChanges();
                }
            } catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public static void UpdateCar(DTO.Model.Car dtoCar)
        {
            using (DataBaseContext context = new DataBaseContext())
            {
                DAL.Model.Car carToUpdate = context.Cars.Find(dtoCar.CarID);

                if (carToUpdate != null)
                {
                    carToUpdate.Name = dtoCar.Name;
                    carToUpdate.Model = dtoCar.Model;
                    carToUpdate.LicensePlate = dtoCar.LicensePlate;
                }
                else
                {
                    throw new DbUpdateException();
                }

                context.SaveChanges();
            }
        }

        public static void RemoveCar(DTO.Model.Car car)
        {
            using (DataBaseContext context = new DataBaseContext())
            {
                DAL.Model.Car cToRemove = CarMapper.Map(GetCar(car.CarID));
                context.Cars.Attach(cToRemove);
                context.Cars.Remove(cToRemove);

                context.SaveChanges();
            }
        }

        public static void AddPassengerToCar(DTO.Model.Car car, DTO.Model.Passenger passenger)
        {
            using (DataBaseContext context = new DataBaseContext())
            {
                DAL.Model.Car temp = context.Cars.Find(car.CarID);
                temp.Passengers.Add(PassengerMapper.Map(passenger));

                context.SaveChanges();
            }
        }

        public static List<DTO.Model.Passenger> GetPassengers(DTO.Model.Car car)
        {
            using (var context = new DataBaseContext())
            {
                List<DTO.Model.Passenger> resList = new List<DTO.Model.Passenger>();
                var passengersOnFerry = (from c in context.Cars
                                         where c.CarID == car.CarID
                                         from passenger in c.Passengers
                                         select passenger).ToList();
                foreach (var passengers in passengersOnFerry)
                {
                    resList.Add(PassengerMapper.Map(passengers));
                }
                return resList;
            }
        }
    }
}
