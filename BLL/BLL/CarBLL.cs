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
    public class CarBLL
    {
        public Car GetCar(int id)
        {
            if (id < 0) throw new IndexOutOfRangeException();
            return CarRepository.GetCar(id);
        }
        public void AddCar(Car car)
        {
            //valider car
            CarRepository.AddCar(car);
        }
        public void UpdateCar(Car car)
        {
            CarRepository.UpdateCar(car);
        }

        public void AddPassengerToCar(Car car, Passenger passenger)
        {
            CarRepository.AddPassengerToCar(car, passenger);
        }

        public List<Passenger> GetPassengersInCar(Car car)
        {
            return CarRepository.GetPassengers(car);
        }

        public void RemoveCar(Car selectedCar)
        {
            CarRepository.RemoveCar(selectedCar);
        }
    }
}
