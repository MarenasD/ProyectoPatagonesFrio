using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PatagonesF;

namespace PatagonesF.Controllers
{
    public class producto_procesoController : Controller
    {
        private PatagonesFEntities db = new PatagonesFEntities();

        // GET: producto_proceso
        public ActionResult Index()
        {
            var producto_proceso = db.producto_proceso.Include(p => p.estado_producto).Include(p => p.producto);
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
            ViewBag.fk_estado_producto = new SelectList(db.estado_producto, "id_estado_producto", "tipo_estado");
            ViewBag.fk_id_producto = new SelectList(db.producto, "id_producto", "producto1");
            return View();
        }

        // POST: producto_proceso/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_producto_proceso,cantidad_procesada,fecha_proceso,fk_id_producto,fk_estado_producto")] producto_proceso producto_proceso)
        {
            if (ModelState.IsValid)
            {
                db.producto_proceso.Add(producto_proceso);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.fk_estado_producto = new SelectList(db.estado_producto, "id_estado_producto", "tipo_estado", producto_proceso.fk_estado_producto);
            ViewBag.fk_id_producto = new SelectList(db.producto, "id_producto", "producto1", producto_proceso.fk_id_producto);
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
            ViewBag.fk_estado_producto = new SelectList(db.estado_producto, "id_estado_producto", "tipo_estado", producto_proceso.fk_estado_producto);
            ViewBag.fk_id_producto = new SelectList(db.producto, "id_producto", "producto1", producto_proceso.fk_id_producto);
            return View(producto_proceso);
        }

        // POST: producto_proceso/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_producto_proceso,cantidad_procesada,fecha_proceso,fk_id_producto,fk_estado_producto")] producto_proceso producto_proceso)
        {
            if (ModelState.IsValid)
            {
                db.Entry(producto_proceso).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fk_estado_producto = new SelectList(db.estado_producto, "id_estado_producto", "tipo_estado", producto_proceso.fk_estado_producto);
            ViewBag.fk_id_producto = new SelectList(db.producto, "id_producto", "producto1", producto_proceso.fk_id_producto);
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
