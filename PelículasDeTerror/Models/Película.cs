using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PelículasDeTerror.Models
{
    public class Película
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public int Duración { get; set; }
        public DateOnly Estreno { get; set; }
        public int Rating {  get; set; }
        public string Director { get; set; } = null!;
        public string Sinópsis { get; set; } = null!;
        public string Portada { get; set; } = null!;
    }
}
