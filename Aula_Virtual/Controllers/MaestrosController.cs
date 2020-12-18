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
    public class MaestrosController : Controller
    {
        private DbAulaVitual db = new DbAulaVitual();

        // GET: Maestros
        public ActionResult Index()
        {
            return View(db.Maestros.ToList());
        }

        // GET: Maestros/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Maestros maestros = db.Maestros.Find(id);
            if (maestros == null)
            {
                return HttpNotFound();
            }
            return View(maestros);
        }

        // GET: Maestros/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Maestros/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre,apellido,edad,especialidad,email,telefono")] Maestros maestros)
        {
            if (ModelState.IsValid)
            {
                db.Maestros.Add(maestros);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(maestros);
        }

        // GET: Maestros/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Maestros maestros = db.Maestros.Find(id);
            if (maestros == null)
            {
                return HttpNotFound();
            }
            return View(maestros);
        }

        // POST: Maestros/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre,apellido,edad,especialidad,email,telefono")] Maestros maestros)
        {
            if (ModelState.IsValid)
            {
                db.Entry(maestros).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(maestros);
        }

        // GET: Maestros/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Maestros maestros = db.Maestros.Find(id);
            if (maestros == null)
            {
                return HttpNotFound();
            }
            return View(maestros);
        }

        // POST: Maestros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Maestros maestros = db.Maestros.Find(id);
            db.Maestros.Remove(maestros);
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
