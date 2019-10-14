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
    public class producto_glaseadoController : Controller
    {
        private PatagonesFEntities db = new PatagonesFEntities();

        // GET: producto_glaseado
        public ActionResult Index()
        {
            var producto_glaseado = db.producto_glaseado.Include(p => p.estado_glaseado).Include(p => p.producto);
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
            ViewBag.fk_id_estado_glaseado = new SelectList(db.estado_glaseado, "id_estado_glaseado", "tipo_estado");
            ViewBag.fk_id_producto_proceso = new SelectList(db.producto, "id_producto", "producto1");
            return View();
        }

        // POST: producto_glaseado/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_producto_glaseado,cantidad_glaseada,fecha_glaseada,fk_id_producto_proceso,fk_id_estado_glaseado")] producto_glaseado producto_glaseado)
        {
            if (ModelState.IsValid)
            {
                db.producto_glaseado.Add(producto_glaseado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.fk_id_estado_glaseado = new SelectList(db.estado_glaseado, "id_estado_glaseado", "tipo_estado", producto_glaseado.fk_id_estado_glaseado);
            ViewBag.fk_id_producto_proceso = new SelectList(db.producto, "id_producto", "producto1", producto_glaseado.fk_id_producto_proceso);
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
            ViewBag.fk_id_estado_glaseado = new SelectList(db.estado_glaseado, "id_estado_glaseado", "tipo_estado", producto_glaseado.fk_id_estado_glaseado);
            ViewBag.fk_id_producto_proceso = new SelectList(db.producto, "id_producto", "producto1", producto_glaseado.fk_id_producto_proceso);
            return View(producto_glaseado);
        }

        // POST: producto_glaseado/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_producto_glaseado,cantidad_glaseada,fecha_glaseada,fk_id_producto_proceso,fk_id_estado_glaseado")] producto_glaseado producto_glaseado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(producto_glaseado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fk_id_estado_glaseado = new SelectList(db.estado_glaseado, "id_estado_glaseado", "tipo_estado", producto_glaseado.fk_id_estado_glaseado);
            ViewBag.fk_id_producto_proceso = new SelectList(db.producto, "id_producto", "producto1", producto_glaseado.fk_id_producto_proceso);
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
