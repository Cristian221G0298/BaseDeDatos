using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDPersonas.Models
{
    public class RegistroPoblacionalContext
    {
        public MySqlConnection conexion =
        new MySqlConnection("server=localhost; user=root; password=root; database=RegistroPoblacional;Port=3307");

        public void Conectar()
        {
            if (conexion.State == System.Data.ConnectionState.Closed)
                conexion.Open();
        }

        public void Desconectar()
        {
            if (conexion.State == System.Data.ConnectionState.Open)
                conexion.Close();
        }
    }
}
