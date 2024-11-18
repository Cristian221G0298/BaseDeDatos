using BDFlores.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDFlores.Repositories
{
    public class FlorRepository
    {
        FloresContext context = new();
        MySqlCommand sql = new();
        List<DatosFlor> flores { get; set; } = new();
        MySqlDataReader? lector;
        public IEnumerable<DatosFlor> GetAll()
        {
            context.Conectar();
            sql.CommandText = "Select * from datosFlores order by nombre";
            sql.Connection = context.conexion;
            lector = sql.ExecuteReader();
            while(lector.Read())
            {
                DatosFlor df = new()
                {
                    Id = (int)lector["Id"],
                    NombreCientífico = (string)lector["NombreCientifico"],
                    NombreComún = (string)lector["NombreComun"],
                    Origen = (string)lector["Origen"],
                    Descripción = (string)lector["Descripcion"],
                    Nombre = (string)lector["Nombre"],
                    URLImagen = (string)lector["URLImagen"]
                };
                flores.Add(df);
            }
            lector.Close();
            context.Desconectar();
            return flores;
        }
    }
}
