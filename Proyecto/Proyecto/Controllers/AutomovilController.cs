using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Proyecto.Models;

namespace Proyecto.Controllers
{
    public class AutomovilController : Controller
    {
        private DB_PROYECTO db = new DB_PROYECTO();

        // GET: /Automovil/
        public ActionResult Index()
        {
            var automovil = db.automovil.Include(a => a.combustible).Include(a => a.marca).Include(a => a.modelo);
            return View(automovil.ToList());
        }

        // GET: /Automovil/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Automovil automovil = db.automovil.Find(id);
            if (automovil == null)
            {
                return HttpNotFound();
            }
            return View(automovil);
        }

        // GET: /Automovil/Create
        public ActionResult Create()
        {
            ViewBag.idCombustible = new SelectList(db.combustible, "idCombustible", "nombre");
            ViewBag.idMarca = new SelectList(db.marca, "idMarca", "nombre");
            ViewBag.idModelo = new SelectList(db.modelo, "idModelo", "nombre");
            return View();
        }

        // POST: /Automovil/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idAutomovil,precio,color,descripcion,estado,idMarca,idModelo,idCombustible,idTransmision")] Automovil automovil, HttpPostedFileBase archivo)
        {
            if (archivo != null && archivo.ContentLength > 0)
            {
                var imagen = new Archivo
                {
                    nombre = System.IO.Path.GetFileName(archivo.FileName),
                    tipo = FileType.Imagen,
                    contentType = archivo.ContentType
                };
                using (var reader = new System.IO.BinaryReader(archivo.InputStream))
                {
                    imagen.contenido = reader.ReadBytes(archivo.ContentLength);
                };
                automovil.archivos = new List<Archivo> { imagen };
            }
            if (ModelState.IsValid)
            {
                db.automovil.Add(automovil);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idCombustible = new SelectList(db.combustible, "idCombustible", "nombre", automovil.idCombustible);
            ViewBag.idMarca = new SelectList(db.marca, "idMarca", "nombre", automovil.idMarca);
            ViewBag.idModelo = new SelectList(db.modelo, "idModelo", "nombre", automovil.idModelo);
            return View(automovil);
        }

        // GET: /Automovil/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Automovil automovil = db.automovil.Find(id);
            if (automovil == null)
            {
                return HttpNotFound();
            }
            ViewBag.idCombustible = new SelectList(db.combustible, "idCombustible", "nombre", automovil.idCombustible);
            ViewBag.idMarca = new SelectList(db.marca, "idMarca", "nombre", automovil.idMarca);
            ViewBag.idModelo = new SelectList(db.modelo, "idModelo", "nombre", automovil.idModelo);
            return View(automovil);
        }

        // POST: /Automovil/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="idAutomovil,precio,color,descripcion,estado,transmision,idMarca,idModelo,idCombustible")] Automovil automovil)
        {
            if (ModelState.IsValid)
            {
                db.Entry(automovil).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idCombustible = new SelectList(db.combustible, "idCombustible", "nombre", automovil.idCombustible);
            ViewBag.idMarca = new SelectList(db.marca, "idMarca", "nombre", automovil.idMarca);
            ViewBag.idModelo = new SelectList(db.modelo, "idModelo", "nombre", automovil.idModelo);
            return View(automovil);
        }

        // GET: /Automovil/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Automovil automovil = db.automovil.Find(id);
            if (automovil == null)
            {
                return HttpNotFound();
            }
            return View(automovil);
        }

        // POST: /Automovil/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Automovil automovil = db.automovil.Find(id);
            db.automovil.Remove(automovil);
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
