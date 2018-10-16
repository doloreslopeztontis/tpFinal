using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace tpFinal.Models
{
    public class Usuario
    {
        private string _nombreusuario, _mail,  _contraseña;
        private bool _perfil;
        private int _botin;

        public string  NombreUsuario
        {
            get
            {
                return _nombreusuario;
            }

            set
            {
                _nombreusuario = value;
            }

        }

        public string Mail
        {
            get
            {
                return _mail;
            }

            set
            {
                _mail = value;
            }
        }
        public string Contraseña
        {
            get
            {
                return _contraseña;
            }

            set
            {
                _contraseña = value;
            }
        }
        public int Botin
        {
            get
            {
                return _botin;
            }

            set
            {
                _botin = value;
            }
        }
        public bool Perfil
        {
            get
            {
                return _perfil;
            }

            set
            {
                _perfil = value;
            }
        }


    }
}