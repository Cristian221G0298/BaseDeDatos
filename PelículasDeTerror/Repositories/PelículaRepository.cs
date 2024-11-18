using MySql.Data.MySqlClient;
using PelículasDeTerror.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PelículasDeTerror.Repositories
{
    public class PelículaRepository
    {
        PelículasDeTerrorContext context = new();
        MySqlCommand sql = new();
        MySqlDataReader? lector;
        List<Película> Películas = new();

        //Utilicé ExecuteEscalar aunque bastara con consultas de LinQ, esto sólo para utilizarlo & que se viera que funciona :)
        public IEnumerable<Película> GetAll()
        {
            Películas.Clear();
            context.Conectar();
            sql.CommandText = "SELECT * FROM PELICULA ORDER BY Nombre";
            sql.Connection = context.conexion;
            lector = sql.ExecuteReader();
            while (lector.Read())
            {
                Película p = new()
                {
                    Id = lector.GetInt32("Id"),
                    Nombre = lector.GetString("Nombre"),
                    Duración = lector.GetInt32("Duracion"),
                    Estreno = DateOnly.FromDateTime(lector.GetDateTime("Estreno")),
                    Rating = lector.GetInt32("Rating"),
                    Director = lector.GetString("Director"),
                    Sinópsis = lector.GetString("Sinopsis"),
                    Portada = lector.GetString("Portada")
                };
                Películas.Add(p);
            }
            lector.Close();
            context.Desconectar();
            return Películas;
        }

        public int CountPelículas()
        {
            context.Conectar();
            sql.CommandText = "SELECT COUNT(*) FROM PELICULA";
            sql.Connection = context.conexion;
            var c = Convert.ToInt32(sql.ExecuteScalar());
            context.Desconectar();
            return c;
        }

        public IEnumerable<Película> GetPeliculasRating(int r)
        {
            return Películas.Where(x=>x.Rating == r);
        }

        public int CountRating(int r)
        {
            context.Conectar();
            sql.CommandText = $"SELECT COUNT(*) FROM PELICULA WHERE RATING = {r}";
            sql.Connection = context.conexion;
            var c = Convert.ToInt32(sql.ExecuteScalar());
            context.Desconectar();
            return c;
        }

        public IEnumerable<Película> GetPelículasAñoEstreno(int e)
        {
            return Películas.Where(x => x.Estreno.Year == e);
        }

        public int CountPeliculasAñoEstreno(int e)
        {
            context.Conectar();
            sql.CommandText = $"SELECT COUNT(*) FROM PELICULA WHERE YEAR(ESTRENO) = {e}";
            sql.Connection = context.conexion;
            var c = Convert.ToInt32(sql.ExecuteScalar());
            context.Desconectar();
            return c;
        }

        public void Agregar(Película p)
        {
            context.Conectar();
            sql.CommandText = $"INSERT INTO pelicula(Nombre, Duracion, Estreno, Rating, Director, Sinopsis, Portada) VALUES('{p.Nombre}', {p.Duración}, '{p.Estreno}', {p.Rating}, '{p.Director}', '{p.Sinópsis}', '{p.Portada}');";
            sql.Connection = context.conexion;
            sql.ExecuteNonQuery();
            context.Desconectar();
        }

        public void Eliminar(Película p)
        {
            context.Conectar();
            sql.CommandText = $"DELETE FROM pelicula WHERE ID={p.Id};";
            sql.Connection = context.conexion;
            sql.ExecuteNonQuery();
            context.Desconectar();
        }

        public static bool Validar(Película p, out string? error)
        {
            List<string> listErrores = new();
            if(string.IsNullOrWhiteSpace(p.Nombre) || string.IsNullOrWhiteSpace(p.Director) || string.IsNullOrWhiteSpace(p.Sinópsis) || string.IsNullOrWhiteSpace(p.Portada))
                listErrores.Add("Verifica haber llenado todos los campos");
            if(p.Duración < 30)
                listErrores.Add("Verifica que la duración sea correcta");
            if(p.Estreno > DateOnly.FromDateTime(DateTime.Now))
                listErrores.Add("Verifica que la fecha esté en formato YYYY-MM-DD y que sea correcta");
            if(p.Rating < 1 || p.Rating > 5)
                listErrores.Add("El Rating es evaluado en una escala de 1 a 5");
            if(!p.Portada.EndsWith(".jpg") && !p.Portada.EndsWith(".jpeg") && !p.Portada.EndsWith(".png"))
            {
                listErrores.Add("Verifica que el formato de la imagen termine en jpg, jpeg o png");
            }

            error = string.Join(Environment.NewLine, listErrores);
            return listErrores.Count != 0;
        }
    }
}