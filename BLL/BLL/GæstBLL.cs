using DAL.Repositories;
using DTO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BLL
{
    public class GæstBLL
    {
        public Gæst getGæst(int id)
        {
            if (id < 0) throw new IndexOutOfRangeException();
            return GæstRepository.GetGæst(id);
        }
        public void AddGæst(Gæst gæst)
        {
            //valider employee
            GæstRepository.AddGæst(gæst);
        }
        public void EditGæst(Gæst gæst)
        {

        }
    }
}
