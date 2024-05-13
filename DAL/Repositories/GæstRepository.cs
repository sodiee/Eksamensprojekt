using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    internal class GæstRepository
    {
        public static BilModel GetBilModel(int id)
        {
            using (BilContext context = new BilContext())
            {
                return BilMapper.Map(context.Biler.Find(id));
            }
        }

        public static void AddBilModel(BilModel bilmodel)
        {
            using (BilContext context = new BilContext())
            {
                context.Biler.Add(BilMapper.Map(bilmodel));
                context.SaveChanges();
            }
        }

        public static void EditBilModel(BilModel bilModel)
        {
            using (BilContext context = new BilContext())
            {
                Model.BilModel dataBil = context.Biler.Find(bilModel.ID);
                BilMapper.UpdateBil(bilModel, dataBil);

                context.SaveChanges();
            }
        }
    }
}
