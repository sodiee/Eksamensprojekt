using BLL.BLL;
using DTO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebAPI.Controllers
{
    public class FerryController : ApiController
    {
        FerryBLL ferryBLL = new FerryBLL();

        [HttpGet]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public Ferry GetFerry(int id)
        {
            //return Ok(ferryBLL.GetFerry(id));
            return ferryBLL.GetFerry(id);
        }

        [HttpGet]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public List<Ferry> GetAllFerries()
        {
            return ferryBLL.GetFerryList();
        }

        [HttpPost]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public void AddFerry(string name, int maxNumberOfPassengers, int maxNumberOfCars, int pricePassenger, int priceCars)
        {
            Ferry newFerry = new Ferry(name, maxNumberOfPassengers, maxNumberOfCars, pricePassenger, priceCars);
            ferryBLL.AddFerry(newFerry);
        }
    }
}
