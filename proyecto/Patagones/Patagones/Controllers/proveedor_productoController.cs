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
    public class proveedor_productoController : Controller
    {
        private PatagonesEntities db = new PatagonesEntities();

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
            ViewBag.FkProducto = new SelectList(db.producto, "IdProducto", "Nombre");
            ViewBag.FkProveedor = new SelectList(db.proveedor, "RutProveedor", "NombreProveedor");
            return View();
        }

        // POST: proveedor_producto/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FkProducto,FkProveedor")] proveedor_producto proveedor_producto)
        {
            if (ModelState.IsValid)
            {
                db.proveedor_producto.Add(proveedor_producto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FkProducto = new SelectList(db.producto, "IdProducto", "Nombre", proveedor_producto.FkProducto);
            ViewBag.FkProveedor = new SelectList(db.proveedor, "RutProveedor", "NombreProveedor", proveedor_producto.FkProveedor);
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
            ViewBag.FkProducto = new SelectList(db.producto, "IdProducto", "Nombre", proveedor_producto.FkProducto);
            ViewBag.FkProveedor = new SelectList(db.proveedor, "RutProveedor", "NombreProveedor", proveedor_producto.FkProveedor);
            return View(proveedor_producto);
        }

        // POST: proveedor_producto/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FkProducto,FkProveedor")] proveedor_producto proveedor_producto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(proveedor_producto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FkProducto = new SelectList(db.producto, "IdProducto", "Nombre", proveedor_producto.FkProducto);
            ViewBag.FkProveedor = new SelectList(db.proveedor, "RutProveedor", "NombreProveedor", proveedor_producto.FkProveedor);
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
