using BDPersonas.Viewmodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDPersonas.Models
{
    public class PersonaModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public int Edad { get; set; }
        public Sexos Genero { get; set; }
    }
}
