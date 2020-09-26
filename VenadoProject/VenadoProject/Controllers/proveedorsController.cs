using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VenadoProject.Models;

namespace VenadoProject.Controllers
{
    public class proveedorsController : Controller
    {
        private rinconEntities db = new rinconEntities();

        // GET: proveedors
        public ActionResult Index()
        {
            var proveedor = db.proveedor.Include(p => p.clase_producto);
            return View(proveedor.ToList());
        }

        // GET: proveedors/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            proveedor proveedor = db.proveedor.Find(id);
            if (proveedor == null)
            {
                return HttpNotFound();
            }
            return View(proveedor);
        }

        // GET: proveedors/Create
        public ActionResult Create()
        {
            ViewBag.clase = new SelectList(db.clase_producto, "id", "nombre");
            return View();
        }

        // POST: proveedors/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "nit,nombre,direccion,clase")] proveedor proveedor)
        {
            if (ModelState.IsValid)
            {
                db.proveedor.Add(proveedor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.clase = new SelectList(db.clase_producto, "id", "nombre", proveedor.clase);
            return View(proveedor);
        }

        // GET: proveedors/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            proveedor proveedor = db.proveedor.Find(id);
            if (proveedor == null)
            {
                return HttpNotFound();
            }
            ViewBag.clase = new SelectList(db.clase_producto, "id", "nombre", proveedor.clase);
            return View(proveedor);
        }

        // POST: proveedors/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "nit,nombre,direccion,clase")] proveedor proveedor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(proveedor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.clase = new SelectList(db.clase_producto, "id", "nombre", proveedor.clase);
            return View(proveedor);
        }

        // GET: proveedors/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            proveedor proveedor = db.proveedor.Find(id);
            if (proveedor == null)
            {
                return HttpNotFound();
            }
            return View(proveedor);
        }

        // POST: proveedors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            proveedor proveedor = db.proveedor.Find(id);
            db.proveedor.Remove(proveedor);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
