using PlantaDocente.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantaDocente.Repositories
{
    public class DocentesRepository
    {
        PlantaDocenteContext context = new();
        public IEnumerable<Docentes> GetDocentesByCoordinacion(Coordinaciones c)
        {
            //return context.Docentes.Where(x=>x.IdCoordinacion == c).OrderBy(x => x.Nombre);
            return context.Coordinaciones.Where(x=>x.Clave == c.Clave).SelectMany(x=>x.Docentes).OrderBy(x=>x.Nombre);
        }
    }
}
