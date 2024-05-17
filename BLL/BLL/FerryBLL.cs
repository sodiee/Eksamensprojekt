using DAL.Repositories;
using DTO.Model;
using System;
using System.Collections.Generic;

namespace BLL.BLL
{
    public class FerryBLL
    {
        public Ferry GetFerry(int id)
        {
            if (id < 0) throw new IndexOutOfRangeException();
            return FerryRepository.GetFerry(id);
        }
        public void AddFerry(Ferry ferry)
        {
            FerryRepository.AddFerry(ferry);
        }
        public void UpdateFerry(Ferry ferry)
        {
            FerryRepository.UpdateFerry(ferry);
        }

        public List<Ferry> GetFerryList()
        {
            return FerryRepository.GetFerryList();
        } 

        public List<Passenger> GetPassengers(Ferry ferry)
        {
            return FerryRepository.GetPassengers(ferry);
        }

        public List<Car> GetCars(Ferry ferry)
        {
            return FerryRepository.GetCars(ferry);
        }

        public void AddPassengerToFerry(Ferry ferry, Passenger passenger) 
        {
            if (ferry.Passengers.Count < ferry.MaxNumberOfPassengers - 1)
            {
                FerryRepository.AddPassengerToFerry(ferry, passenger);
            }
            else
            {
                throw new Exception("Der kan ikke tilføjes flere biler til færgen");
            }
        }

        public void AddCarToFerry(Ferry ferry, Car car)
        {
            if (ferry.Cars.Count < ferry.MaxNumberOfCars - 1)
            {
                FerryRepository.AddCarToFerry(ferry, car);
            } else
            {
                throw new Exception("Der kan ikke tilføjes flere biler til færgen");
            }
        }

        public void RemoveFerry(int id)
        {
            FerryRepository.RemoveFerry(GetFerry(id));
        }

        public void RemoveAllFerries()
        {
            throw new NotImplementedException();
        }
    }
}
