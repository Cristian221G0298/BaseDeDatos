using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDFlores.Models
{
    public class DatosFlor
    {
        public int Id {  get; set; }
        public string NombreCientífico { get; set; } = null!;
        public string NombreComún {  get; set; } = null!;
        public string Origen {  get; set; } = null!;
        public string Descripción { get; set; } = null!;
        public string Nombre {  get; set; } = null!;
        public string URLImagen {  get; set; } = null!;
    }
}
