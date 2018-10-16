using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;


namespace tpFinal.Models
{
    public static class QEQ
    {
        //inicializacion
        public static string connectionString = "Server=10.128.8.16;Database=QUIEN ES QUIEN;User Id=QEQC07;Password=QEQC07;";


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