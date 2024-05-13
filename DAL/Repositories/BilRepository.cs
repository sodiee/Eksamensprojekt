using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Model;
using DAL.Context;
using DAL.Mappers;

namespace DAL.Repositories
{
    public class BilRepository
    {
        public static DTO.Model.Bil GetBil(int id)
        {
            using (FærgeContext context = new FærgeContext())
            {
                return BilMapper.Map(context.Biler.Find(id));
            }
        }

        public static void AddBil(DTO.Model.Bil bilmodel)
        {
            using (FærgeContext context = new FærgeContext())
            {
                context.Biler.Add(BilMapper.Map(bilmodel));
                context.SaveChanges();
            }
        }

        /*public static void EditBil(Bil bilModel)
        {
            using (FærgeContext context = new FærgeContext())
            {
                Bil dataBil = context.Biler.Find(bilModel.ID);
                BilMapper.UpdateBil(bilModel, dataBil);

                context.SaveChanges();
            }
        }*/
    }
}
