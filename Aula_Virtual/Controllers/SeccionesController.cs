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
    public class SeccionesController : Controller
    {
        private DbAulaVitual db = new DbAulaVitual();

        // GET: Secciones
        public ActionResult Index()
        {
            var secciones = db.Secciones.Include(s => s.clases).Include(s => s.Maestros);
            return View(secciones.ToList());
        }

        // GET: Secciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Secciones secciones = db.Secciones.Find(id);
            if (secciones == null)
            {
                return HttpNotFound();
            }
            return View(secciones);
        }

        // GET: Secciones/Create
        public ActionResult Create()
        {
            ViewBag.codigo = new SelectList(db.clases, "codigo", "nombre");
            ViewBag.idMaestro = new SelectList(db.Maestros, "id", "nombre");
            return View();
        }

        // POST: Secciones/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,clase,hora,aula,cupos,maestro,codigo,idMaestro")] Secciones secciones)
        {
            if (ModelState.IsValid)
            {
                db.Secciones.Add(secciones);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.codigo = new SelectList(db.clases, "codigo", "nombre", secciones.codigo);
            ViewBag.idMaestro = new SelectList(db.Maestros, "id", "nombre", secciones.idMaestro);
            return View(secciones);
        }

        // GET: Secciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Secciones secciones = db.Secciones.Find(id);
            if (secciones == null)
            {
                return HttpNotFound();
            }
            ViewBag.codigo = new SelectList(db.clases, "codigo", "nombre", secciones.codigo);
            ViewBag.idMaestro = new SelectList(db.Maestros, "id", "nombre", secciones.idMaestro);
            return View(secciones);
        }

        // POST: Secciones/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,clase,hora,aula,cupos,maestro,codigo,idMaestro")] Secciones secciones)
        {
            if (ModelState.IsValid)
            {
                db.Entry(secciones).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.codigo = new SelectList(db.clases, "codigo", "nombre", secciones.codigo);
            ViewBag.idMaestro = new SelectList(db.Maestros, "id", "nombre", secciones.idMaestro);
            return View(secciones);
        }

        // GET: Secciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Secciones secciones = db.Secciones.Find(id);
            if (secciones == null)
            {
                return HttpNotFound();
            }
            return View(secciones);
        }

        // POST: Secciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Secciones secciones = db.Secciones.Find(id);
            db.Secciones.Remove(secciones);
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
