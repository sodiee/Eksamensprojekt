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
            //valider ferry
            FerryRepository.AddFerry(ferry);
        }
        public void EditFerry(Ferry ferry)
        {

        }

        public List<Ferry> GetFerryList()
        {
            return FerryRepository.getFerrys();
        }

        /*public void AddGæstTilFærge(Færge færge, Gæst gæst) 
        {
            FærgeRepository.AddGæstTilFærge(færge, gæst);
        }*/
    }
}
