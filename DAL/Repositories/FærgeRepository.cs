using DAL.Context;
using DAL.Mappers;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class FærgeRepository
    {
        public static DTO.Model.Færge GetFærge(int id)
        {
            using (FærgeContext context = new FærgeContext())
            {
                return FærgeMapper.Map(context.Færger.Find(id));
            }
        }

        public static void AddFærge(DTO.Model.Færge færge)
        {
            using (FærgeContext context = new FærgeContext())
            {
                context.Færger.Add(FærgeMapper.Map(færge));
                context.SaveChanges();
            }
        }

        /*public static void EditFærge(Færge færge)
        {
            using (FærgeContext context = new FærgeContext())
            {
                Færge dataFærge = context.Færger.Find(færge.ID);
                FærgeMapper.UpdateFærge(færge, dataFærge);

                context.SaveChanges();
            }
        }*/
    }
}
