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
    public class GæstRepository
    {
        public static DTO.Model.Gæst GetGæst(int id)
        {
            using (FærgeContext context = new FærgeContext())
            {
                return GæstMapper.Map(context.Gæster.Find(id));
            }
        }

        public static void AddGæst(DTO.Model.Gæst gæst)
        {
            using (FærgeContext context = new FærgeContext())
            {
                context.Gæster.Add(GæstMapper.Map(gæst));
                context.SaveChanges();
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
