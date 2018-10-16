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

        public ActionResult Login()
        {
            return View();
        }
    }
}