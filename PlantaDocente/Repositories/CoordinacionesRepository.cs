using PlantaDocente.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantaDocente.Repositories
{
    public class CoordinacionesRepository
    {
        PlantaDocenteContext context = new();
        public IEnumerable<Coordinaciones> GetAll()
        {
            return context.Coordinaciones.OrderBy(x=>x.Nombre);
        }
    }
}
