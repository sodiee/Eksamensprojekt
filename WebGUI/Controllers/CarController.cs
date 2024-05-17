using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.BLL;
using DTO.Model;

namespace WebGUI.Controllers
{
    public class CarController : Controller
    {
        FerryBLL ferryBLL = new FerryBLL();
        CarBLL carBLL = new CarBLL();

        [HttpGet]
        public ActionResult AddCar(int ferryId)
        {
            var ferry = ferryBLL.GetFerry(ferryId);
            if (ferry == null)
            {
                return HttpNotFound();
            }

            ViewBag.Ferry = ferry;
            return View(new Car { FerryID = ferryId });
        }

        [HttpPost]
        public ActionResult AddCar(int ferryId, Car car)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var ferry = ferryBLL.GetFerry(ferryId);
                    if (ferry == null)
                    {
                        return HttpNotFound();
                    }

                    // Tilføj bilen til færgen
                    ferryBLL.AddCarToFerry(ferry, car);

                    return RedirectToAction("Details", "Ferry", new { id = ferryId });
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "An error occurred while adding the car: " + ex.Message);
                }
            }

            var ferryFallback = ferryBLL.GetFerry(ferryId);
            ViewBag.Ferry = ferryFallback;
            return View(car);
        }

        public ActionResult Details(int id)
        {
            var car = carBLL.GetCar(id);
            if (car == null)
            {
                return HttpNotFound();
            }

            // Hent passagererne for bilen
            var passengers = carBLL.GetPassengersInCar(car);

            // Gem passagererne i en ViewBag-variabel
            ViewBag.Passengers = passengers;

            return View(car);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var car = carBLL.GetCar(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }
        [HttpPost]
        public ActionResult Edit(Car car)
        {
            ModelState.Clear();
            if (ModelState.IsValid)
            {
                try
                {
                    carBLL.UpdateCar(car);
                    return RedirectToAction("Details", new { id = car.CarID });
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "An error occurred while updating the ferry: " + ex.Message);
                }
            }
            return View(car);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var car = carBLL.GetCar(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        [HttpPost]
        public ActionResult DeleteConfirmed(int id, int ferryId)
        {
            var cToDelete = carBLL.GetCar(id);
            carBLL.RemoveCar(cToDelete);
            return RedirectToAction("Details", "Ferry", new { id = ferryId });
        }
    }
}