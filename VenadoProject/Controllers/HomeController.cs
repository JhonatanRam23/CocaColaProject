using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VenadoProject.Filters;

namespace VenadoProject.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "El Tucan Web.";

            return View();
        }

        [AuthorizeUser(idrol:1)]
        public ActionResult Contact()
        {
            ViewBag.Message = "Contactenos.";

            return View();
        }
    }
}