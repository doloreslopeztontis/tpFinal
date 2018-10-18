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
        // GET: QEQ
        public ActionResult Index()
        {
            Usuario USUARIO = new Usuario();
            Session["USUARIO"] = USUARIO;
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
        public ActionResult ActionLogin(string Usuario, string Contraseña) //cambiar, todavia no anda. no se que pasa. Fede.
        {
            Session["USUARIO"] = QEQ.TraerUsuario(Usuario, Contraseña);
            if (u.Perfil) //true = admin
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