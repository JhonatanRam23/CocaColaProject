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
    public class enc_facturaController : Controller
    {
        private rinconEntities db = new rinconEntities();

        // GET: enc_factura
        public ActionResult Index()
        {
            var enc_factura = db.enc_factura.Include(e => e.cliente1).Include(e => e.usuario1);
            return View(enc_factura.ToList());
        }

        // GET: enc_factura/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            enc_factura enc_factura = db.enc_factura.Find(id);
            if (enc_factura == null)
            {
                return HttpNotFound();
            }
            return View(enc_factura);
        }

        // GET: enc_factura/Create
        public ActionResult Create()
        {
            ViewBag.cliente = new SelectList(db.cliente, "nit", "nombre");
            ViewBag.usuario = new SelectList(db.usuario, "id", "pass");
            return View();
        }

        // POST: enc_factura/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "no_factura,fecha,cliente,total_factura,usuario")] enc_factura enc_factura)
        {
            if (ModelState.IsValid)
            {
                db.enc_factura.Add(enc_factura);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cliente = new SelectList(db.cliente, "nit", "nombre", enc_factura.cliente);
            ViewBag.usuario = new SelectList(db.usuario, "id", "pass", enc_factura.usuario);
            return View(enc_factura);
        }

        // GET: enc_factura/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            enc_factura enc_factura = db.enc_factura.Find(id);
            if (enc_factura == null)
            {
                return HttpNotFound();
            }
            ViewBag.cliente = new SelectList(db.cliente, "nit", "nombre", enc_factura.cliente);
            ViewBag.usuario = new SelectList(db.usuario, "id", "pass", enc_factura.usuario);
            return View(enc_factura);
        }

        // POST: enc_factura/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "no_factura,fecha,cliente,total_factura,usuario")] enc_factura enc_factura)
        {
            if (ModelState.IsValid)
            {
                db.Entry(enc_factura).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cliente = new SelectList(db.cliente, "nit", "nombre", enc_factura.cliente);
            ViewBag.usuario = new SelectList(db.usuario, "id", "pass", enc_factura.usuario);
            return View(enc_factura);
        }

        // GET: enc_factura/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            enc_factura enc_factura = db.enc_factura.Find(id);
            if (enc_factura == null)
            {
                return HttpNotFound();
            }
            return View(enc_factura);
        }

        // POST: enc_factura/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            enc_factura enc_factura = db.enc_factura.Find(id);
            db.enc_factura.Remove(enc_factura);
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
