using BLL.BLL;
using DTO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebAPI.Controllers
{
    public class CarController : ApiController
    {
        FerryBLL ferryBLL = new FerryBLL();
        CarBLL carBLL = new CarBLL();

        [HttpGet]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public Car GetCar(int id)
        {
            return carBLL.GetCar(id);
        }

        [HttpGet]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public List<Car> GetAllCarsOnFerry(int id)
        {
            Ferry ferry = ferryBLL.GetFerry(id);
            return ferryBLL.GetCars(ferry);
        }

        [HttpPost]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public Car AddCar(int id,[FromUri] Car newCar)
        {
            Ferry ferry = ferryBLL.GetFerry(id);
            ferryBLL.AddCarToFerry(ferry, newCar);

            return newCar;
        }

        [HttpDelete]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult DeleteCar(int id)
        {
            Car car = carBLL.GetCar(id);
            carBLL.RemoveCar(car);

            return Ok();
        }

        [HttpPut]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public Car UpdateCar(int id, [FromUri] Car updatedCar)
        {
            updatedCar.CarID = id;

            carBLL.UpdateCar(updatedCar);

            return updatedCar;
        }
    }
}
