﻿using DAL.Repositories;
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
            //valider ferry
            FerryRepository.AddFerry(ferry);
        }
        public void UpdateFerry(Ferry ferry)
        {
            FerryRepository.UpdateFerry(ferry);
        }

        public List<Ferry> GetFerryList()
        {
            return FerryRepository.getFerrys();
        }

        public List<Passenger> GetPassengers(Ferry ferry)
        {
            return FerryRepository.GetPassengers(ferry);
        }

        public void AddPassengerToFerry(Ferry ferry, Passenger passenger) 
        {
            FerryRepository.AddPassengerToFerry(ferry, passenger);
        }
    }
}
