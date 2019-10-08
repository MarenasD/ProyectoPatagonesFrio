using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Patagones;

namespace Patagones.Controllers
{
    public class producto_procesoController : Controller
    {
        private PatagonesEntities db = new PatagonesEntities();

        // GET: producto_proceso
        public ActionResult Index()
        {
            var producto_proceso = db.producto_proceso.Include(p => p.producto);
            return View(producto_proceso.ToList());
        }

        // GET: producto_proceso/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            producto_proceso producto_proceso = db.producto_proceso.Find(id);
            if (producto_proceso == null)
            {
                return HttpNotFound();
            }
            return View(producto_proceso);
        }

        // GET: producto_proceso/Create
        public ActionResult Create()
        {
            ViewBag.FkProducto = new SelectList(db.producto, "IdProducto", "Nombre");
            return View();
        }

        // POST: producto_proceso/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CantidadProceso,FechaProceso,FkProducto")] producto_proceso producto_proceso)
        {
            if (ModelState.IsValid)
            {
                db.producto_proceso.Add(producto_proceso);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FkProducto = new SelectList(db.producto, "IdProducto", "Nombre", producto_proceso.FkProducto);
            return View(producto_proceso);
        }

        // GET: producto_proceso/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            producto_proceso producto_proceso = db.producto_proceso.Find(id);
            if (producto_proceso == null)
            {
                return HttpNotFound();
            }
            ViewBag.FkProducto = new SelectList(db.producto, "IdProducto", "Nombre", producto_proceso.FkProducto);
            return View(producto_proceso);
        }

        // POST: producto_proceso/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CantidadProceso,FechaProceso,FkProducto")] producto_proceso producto_proceso)
        {
            if (ModelState.IsValid)
            {
                db.Entry(producto_proceso).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FkProducto = new SelectList(db.producto, "IdProducto", "Nombre", producto_proceso.FkProducto);
            return View(producto_proceso);
        }

        // GET: producto_proceso/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            producto_proceso producto_proceso = db.producto_proceso.Find(id);
            if (producto_proceso == null)
            {
                return HttpNotFound();
            }
            return View(producto_proceso);
        }

        // POST: producto_proceso/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            producto_proceso producto_proceso = db.producto_proceso.Find(id);
            db.producto_proceso.Remove(producto_proceso);
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
