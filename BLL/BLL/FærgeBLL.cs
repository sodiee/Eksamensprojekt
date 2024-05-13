using DAL.Repositories;
using DTO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BLL
{
    public class FærgeBLL
    {
        public Færge getFærge(int id)
        {
            if (id < 0) throw new IndexOutOfRangeException();
            return FærgeRepository.GetFærge(id);
        }
        public void AddFærge(Færge færge)
        {
            //valider færge
            FærgeRepository.AddFærge(færge);
        }
        public void EditFærgeEmployee(Færge færge)
        {

        }
    }
}
