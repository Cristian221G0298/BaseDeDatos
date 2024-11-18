using EjercicioBanderas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioBanderas.Repositories
{
    public class PaísRepository
    {
        MundoContext context = new();
        public IEnumerable<Paises> GetAllPaíses()
        {
            return context.Paises.OrderBy(x=>x.Nombre);
        }
    }
}
