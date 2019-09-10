using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using proyecto8.Models;

namespace proyecto8.Controllers
{
    public class estado_productoController : Controller
    {
        private patagones1Entities db = new patagones1Entities();

        // GET: estado_producto
        public ActionResult Index()
        {
            return View(db.estado_producto.ToList());
        }

        // GET: estado_producto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            estado_producto estado_producto = db.estado_producto.Find(id);
            if (estado_producto == null)
            {
                return HttpNotFound();
            }
            return View(estado_producto);
        }

        // GET: estado_producto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: estado_producto/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_estado_producto,tipo_estado")] estado_producto estado_producto)
        {
            if (ModelState.IsValid)
            {
                db.estado_producto.Add(estado_producto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(estado_producto);
        }

        // GET: estado_producto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            estado_producto estado_producto = db.estado_producto.Find(id);
            if (estado_producto == null)
            {
                return HttpNotFound();
            }
            return View(estado_producto);
        }

        // POST: estado_producto/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_estado_producto,tipo_estado")] estado_producto estado_producto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estado_producto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(estado_producto);
        }

        // GET: estado_producto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            estado_producto estado_producto = db.estado_producto.Find(id);
            if (estado_producto == null)
            {
                return HttpNotFound();
            }
            return View(estado_producto);
        }

        // POST: estado_producto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            estado_producto estado_producto = db.estado_producto.Find(id);
            db.estado_producto.Remove(estado_producto);
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
