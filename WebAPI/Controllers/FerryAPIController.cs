using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL.BLL;
using DTO.Model;

namespace WebAPI.Controllers
{
    public class FerryAPIController : ApiController
    {
        FerryBLL ferryBLL = new FerryBLL();
        //GET: All ferries
        [HttpGet]
        public IEnumerable<Ferry> GetFerries()
        {
            return ferryBLL.GetFerryList();
        }

        [HttpGet]
        public Ferry GetFerry(int id)
        {
            return ferryBLL.GetFerry(id);
        }

        [HttpPut]
        public Ferry UpdateFerry(Ferry ferry)
        {
            ferryBLL.UpdateFerry(ferry);
            return ferry;
        }

        [HttpPost]
        public Ferry AddFerry(Ferry ferry)
        {
            ferryBLL.AddFerry(ferry);
            return ferry;
        }

        [HttpDelete]
        public Ferry DeleteFerry(int id)
        {
            return ferryBLL.RemoveFerry(id);
        }

        [HttpDelete]
        public void DeleteAllFerries()
        {
            ferryBLL.RemoveAllFerries();
        }
    }
}
