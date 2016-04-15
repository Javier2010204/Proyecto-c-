using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proyecto.Models;

namespace Proyecto.Controllers
{
    public class CuentaController : Controller
    {
        public DB_PROYECTO db = new DB_PROYECTO();
        //
        // GET: /Cuenta/
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Usuario usuario)
        {
            var usr = db.usuario.FirstOrDefault(u => u.correo == usuario.correo && u.contraseña == usuario.contraseña);
            if (usr != null)
            {
                Session["nombreUsuario"] = usr.nombre;
                Session["idUsuario"] = usr.idUsuario;
                return VerificarSesion();
            }
            else
            {
                ModelState.AddModelError("", "Verifique sus credenciales");
            }
            return View();
        }

         public ActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registro(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                var rol = db.rol.FirstOrDefault(r => r.idRol == 2);
                db.usuario.Add(usuario);
                db.SaveChanges();
                ViewBag.mensaje = "El usuario" + usuario.nombre + " fue registrado con exito";
            }
            return View();
        }

        public ActionResult VerificarSesion()
        {
            if(Session["idUsuario"]!=null){
                return RedirectToAction("../Home/Index");
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult Logout()
        {
            Session.Remove("idUsuario");
            Session.Remove("nombreUsuario");
            return RedirectToAction("Login");
        }
       
	}
}