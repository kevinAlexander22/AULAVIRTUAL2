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
    public class materiasController : Controller
    {
        private DbAulaVitual db = new DbAulaVitual();

        // GET: materias
        public ActionResult Index()
        {
            return View(db.materia.ToList());
        }

        // GET: materias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            materia materia = db.materia.Find(id);
            if (materia == null)
            {
                return HttpNotFound();
            }
            return View(materia);
        }

        // GET: materias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: materias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre")] materia materia)
        {
            if (ModelState.IsValid)
            {
                db.materia.Add(materia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(materia);
        }

        // GET: materias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            materia materia = db.materia.Find(id);
            if (materia == null)
            {
                return HttpNotFound();
            }
            return View(materia);
        }

        // POST: materias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre")] materia materia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(materia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(materia);
        }

        // GET: materias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            materia materia = db.materia.Find(id);
            if (materia == null)
            {
                return HttpNotFound();
            }
            return View(materia);
        }

        // POST: materias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            materia materia = db.materia.Find(id);
            db.materia.Remove(materia);
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
