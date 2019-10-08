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
    public class producto_glaseadoController : Controller
    {
        private PatagonesEntities db = new PatagonesEntities();

        // GET: producto_glaseado
        public ActionResult Index()
        {
            var producto_glaseado = db.producto_glaseado.Include(p => p.producto);
            return View(producto_glaseado.ToList());
        }

        // GET: producto_glaseado/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            producto_glaseado producto_glaseado = db.producto_glaseado.Find(id);
            if (producto_glaseado == null)
            {
                return HttpNotFound();
            }
            return View(producto_glaseado);
        }

        // GET: producto_glaseado/Create
        public ActionResult Create()
        {
            ViewBag.FkProducto = new SelectList(db.producto, "IdProducto", "Nombre");
            return View();
        }

        // POST: producto_glaseado/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CantidadGlaseado,FechaGlaseado,FkProducto")] producto_glaseado producto_glaseado)
        {
            if (ModelState.IsValid)
            {
                db.producto_glaseado.Add(producto_glaseado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FkProducto = new SelectList(db.producto, "IdProducto", "Nombre", producto_glaseado.FkProducto);
            return View(producto_glaseado);
        }

        // GET: producto_glaseado/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            producto_glaseado producto_glaseado = db.producto_glaseado.Find(id);
            if (producto_glaseado == null)
            {
                return HttpNotFound();
            }
            ViewBag.FkProducto = new SelectList(db.producto, "IdProducto", "Nombre", producto_glaseado.FkProducto);
            return View(producto_glaseado);
        }

        // POST: producto_glaseado/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CantidadGlaseado,FechaGlaseado,FkProducto")] producto_glaseado producto_glaseado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(producto_glaseado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FkProducto = new SelectList(db.producto, "IdProducto", "Nombre", producto_glaseado.FkProducto);
            return View(producto_glaseado);
        }

        // GET: producto_glaseado/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            producto_glaseado producto_glaseado = db.producto_glaseado.Find(id);
            if (producto_glaseado == null)
            {
                return HttpNotFound();
            }
            return View(producto_glaseado);
        }

        // POST: producto_glaseado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            producto_glaseado producto_glaseado = db.producto_glaseado.Find(id);
            db.producto_glaseado.Remove(producto_glaseado);
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
