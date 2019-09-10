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
    public class proveedor_productoController : Controller
    {
        private patagones1Entities db = new patagones1Entities();

        // GET: proveedor_producto
        public ActionResult Index()
        {
            var proveedor_producto = db.proveedor_producto.Include(p => p.producto).Include(p => p.proveedor);
            return View(proveedor_producto.ToList());
        }

        // GET: proveedor_producto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            proveedor_producto proveedor_producto = db.proveedor_producto.Find(id);
            if (proveedor_producto == null)
            {
                return HttpNotFound();
            }
            return View(proveedor_producto);
        }

        // GET: proveedor_producto/Create
        public ActionResult Create()
        {
            ViewBag.fk_id_producto = new SelectList(db.producto, "id_producto", "producto1");
            ViewBag.fk_id_provvedor = new SelectList(db.proveedor, "rut_ptoveedor", "nombre_proveedor");
            return View();
        }

        // POST: proveedor_producto/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_producto_proveedor,fk_id_producto,fk_id_provvedor")] proveedor_producto proveedor_producto)
        {
            if (ModelState.IsValid)
            {
                db.proveedor_producto.Add(proveedor_producto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.fk_id_producto = new SelectList(db.producto, "id_producto", "producto1", proveedor_producto.fk_id_producto);
            ViewBag.fk_id_provvedor = new SelectList(db.proveedor, "rut_ptoveedor", "nombre_proveedor", proveedor_producto.fk_id_provvedor);
            return View(proveedor_producto);
        }

        // GET: proveedor_producto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            proveedor_producto proveedor_producto = db.proveedor_producto.Find(id);
            if (proveedor_producto == null)
            {
                return HttpNotFound();
            }
            ViewBag.fk_id_producto = new SelectList(db.producto, "id_producto", "producto1", proveedor_producto.fk_id_producto);
            ViewBag.fk_id_provvedor = new SelectList(db.proveedor, "rut_ptoveedor", "nombre_proveedor", proveedor_producto.fk_id_provvedor);
            return View(proveedor_producto);
        }

        // POST: proveedor_producto/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_producto_proveedor,fk_id_producto,fk_id_provvedor")] proveedor_producto proveedor_producto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(proveedor_producto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fk_id_producto = new SelectList(db.producto, "id_producto", "producto1", proveedor_producto.fk_id_producto);
            ViewBag.fk_id_provvedor = new SelectList(db.proveedor, "rut_ptoveedor", "nombre_proveedor", proveedor_producto.fk_id_provvedor);
            return View(proveedor_producto);
        }

        // GET: proveedor_producto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            proveedor_producto proveedor_producto = db.proveedor_producto.Find(id);
            if (proveedor_producto == null)
            {
                return HttpNotFound();
            }
            return View(proveedor_producto);
        }

        // POST: proveedor_producto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            proveedor_producto proveedor_producto = db.proveedor_producto.Find(id);
            db.proveedor_producto.Remove(proveedor_producto);
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
