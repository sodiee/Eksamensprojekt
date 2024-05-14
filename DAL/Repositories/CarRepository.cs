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
