using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DTO.Model;
using BLL.BLL;

namespace WebGUI.Controllers
{
    public class PassengerController : Controller
    {
        FerryBLL ferryBLL = new FerryBLL();
        CarBLL carBLL = new CarBLL();
        PassengerBLL passengerBLL = new PassengerBLL();

        [HttpGet]
        public ActionResult AddPassenger(int ferryId)
        {
            var ferry = ferryBLL.GetFerry(ferryId);
            if (ferry == null)
            {
                return HttpNotFound();
            }

            var cars = ferryBLL.GetCars(ferry);

            ViewBag.Ferry = ferry;
            ViewBag.Cars = cars;
            return View();
        }

        [HttpPost]
        public ActionResult AddPassenger(int ferryId, Passenger passenger, int carId)
        {
            try
            {
                ModelState.Clear();
                /*if (ModelState.IsValid)
                {
                }*/
                    var ferry = ferryBLL.GetFerry(ferryId);
                if (ferry == null)
                {
                    return HttpNotFound();
                }

                // Tilføj passager til færgen
                ferryBLL.AddPassengerToFerry(ferry, passenger);

                // Hent bilen fra id'et
                var car = carBLL.GetCar(carId);
                if (car == null)
                {
                    return HttpNotFound();
                }

                // Tilføj passageren til bilen
                //carBLL.AddPassengerToCar(car, passenger);
                return RedirectToAction("Details", "Ferry", new { id = ferryId });

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "An error occurred while adding the passenger: " + ex.Message);
                return View(passenger);
            }
        }

        public ActionResult Details(int id)
        {
            var passenger = passengerBLL.GetPassenger(id);
            if (passenger == null)
            {
                return HttpNotFound();
            }
            return View("Details",passenger);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var passenger = passengerBLL.GetPassenger(id);
            if (passenger == null)
            {
                return HttpNotFound();
            }
            return View(passenger);
        }
        [HttpPost]
        public ActionResult Edit(Passenger passenger)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    passengerBLL.UpdatePassenger(passenger);
                    return RedirectToAction("Details", new { id = passenger.PassengerID });
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "An error occurred while updating the ferry: " + ex.Message);
                }
            }
            return View(passenger);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var passenger = passengerBLL.GetPassenger(id);
            if (passenger == null)
            {
                return HttpNotFound();
            }
            return View(passenger);
        }

        [HttpPost]
        public ActionResult DeleteConfirmed(int id, int ferryId)
        {
            var pToDelete = passengerBLL.GetPassenger(id);
            passengerBLL.RemovePassenger(pToDelete);
            return RedirectToAction("Details", "Ferry", new { id = ferryId });
        }
    }
}