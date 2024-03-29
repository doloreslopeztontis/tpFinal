﻿using System;
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
            Usuario USER = new Usuario();
            Session["Usuario"] = USER;
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
     

        //Login: Haber
        [HttpPost]
        public ActionResult ActionLogin()
        {
            return View();
        }

        public ActionResult Login(string Usuario="", string Contraseña="")
        {
            if (Usuario == "" && Contraseña=="")
            {
                return View();
            }
            else
            {
                bool Existe = QEQ.ExisteUsuario(Usuario, Contraseña);
                Usuario USER = QEQ.TraerUsuario(Usuario, Contraseña);
                Session["Usuario"] = USER;
                if (Existe == false)
                {
                    return RedirectToAction("Registro", "QEQ");
                }
                else
                {
                    if (USER.Perfil == true) //true=admin
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
	public ActionResult ComienzoJuego()


        {
            return View();
        }
    }
}