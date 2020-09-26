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
    public class detalle_facturaController : Controller
    {
        private rinconEntities db = new rinconEntities();

        // GET: detalle_factura
        public ActionResult Index()
        {
            var detalle_factura = db.detalle_factura.Include(d => d.enc_factura).Include(d => d.producto1);
            return View(detalle_factura.ToList());
        }

        // GET: detalle_factura/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            detalle_factura detalle_factura = db.detalle_factura.Find(id);
            if (detalle_factura == null)
            {
                return HttpNotFound();
            }
            return View(detalle_factura);
        }

        // GET: detalle_factura/Create
        public ActionResult Create()
        {
            ViewBag.factura = new SelectList(db.enc_factura, "no_factura", "cliente");
            ViewBag.producto = new SelectList(db.producto, "id", "nombre");
            return View();
        }

        // POST: detalle_factura/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "factura,cantidad,producto,precio,total")] detalle_factura detalle_factura)
        {
            if (ModelState.IsValid)
            {
                db.detalle_factura.Add(detalle_factura);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.factura = new SelectList(db.enc_factura, "no_factura", "cliente", detalle_factura.factura);
            ViewBag.producto = new SelectList(db.producto, "id", "nombre", detalle_factura.producto);
            return View(detalle_factura);
        }

        // GET: detalle_factura/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            detalle_factura detalle_factura = db.detalle_factura.Find(id);
            if (detalle_factura == null)
            {
                return HttpNotFound();
            }
            ViewBag.factura = new SelectList(db.enc_factura, "no_factura", "cliente", detalle_factura.factura);
            ViewBag.producto = new SelectList(db.producto, "id", "nombre", detalle_factura.producto);
            return View(detalle_factura);
        }

        // POST: detalle_factura/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "factura,cantidad,producto,precio,total")] detalle_factura detalle_factura)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detalle_factura).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.factura = new SelectList(db.enc_factura, "no_factura", "cliente", detalle_factura.factura);
            ViewBag.producto = new SelectList(db.producto, "id", "nombre", detalle_factura.producto);
            return View(detalle_factura);
        }

        // GET: detalle_factura/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            detalle_factura detalle_factura = db.detalle_factura.Find(id);
            if (detalle_factura == null)
            {
                return HttpNotFound();
            }
            return View(detalle_factura);
        }

        // POST: detalle_factura/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            detalle_factura detalle_factura = db.detalle_factura.Find(id);
            db.detalle_factura.Remove(detalle_factura);
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
