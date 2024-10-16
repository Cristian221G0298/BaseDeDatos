using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseDeDatos.Models
{
    public class JugadorModel
    {
        public string Nombre { get; set; } = "";
        public string NickName { get; set; } = "";
        public string País { get; set; } = "";
        public int Edad {  get; set; }
    }
}
