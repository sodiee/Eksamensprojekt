using DAL.Context;
using DAL.Mappers;
using DAL.Model;
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

        public static void EditFærge(DTO.Model.Ferry dtoFerry)
        {
            using (FerryContext context = new FerryContext())
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
        /*
        public static void AddGæstTilFærge(DTO.Model.Færge færge, DTO.Model.Gæst gæst)
        {
            Færge temp;
            using (FærgeContext context = new FærgeContext())
            {
                temp = context.Færger.Find(færge.ID);
                temp.Gæster.Add(gæst);
                context.SaveChanges();
            }
        }*/
    }
}
