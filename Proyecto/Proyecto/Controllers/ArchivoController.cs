using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proyecto.Models;

namespace Proyecto.Controllers
{
    public class ArchivoController : Controller
    {
        public DB_PROYECTO db = new DB_PROYECTO();
        //
        // GET: /Archivo/
        public ActionResult ObtenerArchivo(int id)
        {
            var imagen = db.archivo.Find(id);
            return File(imagen.contenido, imagen.contentType);
        }
	}
}