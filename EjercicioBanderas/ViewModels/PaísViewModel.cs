using EjercicioBanderas.Models;
using EjercicioBanderas.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioBanderas.ViewModels
{
    public class PaísViewModel
    {
        PaísRepository repos = new();
        public List<Paises> ListaPaises { get; set; } = new();
        public PaísViewModel()
        {
            ListaPaises = repos.GetAllPaíses().ToList();
        }
    }
}
