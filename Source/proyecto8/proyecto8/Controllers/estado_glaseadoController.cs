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
    public class estado_glaseadoController : Controller
    {
        private patagones1Entities db = new patagones1Entities();

        // GET: estado_glaseado
        public ActionResult Index()
        {
            return View(db.estado_glaseado.ToList());
        }

        // GET: estado_glaseado/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            estado_glaseado estado_glaseado = db.estado_glaseado.Find(id);
            if (estado_glaseado == null)
            {
                return HttpNotFound();
            }
            return View(estado_glaseado);
        }

        // GET: estado_glaseado/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: estado_glaseado/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_estado_glaseado,tipo_estado")] estado_glaseado estado_glaseado)
        {
            if (ModelState.IsValid)
            {
                db.estado_glaseado.Add(estado_glaseado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(estado_glaseado);
        }

        // GET: estado_glaseado/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            estado_glaseado estado_glaseado = db.estado_glaseado.Find(id);
            if (estado_glaseado == null)
            {
                return HttpNotFound();
            }
            return View(estado_glaseado);
        }

        // POST: estado_glaseado/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_estado_glaseado,tipo_estado")] estado_glaseado estado_glaseado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estado_glaseado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(estado_glaseado);
        }

        // GET: estado_glaseado/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            estado_glaseado estado_glaseado = db.estado_glaseado.Find(id);
            if (estado_glaseado == null)
            {
                return HttpNotFound();
            }
            return View(estado_glaseado);
        }

        // POST: estado_glaseado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            estado_glaseado estado_glaseado = db.estado_glaseado.Find(id);
            db.estado_glaseado.Remove(estado_glaseado);
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
