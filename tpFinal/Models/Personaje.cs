using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace tpFinal.Models
{
    public class Personaje
    {
        //inicializacion
        private int _id;
        private string _nombre, _foto;
        private Categoria _categoria;
        private List<Caracteristica> _caracteristicas;

        public int Id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }
        public string Nombre
        {
            get
            {
                return _nombre;
            }

            set
            {
                _nombre = value;
            }
        }
        public string Foto
        {
            get
            {
                return _foto;
            }

            set
            {
                _foto = value;
            }
        }
        public Categoria Categoria
        {
            get
            {
                return _categoria;
            }

            set
            {
                _categoria = value;
            }
        }

        public List<Caracteristica> Caracteristicas
        {
            get
            {
                return _caracteristicas;
            }

            set
            {
                _caracteristicas = value;
            }
        }

    }
}