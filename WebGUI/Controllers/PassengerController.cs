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
            return View(new Passenger { FerryID = ferryId });
        }

        [HttpPost]
        public ActionResult AddPassenger(int ferryId, Passenger passenger, int carId)
        {

            Car car = carBLL.GetCar(carId);


            if (car.NumberOfPassengers >= 5)
            {
                ModelState.AddModelError("", "Bilen er allerede fuld. Der kan ikke tilføjes flere passagerer.");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var ferry = ferryBLL.GetFerry(ferryId);
                    if (ferry == null)
                    {
                        return HttpNotFound();
                    }

                    ferryBLL.AddPassengerToFerry(ferry, passenger);
                    
                    if (car == null)
                    {
                        return HttpNotFound();
                    }
                    carBLL.AddPassengerToCar(car, passenger);


                    return RedirectToAction("Details", "Ferry", new { id = ferryId });
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "An error occurred while adding the passenger: " + ex.Message);
                }
            }

            var cars = ferryBLL.GetCars(ferryBLL.GetFerry(ferryId));
            ViewBag.Cars = cars;
            ViewBag.Ferry = ferryBLL.GetFerry(ferryId);
            return View(passenger);
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
            if (pToDelete.CarID == null) { return HttpNotFound(); }
            carBLL.RemovePassenger(pToDelete, (int)pToDelete.CarID);
         
            passengerBLL.RemovePassenger(pToDelete);
            return RedirectToAction("Details", "Ferry", new { id = ferryId });
        }
    }
}