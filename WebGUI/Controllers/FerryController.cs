using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DTO.Model;
using BLL.BLL;

namespace WebGUI.Controllers
{
    public class FerryController : Controller
    {
        public FerryBLL ferryBLL = new FerryBLL();

        // GET: Ferry
        public ActionResult Index()
        {
            ICollection<Ferry> ferries = ferryBLL.GetFerryList();
            return View(ferries);
        }

        public ActionResult Details(int id)
        {
            var ferry = ferryBLL.GetFerry(id);
            var passengers = ferryBLL.GetPassengers(ferry);
            if (ferry == null)
            {
                return HttpNotFound();
            }
            ViewBag.Passengers = passengers;
            return View(ferry);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var ferry = ferryBLL.GetFerry(id);
            if (ferry == null)
            {
                return HttpNotFound();
            }
            return View(ferry);
        }
        [HttpPost]
        public ActionResult Edit(Ferry ferry)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ferryBLL.UpdateFerry(ferry);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "An error occurred while updating the ferry: " + ex.Message);
                }
            }
            return View(ferry);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var ferry = ferryBLL.GetFerry(id);
            if (ferry == null)
            {
                return HttpNotFound();
            }
            return View(ferry);
        }

        [HttpPost]
        public ActionResult DeleteConfirmed(int id)
        {
            ferryBLL.RemoveFerry(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult AddNewPassenger(int id, Passenger passenger)
        {
            try
            {
                var ferry = ferryBLL.GetFerry(id);
                if (ferry == null)
                {
                    return HttpNotFound();
                }
                ferryBLL.AddPassengerToFerry(ferry, passenger);

                return RedirectToAction("Details", new { id = id });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "An error occurred while adding the passenger: " + ex.Message);
                return View("Details", id);
            }
        }

        [HttpPost]
        public ActionResult AddNewCar(int id, Car car, Passenger passenger)
        {
            try
            {
                var ferry = ferryBLL.GetFerry(id);
                if (ferry == null)
                {
                    return HttpNotFound();
                }
                ferryBLL.AddPassengerToFerry(ferry, passenger);

                return RedirectToAction("Details", new { id = id });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "An error occurred while adding the passenger: " + ex.Message);
                return View("Details", id);
            }
        }

        public ActionResult Return(int id)
        {
            return View("Details", id);
        }
    }
}