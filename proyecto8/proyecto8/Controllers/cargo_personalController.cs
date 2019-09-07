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
    public class cargo_personalController : Controller
    {
        private patagones1Entities db = new patagones1Entities();

        // GET: cargo_personal
        public ActionResult Index()
        {
            return View(db.cargo_personal.ToList());
        }

        // GET: cargo_personal/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cargo_personal cargo_personal = db.cargo_personal.Find(id);
            if (cargo_personal == null)
            {
                return HttpNotFound();
            }
            return View(cargo_personal);
        }

        // GET: cargo_personal/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: cargo_personal/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_cargo,tipocargo_personal")] cargo_personal cargo_personal)
        {
            if (ModelState.IsValid)
            {
                db.cargo_personal.Add(cargo_personal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cargo_personal);
        }

        // GET: cargo_personal/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cargo_personal cargo_personal = db.cargo_personal.Find(id);
            if (cargo_personal == null)
            {
                return HttpNotFound();
            }
            return View(cargo_personal);
        }

        // POST: cargo_personal/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_cargo,tipocargo_personal")] cargo_personal cargo_personal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cargo_personal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cargo_personal);
        }

        // GET: cargo_personal/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cargo_personal cargo_personal = db.cargo_personal.Find(id);
            if (cargo_personal == null)
            {
                return HttpNotFound();
            }
            return View(cargo_personal);
        }

        // POST: cargo_personal/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            cargo_personal cargo_personal = db.cargo_personal.Find(id);
            db.cargo_personal.Remove(cargo_personal);
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
