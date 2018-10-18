using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Web.Mvc;


namespace tpFinal.Models
{
    public static class QEQ
    {
        //inicializacion
        public static string connectionString = "Server=10.128.8.16;Database=QEQC07;User Id=QEQC07;Password=QEQC07;";


        //metodos
        public static List<Categoria> ListarCategorias()
        {
            List<Categoria> lstCategorias = new List<Categoria>();

            SqlConnection conexion = conectarBase();
            SqlCommand consulta = conexion.CreateCommand();
            consulta.CommandType = CommandType.StoredProcedure;
            consulta.CommandText = "ListarCategorias";
            SqlDataReader lector = consulta.ExecuteReader();
            while (lector.Read() != false)
            {
                Categoria categoriaNow = new Categoria();
                categoriaNow.Id = (int)lector["id"];
                categoriaNow.Nombre = (string)lector["Categoria"];
                lstCategorias.Add(categoriaNow);
            }
            desconectarBase(conexion);
            return lstCategorias;
        }
        public static List<Personaje> ListarPersonajes(string Categoria)
        {
            List<Personaje> lstPersonajes = new List<Personaje>();

            SqlConnection conexion = conectarBase();
            SqlCommand consulta = conexion.CreateCommand();
            consulta.CommandType = CommandType.StoredProcedure;
            consulta.CommandText = "ListarPersonajes";
            consulta.Parameters.AddWithValue("@categoria", Categoria);
            SqlDataReader lector = consulta.ExecuteReader();
            while (lector.Read() != false)
            {
                Personaje personajeNow = new Personaje();
                personajeNow.Id = (int)lector["id"];
                personajeNow.Nombre = (string)lector["Nombre"];
                personajeNow.Foto = (string)lector["Foto"];

                Categoria categoriaNow = new Categoria();
                categoriaNow.Id = (int)lector["IdCategoria"];
                categoriaNow.Nombre = (string)lector["Categoria"];

                personajeNow.Categoria = categoriaNow;
                personajeNow.Caracteristicas = ListarCaracteristicasPersonaje(personajeNow.Id);
                lstPersonajes.Add(personajeNow);
            }
            desconectarBase(conexion);
            return lstPersonajes;
        }
        public static List<Caracteristica> ListarCaracteristicas()
        {
            List<Caracteristica> lstCaracteristicas = new List<Caracteristica>();

            SqlConnection conexion = conectarBase();
            SqlCommand consulta = conexion.CreateCommand();
            consulta.CommandType = CommandType.StoredProcedure;
            consulta.CommandText = "ListarCaracteristicas";
            SqlDataReader lector = consulta.ExecuteReader();
            while (lector.Read() != false)
            {
                Caracteristica caracteristicaNow = new Caracteristica();
                caracteristicaNow.Id = (int)lector["id"];
                caracteristicaNow.Nombre = (string)lector["Caracteristica"];

                lstCaracteristicas.Add(caracteristicaNow);
            }
            desconectarBase(conexion);
            return lstCaracteristicas;
        }

        public static void InsertarPersonaje(Personaje PERSONAJE)
        {
            SqlConnection conexion = conectarBase();
            SqlCommand consulta = conexion.CreateCommand();
            consulta.CommandType = CommandType.StoredProcedure;
            consulta.CommandText = "InsertarPersonaje";
            consulta.Parameters.AddWithValue("@nombre", PERSONAJE.Nombre);
            consulta.Parameters.AddWithValue("@foto", PERSONAJE.Foto);
            consulta.Parameters.AddWithValue("@categoria", PERSONAJE.Categoria);
            consulta.ExecuteNonQuery();
            desconectarBase(conexion);
        }
        public static void EliminarPersonaje(int Id)
        {
            SqlConnection conexion = conectarBase();
            SqlCommand consulta = conexion.CreateCommand();
            consulta.CommandType = CommandType.StoredProcedure;
            consulta.CommandText = "EliminarPersonaje";
            consulta.Parameters.AddWithValue("@idpersonaje", Id);
            consulta.ExecuteNonQuery();
            desconectarBase(conexion);
        }
        public static Personaje TraerPersonaje(int Id)
        {
            Personaje personajeNow = new Personaje();
            personajeNow.Id = Id;

            SqlConnection conexion = conectarBase();
            SqlCommand consulta = conexion.CreateCommand();
            consulta.CommandType = CommandType.StoredProcedure;
            consulta.CommandText = "TraerPersonaje";
            consulta.Parameters.AddWithValue("@idpersonaje", Id);
            SqlDataReader lector = consulta.ExecuteReader();
            if (lector.Read() != false)
            {
                personajeNow.Nombre = (string)lector["Nombre"];
                personajeNow.Foto= (string)lector["Foto"];
                personajeNow.Categoria = (int)
            }
            desconectarBase(conexion);
            return personajeNow;
        }


