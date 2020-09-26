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
    public class stocksController : Controller
    {
        private rinconEntities db = new rinconEntities();

        // GET: stocks
        public ActionResult Index()
        {
            var stock = db.stock.Include(s => s.producto1);
            return View(stock.ToList());
        }

        // GET: stocks/Details/5
        public ActionResult Details(int? id, DateTime? fecha,float? precio)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            stock stock = new stock();

            var ostock = (from d in db.stock
                         where d.producto == id && d.precio == precio
                         select d).FirstOrDefault();
            if (ostock != null)
            {
                stock.producto = ostock.producto;
                stock.fecha_ingreso = ostock.fecha_ingreso;
                stock.precio = ostock.precio;
                stock.cantidad = ostock.cantidad;
            }
                
            if (stock == null)
            {
                return HttpNotFound();
            }
            return View(stock);
        }

        // GET: stocks/Create
        public ActionResult Create()
        {
            ViewBag.producto = new SelectList(db.producto, "id", "nombre");
            return View();
        }

        // POST: stocks/Create  
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "producto,fecha_ingreso,precio,cantidad")] stock stock)
        {
            if (ModelState.IsValid)
            {
                db.stock.Add(stock);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.producto = new SelectList(db.producto, "id", "nombre", stock.producto);
            return View(stock);
        }

        // GET: stocks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            stock stock = db.stock.Find(id);
            if (stock == null)
            {
                return HttpNotFound();
            }
            ViewBag.producto = new SelectList(db.producto, "id", "nombre", stock.producto);
            return View(stock);
        }

        // POST: stocks/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "producto,fecha_ingreso,precio,cantidad")] stock stock)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stock).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.producto = new SelectList(db.producto, "id", "nombre", stock.producto);
            return View(stock);
        }

        // GET: stocks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            stock stock = db.stock.Find(id);
            if (stock == null)
            {
                return HttpNotFound();
            }
            return View(stock);
        }

        // POST: stocks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            stock stock = db.stock.Find(id);
            db.stock.Remove(stock);
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
