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
        CarBLL carBLL = new CarBLL();

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
            var cars = ferryBLL.GetCars(ferry);
            if (ferry == null)
            {
                return HttpNotFound();
            }
            ViewBag.Passengers = passengers;
            ViewBag.Cars = cars;
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

        public ActionResult AddPassenger(int id)
        {
            var ferry = ferryBLL.GetFerry(id);
            if (ferry == null)
            {
                return HttpNotFound();
            }
            return View(ferry);
        }

        [HttpPost]
        public ActionResult AddNewPassenger(int id, Passenger passenger, int carId)
        {
            try
            {
                var ferry = ferryBLL.GetFerry(id);
                if (ferry == null)
                {
                    return HttpNotFound();
                }

                ferryBLL.AddPassengerToFerry(ferry, passenger);

                var car = carBLL.GetCar(carId);
                if (car == null)
                {
                    return HttpNotFound();
                }

                //carBLL.AddPassengerToCar(car, passenger);

                return RedirectToAction("Details", new { id = id });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "An error occurred while adding the passenger to the ferry and car: " + ex.Message);
                return View("Details", id);
            }
        }


        public ActionResult AddCar(int id)
        {
            var ferry = ferryBLL.GetFerry(id);
            if (ferry == null)
            {
                return HttpNotFound();
            }
            return View(ferry);
        }

        [HttpPost]
        public ActionResult AddNewCar(int id, Car car)
        {
            try
            {
                var ferry = ferryBLL.GetFerry(id);
                if (ferry == null)
                {
                    return HttpNotFound();
                }
                ferryBLL.AddCarToFerry(ferry, car);

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