using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DTO.Model;
using BLL.BLL;
using System.Web.Http.Cors;

namespace WebAPI.Controllers
{
    public class PassengerController : ApiController
    {
        FerryBLL ferryBLL = new FerryBLL();
        PassengerBLL passengerBLL = new PassengerBLL();

        [HttpGet]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public Passenger GetPassenger(int id)
        {
            return passengerBLL.GetPassenger(id);
        }

        [HttpGet]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public List<Passenger> GetAllPassengersOnFerry(int id)
        {
            Ferry ferry = ferryBLL.GetFerry(id);
            return ferryBLL.GetPassengers(ferry);
        }

        [HttpPost]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public Passenger AddPassenger(int id, [FromUri] Passenger newPassenger)
        {
            Ferry ferry = ferryBLL.GetFerry(id);
            ferryBLL.AddPassengerToFerry(ferry, newPassenger);

            return newPassenger;
        }

        [HttpDelete]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult DeletePassenger(int id)
        {
            Passenger passenger = passengerBLL.GetPassenger(id);
            passengerBLL.RemovePassenger(passenger);

            return Ok();
        }

        [HttpPut]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public Passenger UpdatePassenger(int id, [FromUri] Passenger updatedPassenger)
        {
            updatedPassenger.CarID = id;

            passengerBLL.UpdatePassenger(updatedPassenger);

            return updatedPassenger;
        }
    }
}
