using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VenadoProject.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult NoAutorizado()
        {            
            return View();
        }
        
        
        
    }
}