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
            Usuario u = new Usuario();
            Session["Usuario"] = u;
            return View();
        }

        //ABML: Lopez Joffre
        public ActionResult PaginaPrincipalAdmin()
        {
            return View();
        }
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
     

        //Login Haber
        
            
        // [HttpPost]
        public ActionResult ActionLogin(string Usuario, string Contraseña) //cambiar, todavia no anda. no se que pasa .Fede..
        {
            return View();
        }

        public ActionResult login(string Usuario="", string Contraseña="")
        {
            if (Usuario == "" && Contraseña=="")
            {
                return View();
            }
            else
            {
                bool Existe = ExisteUsuario(Usuario, Contraseña);
                Session["Usuario"] = QEQ.TraerUsuario(Usuario, Contraseña);
                Usuario u = (Usuario)Session["Usuario"];
                if (Existe == false)
                {
                    return RedirectToAction("Registro", "QEQ");
                }
                else
                {
                    if (u.Perfil == true) //true=admin
                    {
                        return RedirectToAction("PaginaPrincipalAdmin", "QEQ");
                    }
                    else
                    {
                        return RedirectToAction("comienzoJuego", "QEQ");
                    }
                }
            }
        }


        //Juego
        public ActionResult comienzoJuego()
        {
            return View();
        }
    }
}