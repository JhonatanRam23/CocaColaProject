using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VenadoProject.Models;
using VenadoProject.Models.ViewModels;

namespace VenadoProject.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            List<ListCliente> lista;
            using (rinconEntities db = new rinconEntities())
            {
                lista = (from d in db.cliente
                         select new ListCliente
                         {
                             nit = d.nit,
                             nombre = d.nombre,
                             direccion = d.direccion
                         }).ToList();
            }
                return View(lista);
        }

        public ActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(ListCliente nuevo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (rinconEntities db= new rinconEntities())
                    {
                        var oCliente = new cliente();
                        oCliente.nit = nuevo.nit;
                        oCliente.nombre = nuevo.nombre;
                        oCliente.direccion = nuevo.direccion;
                        db.cliente.Add(oCliente);
                        db.SaveChanges();
                    }
                    return Redirect("~/Cliente/");
                }
                return View(nuevo);
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public ActionResult Editar(string nit)
        {

            ListCliente nuevo = new ListCliente();
            ViewBag.nit = "Editanto Cliente con Nit "+nit;

            using (rinconEntities db = new rinconEntities())
            {
                var oCliente = db.cliente.Find(nit);
                nuevo.nit = oCliente.nit;
                nuevo.nombre = oCliente.nombre;
                nuevo.direccion = oCliente.direccion;
            }

                return View(nuevo);
        }

        [HttpPost]
        public ActionResult Editar(ListCliente nuevo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (rinconEntities db = new rinconEntities())
                    {
                        var oCliente = db.cliente.Find(nuevo.nit);                        
                        oCliente.nombre = nuevo.nombre;
                        oCliente.direccion = nuevo.direccion;
                        db.Entry(oCliente).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    return Redirect("~/Cliente/");
                }
                return View(nuevo);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}