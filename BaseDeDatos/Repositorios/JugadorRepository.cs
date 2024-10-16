using BaseDeDatos.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseDeDatos.Repositorios
{
    public class JugadorRepository
    {
        public ObservableCollection<JugadorModel> Jugadores { get; set; } = new();
        MySqlConnection conexion = new("server=localhost; user=root; password=root; database=LigaMx; port=3307");
        MySqlCommand sql = new();
        MySqlDataReader lector;
        LigaMxContext lmc = new();
        public IEnumerable<JugadorModel> GetAll()
        {
            lmc.Conectar();
            sql.CommandText = "select * from jugadores order by nombre;";
            sql.Connection = lmc.conexion;
            lector = sql.ExecuteReader();
            while (lector.Read())
            {
                JugadorModel jugador = new()
                {
                    Edad = (int)lector[3],
                    NickName = (string)lector[1],
                    Nombre = (string)lector[2],
                    País = (string)lector[4]
                };
                Jugadores.Add(jugador);
            }
            lector.Close();
            lmc.Desconectar();
            return Jugadores;
        }
    }
}