        /*
        public static void InsertarTrabajador(Trabajador TRABAJADOR)
        {
            SqlConnection conexion = conectarBase();
            SqlCommand consulta = conexion.CreateCommand();
            consulta.CommandType = CommandType.StoredProcedure;
            consulta.CommandText = "InsertarTrabajador";
            consulta.Parameters.AddWithValue("@foto", TRABAJADOR.Foto);
            consulta.Parameters.AddWithValue("@nombre", TRABAJADOR.Nombre);
            consulta.Parameters.AddWithValue("@apellido", TRABAJADOR.Apellido);
            consulta.Parameters.AddWithValue("@nacimiento", TRABAJADOR.Nacimiento);
            consulta.Parameters.AddWithValue("@sueldo", TRABAJADOR.Sueldo);
            consulta.Parameters.AddWithValue("@activo", TRABAJADOR.Activo);
            consulta.ExecuteNonQuery();
            desconectarBase(conexion);
        }
        public static Trabajador TraerTrabajador(int id)
        {
            Trabajador TRABAJADOR = new Trabajador();
            TRABAJADOR.Codigo = id;

            SqlConnection conexion = conectarBase();
            SqlCommand consulta = conexion.CreateCommand();
            consulta.CommandType = CommandType.StoredProcedure;
            consulta.CommandText = "TraerTrabajador";
            consulta.Parameters.AddWithValue("@cod", id);
            SqlDataReader lector = consulta.ExecuteReader();
            if (lector.Read() != false)
            {
                TRABAJADOR.Foto = (string)lector["Foto"];
                TRABAJADOR.Nombre = (string)lector["Nombre"];
                TRABAJADOR.Apellido = (string)lector["Apellido"];
                TRABAJADOR.Nacimiento = (DateTime)lector["Nacimiento"];
                TRABAJADOR.Sueldo = (float)lector["Sueldo"];
                TRABAJADOR.Activo = (bool)lector["Activo"];
            }
            desconectarBase(conexion);
            return TRABAJADOR;
        }
        public static void ModificarTrabajador(Trabajador TRABAJADOR)
        {
            SqlConnection conexion = conectarBase();
            SqlCommand consulta = conexion.CreateCommand();
            consulta.CommandType = CommandType.StoredProcedure;
            consulta.CommandText = "ModificarTrabajador";
            consulta.Parameters.AddWithValue("@cod", TRABAJADOR.Codigo);
            consulta.Parameters.AddWithValue("@foto", TRABAJADOR.Foto);
            consulta.Parameters.AddWithValue("@nombre", TRABAJADOR.Nombre);
            consulta.Parameters.AddWithValue("@apellido", TRABAJADOR.Apellido);
            consulta.Parameters.AddWithValue("@nacimiento", TRABAJADOR.Nacimiento);
            consulta.Parameters.AddWithValue("@sueldo", TRABAJADOR.Sueldo);
            consulta.Parameters.AddWithValue("@activo", TRABAJADOR.Activo);
            consulta.ExecuteNonQuery();
            desconectarBase(conexion);
        }
        public static void BorrarTrabajador(int id)
        {
            SqlConnection conexion = conectarBase();
            SqlCommand consulta = conexion.CreateCommand();
            consulta.CommandType = CommandType.StoredProcedure;
            consulta.CommandText = "BorrarTrabajador";
            consulta.Parameters.AddWithValue("@cod", id);
            consulta.ExecuteNonQuery();
            desconectarBase(conexion);
        }

        */

        public static bool ExisteUsuario(string user, string contra)
        {
            bool existe = false;
            Usuario userNow = TraerUsuario(user, contra);
            if(userNow != null)
            {
                existe = true;
            }
            return existe;
        }

        public static Usuario TraerUsuario(string Nombre, string Pass)
        {
            Usuario userNow = new Usuario();

            SqlConnection conexion = conectarBase();
            SqlCommand consulta = conexion.CreateCommand();
            consulta.CommandType = CommandType.StoredProcedure;
            consulta.CommandText = "LoginUsuario";
            consulta.Parameters.AddWithValue("@usuario", Nombre);
            consulta.Parameters.AddWithValue("@pass", Pass);
            SqlDataReader lector = consulta.ExecuteReader();
            if (lector.Read() != false)
            {
                userNow.NombreUsuario = (string)lector["Usuario"];
                userNow.Contraseña = (string)lector["Contraseña"];
                userNow.Perfil = (bool)lector["Perfil"];
            }
            desconectarBase(conexion);
            return userNow;
        }


        //funciones
        private static SqlConnection conectarBase()
        {
            SqlConnection conexion = new SqlConnection(connectionString);
            conexion.Open();
            return conexion;
        }
        private static void desconectarBase(SqlConnection conexion)
        {
            conexion.Close();
        }

        private static List<Caracteristica> ListarCaracteristicasPersonaje(int id)
        {
            List<Caracteristica> lstCaracteristicas = new List<Caracteristica>();

            SqlConnection conexion = conectarBase();
            SqlCommand consulta = conexion.CreateCommand();
            consulta.CommandType = CommandType.StoredProcedure;
            consulta.CommandText = "ListarCaracteristicasPersonaje";
            consulta.Parameters.AddWithValue("@idpersonaje", id);
            SqlDataReader lector = consulta.ExecuteReader();
            while (lector.Read() != false)
            {
                Caracteristica caracteristicaNow = new Caracteristica();
                caracteristicaNow.Id = (int)lector["id"];
                caracteristicaNow.Nombre = (string)lector["Caracteristica"];
                lstCaracteristicas.Add(caracteristicaNow);
            }
            desconectarBase(conexion);
            return lstCaracteristicas;
        }
       

    }
}