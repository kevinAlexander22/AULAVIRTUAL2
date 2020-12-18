using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Aula_Virtual.Models;

namespace Aula_Virtual.Controllers
{
    public class clasesController : Controller
    {
        private DbAulaVitual db = new DbAulaVitual();

        // GET: clases
        public ActionResult Index()
        {
            return View(db.clases.ToList());
        }

        // GET: clases/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            clases clases = db.clases.Find(id);
            if (clases == null)
            {
                return HttpNotFound();
            }
            return View(clases);
        }

        // GET: clases/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: clases/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "codigo,nombre")] clases clases)
        {
            if (ModelState.IsValid)
            {
                db.clases.Add(clases);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(clases);
        }

        // GET: clases/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            clases clases = db.clases.Find(id);
            if (clases == null)
            {
                return HttpNotFound();
            }
            return View(clases);
        }

        // POST: clases/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "codigo,nombre")] clases clases)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clases).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(clases);
        }

        // GET: clases/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            clases clases = db.clases.Find(id);
            if (clases == null)
            {
                return HttpNotFound();
            }
            return View(clases);
        }

        // POST: clases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            clases clases = db.clases.Find(id);
            db.clases.Remove(clases);
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
