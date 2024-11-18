using BDPersonas.Models;
using BDPersonas.Viewmodels;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDPersonas.Repositories
{
    public class PersonaRepository
    {
        RegistroPoblacionalContext context = new();
        MySqlCommand sql = new MySqlCommand();
        MySqlDataReader? lector;
        public ObservableCollection<PersonaModel> DatosPersonas { get; set; } = new();

        public IEnumerable<PersonaModel> GetAllPersonas()
        {
            context.Conectar();
            sql.CommandText = "select * from personas order by Nombre";
            sql.Connection = context.conexion;
            lector = sql.ExecuteReader();
            while (lector.Read())
            {
                PersonaModel p = new()
                {
                    Id = lector.GetInt32("Id"),
                    Nombre = lector.GetString("Nombre"),
                    Edad = lector.GetInt32("Edad"),
                    Genero = lector.GetInt32("Genero") == 1 ? Sexos.Hombres : Sexos.Mujeres
                };
                DatosPersonas.Add(p);
            }
            lector.Close();
            context.Desconectar();
            return DatosPersonas;
        }

        public void Agregar(PersonaModel p)
        {
            context.Conectar();
            sql.CommandText = $"insert into Personas (Nombre, Edad, Genero) values ('{p.Nombre}','{p.Edad}','{(p.Genero == Sexos.Hombres ? 1 : 2)}');";
            sql.Connection = context.conexion;
            sql.ExecuteNonQuery();
            context.Desconectar();
        }
        public void Eliminar(PersonaModel p)
        {
            context.Conectar();
            sql.CommandText = $"delete from personas where id={p.Id};";
            sql.Connection = context.conexion;
            sql.ExecuteNonQuery();
            context.Desconectar();
        }
        public bool Validar(PersonaModel p, out string? error)
        {
            List<string> listErrores = new List<string>();
            if (string.IsNullOrWhiteSpace(p.Nombre))
            {
                listErrores.Add("Escriba el nombre de la persona");
            }
            if (p.Edad < 0 || p.Edad > 100)
            {
                listErrores.Add("La edad de la persona debe de estar entre o y 100");
            }
            if (p.Genero == 0)
            {
                listErrores.Add("Seleccione un genero valido: hombre o mujer");
            }
            error = string.Join(Environment.NewLine, listErrores);
            return listErrores.Count != 0;
        }
    }
}
