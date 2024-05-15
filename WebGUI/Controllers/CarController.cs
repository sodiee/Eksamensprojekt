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
        /*private CarBLL carBLL = new CarBLL();

        // GET: Car/AddPassenger
        [HttpGet]
        public ActionResult AddPassenger()
        {
            // Hent en liste over alle biler for at vise dem i dropdown-listen
            var cars = carBLL.GetAllCars();
            ViewBag.Cars = cars;
            return View();
        }

        // POST: Car/AddPassengerToCar
        [HttpPost]
        public ActionResult AddPassengerToCar(Passenger passenger)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Tilføj passageren til den valgte bil
                    int carID = passenger.CarID; // Hent bilens ID fra formularen
                    Car car = carBLL.GetCar(carID); // Hent bilen fra BLL
                    carBLL.AddPassengerToCar(car, passenger);

                    // Send brugeren tilbage til en passende visning (f.eks. oversigt over biler eller en bekræftelsesside)
                    return RedirectToAction("Index", "Car");
                }
                catch (Exception ex)
                {
                    // Håndter eventuelle fejl, f.eks. ved visning af en fejlmeddelelse
                    ModelState.AddModelError("", "An error occurred while adding the passenger to the car: " + ex.Message);
                }
            }

            // Hvis der opstår en valideringsfejl, vis formularen igen med fejlmeddelelser
            var cars = carBLL.GetAllCars();
            ViewBag.Cars = cars;
            return View("AddPassenger", passenger);
        }*/
    }
}