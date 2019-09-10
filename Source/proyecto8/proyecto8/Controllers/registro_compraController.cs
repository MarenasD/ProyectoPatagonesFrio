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
    public class registro_compraController : Controller
    {
        private patagones1Entities db = new patagones1Entities();

        // GET: registro_compra
        public ActionResult Index()
        {
            var registro_compra = db.registro_compra.Include(r => r.personal).Include(r => r.producto);
            return View(registro_compra.ToList());
        }

        // GET: registro_compra/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            registro_compra registro_compra = db.registro_compra.Find(id);
            if (registro_compra == null)
            {
                return HttpNotFound();
            }
            return View(registro_compra);
        }

        // GET: registro_compra/Create
        public ActionResult Create()
        {
            ViewBag.fk_id_personal = new SelectList(db.personal, "rut_personal", "nombre_completo");
            ViewBag.fk_id_producto = new SelectList(db.producto, "id_producto", "producto1");
            return View();
        }

        // POST: registro_compra/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_registro_compra,cantidad_comprada,fecha_comprada,n_factura,lote,tipo_documento,fk_id_producto,fk_id_personal")] registro_compra registro_compra)
        {
            if (ModelState.IsValid)
            {
                db.registro_compra.Add(registro_compra);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.fk_id_personal = new SelectList(db.personal, "rut_personal", "nombre_completo", registro_compra.fk_id_personal);
            ViewBag.fk_id_producto = new SelectList(db.producto, "id_producto", "producto1", registro_compra.fk_id_producto);
            return View(registro_compra);
        }

        // GET: registro_compra/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            registro_compra registro_compra = db.registro_compra.Find(id);
            if (registro_compra == null)
            {
                return HttpNotFound();
            }
            ViewBag.fk_id_personal = new SelectList(db.personal, "rut_personal", "nombre_completo", registro_compra.fk_id_personal);
            ViewBag.fk_id_producto = new SelectList(db.producto, "id_producto", "producto1", registro_compra.fk_id_producto);
            return View(registro_compra);
        }

        // POST: registro_compra/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_registro_compra,cantidad_comprada,fecha_comprada,n_factura,lote,tipo_documento,fk_id_producto,fk_id_personal")] registro_compra registro_compra)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registro_compra).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fk_id_personal = new SelectList(db.personal, "rut_personal", "nombre_completo", registro_compra.fk_id_personal);
            ViewBag.fk_id_producto = new SelectList(db.producto, "id_producto", "producto1", registro_compra.fk_id_producto);
            return View(registro_compra);
        }

        // GET: registro_compra/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            registro_compra registro_compra = db.registro_compra.Find(id);
            if (registro_compra == null)
            {
                return HttpNotFound();
            }
            return View(registro_compra);
        }

        // POST: registro_compra/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            registro_compra registro_compra = db.registro_compra.Find(id);
            db.registro_compra.Remove(registro_compra);
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
