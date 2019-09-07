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
    public class personalsController : Controller
    {
        private patagones1Entities db = new patagones1Entities();

        // GET: personals
        public ActionResult Index()
        {
            var personal = db.personal.Include(p => p.cargo_personal);
            return View(personal.ToList());
        }

        // GET: personals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            personal personal = db.personal.Find(id);
            if (personal == null)
            {
                return HttpNotFound();
            }
            return View(personal);
        }

        // GET: personals/Create
        public ActionResult Create()
        {
            ViewBag.fk_id_cargo = new SelectList(db.cargo_personal, "id_cargo", "tipocargo_personal");
            return View();
        }

        // POST: personals/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "rut_personal,nombre_completo,apellido_paterno,apellido_materno,direccion_personal,fk_id_cargo")] personal personal)
        {
            if (ModelState.IsValid)
            {
                db.personal.Add(personal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.fk_id_cargo = new SelectList(db.cargo_personal, "id_cargo", "tipocargo_personal", personal.fk_id_cargo);
            return View(personal);
        }

        // GET: personals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            personal personal = db.personal.Find(id);
            if (personal == null)
            {
                return HttpNotFound();
            }
            ViewBag.fk_id_cargo = new SelectList(db.cargo_personal, "id_cargo", "tipocargo_personal", personal.fk_id_cargo);
            return View(personal);
        }

        // POST: personals/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "rut_personal,nombre_completo,apellido_paterno,apellido_materno,direccion_personal,fk_id_cargo")] personal personal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fk_id_cargo = new SelectList(db.cargo_personal, "id_cargo", "tipocargo_personal", personal.fk_id_cargo);
            return View(personal);
        }

        // GET: personals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            personal personal = db.personal.Find(id);
            if (personal == null)
            {
                return HttpNotFound();
            }
            return View(personal);
        }

        // POST: personals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            personal personal = db.personal.Find(id);
            db.personal.Remove(personal);
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
