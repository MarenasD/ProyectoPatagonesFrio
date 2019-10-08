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
    public class telefono_personalController : Controller
    {
        private PatagonesEntities db = new PatagonesEntities();

        // GET: telefono_personal
        public ActionResult Index()
        {
            var telefono_personal = db.telefono_personal.Include(t => t.personal);
            return View(telefono_personal.ToList());
        }

        // GET: telefono_personal/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            telefono_personal telefono_personal = db.telefono_personal.Find(id);
            if (telefono_personal == null)
            {
                return HttpNotFound();
            }
            return View(telefono_personal);
        }

        // GET: telefono_personal/Create
        public ActionResult Create()
        {
            ViewBag.FkPersonal = new SelectList(db.personal, "RutPersonal", "Nombres");
            return View();
        }

        // POST: telefono_personal/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PrimerNumero,SegundoNumero,FkPersonal")] telefono_personal telefono_personal)
        {
            if (ModelState.IsValid)
            {
                db.telefono_personal.Add(telefono_personal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FkPersonal = new SelectList(db.personal, "RutPersonal", "Nombres", telefono_personal.FkPersonal);
            return View(telefono_personal);
        }

        // GET: telefono_personal/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            telefono_personal telefono_personal = db.telefono_personal.Find(id);
            if (telefono_personal == null)
            {
                return HttpNotFound();
            }
            ViewBag.FkPersonal = new SelectList(db.personal, "RutPersonal", "Nombres", telefono_personal.FkPersonal);
            return View(telefono_personal);
        }

        // POST: telefono_personal/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PrimerNumero,SegundoNumero,FkPersonal")] telefono_personal telefono_personal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(telefono_personal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FkPersonal = new SelectList(db.personal, "RutPersonal", "Nombres", telefono_personal.FkPersonal);
            return View(telefono_personal);
        }

        // GET: telefono_personal/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            telefono_personal telefono_personal = db.telefono_personal.Find(id);
            if (telefono_personal == null)
            {
                return HttpNotFound();
            }
            return View(telefono_personal);
        }

        // POST: telefono_personal/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            telefono_personal telefono_personal = db.telefono_personal.Find(id);
            db.telefono_personal.Remove(telefono_personal);
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
