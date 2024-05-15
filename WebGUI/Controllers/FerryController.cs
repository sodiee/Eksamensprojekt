using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebGUI.Controllers
{
    public class FerryController : Controller
    {
        // GET: Ferry
        public ActionResult Index()
        {
            return View();
        }
    }
}