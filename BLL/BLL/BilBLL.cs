using DTO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DAL.Repositories;

namespace BLL.BLL
{
    public class BilBLL
    {
        public Bil getBil(int id)
        {
            if (id < 0) throw new IndexOutOfRangeException();
            return BilRepository.GetBil(id);
        }
        public void AddBil(Bil bil)
        {
            //valider employee
            BilRepository.AddBil(bil);
        }
        public void EditEmployee(Bil bil)
        {

        }
    }
}
