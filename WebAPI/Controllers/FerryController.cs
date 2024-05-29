using BLL.BLL;
using DTO.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
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
        public Ferry AddFerry(Ferry newFerry)
        {
            ferryBLL.AddFerry(newFerry);

            return newFerry;
        }

        [HttpDelete]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult DeleteFerry(int id)
        {
            ferryBLL.RemoveFerry(id);

            return Ok();
        }

        [HttpPut]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public Ferry UpdateFerry(int id, Ferry updatedFerry)
        {
            updatedFerry.FerryID = id;

            ferryBLL.UpdateFerry(updatedFerry);

            return updatedFerry;
        }
    }
}
