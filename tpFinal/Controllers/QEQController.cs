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

        //ABML: Lopez Joffre
        public ActionResult ListaPersonajes(string Categoria = "todos")
        {
            ViewBag.Personajes = QEQ.ListarPersonajes(Categoria);
            return View();
        }

        

        //Inicio: Ramis
        public ActionResult Home()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Instrucciones()
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