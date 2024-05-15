using DAL.Repositories;
using DTO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BLL
{
    public class PassengerBLL
    {
        public Passenger GetPassenger(int id)
        {
            if (id < 0) throw new IndexOutOfRangeException();
            return PassengerRepository.GetPassenger(id);
        }
        public void AddPassenger(Passenger passenger)
        {
            //valider employee
            PassengerRepository.AddPassenger(passenger);
        }
        public void UpdatePassenger(Passenger passenger)
        {
            PassengerRepository.UpdatePassenger(passenger);
        }

        public void RemovePassenger(Passenger passenger)
        {
            PassengerRepository.RemovePassenger(passenger);
        }
    }
}
