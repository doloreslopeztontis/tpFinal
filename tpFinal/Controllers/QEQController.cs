using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tpFinal.Models;

namespace tpFinal.Controllers
{
    public class QEQController : Controller
    {
        Usuario u = new Usuario();
        // GET: QEQ
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult ListaPersonajes(string categoria)
        {
            ViewBag.Personajes = QEQ.ListarPersonajes(categoria);
            return View();
        }

        public ActionResult EliminarPersonaje (int Id)
        {
            QEQ.EliminarPersonaje(Id);
            ViewBag.Mensaje = "eliminado exitosamente";
            return View("ListaPersonajes", "QEQ");
        }
        public ActionResult home()
        {
            return View();
        }
        public ActionResult about()
        {
            return View();
        }
        public ActionResult instructions()
        {
            return View();
        }
        // [HttpPost]
        public ActionResult ActionLogin(string Usuario, string Contraseña) //cambiar, todavia no anda. no se que pasa .Fede..
        {
            ViewBag.u = QEQ.TraerUser(Usuario, Contraseña);
            if (u.Perfil == true) //true=admin
            {
                return View("ListarPersonajes", "QEQ");
            }
            else
            {
                return View();
            }
        }
        public ActionResult login()
        {
                return View();
        }
        public ActionResult comienzoJuego()
        {
            return View();
        }
    }
}