using PlantaDocente.Models;
using PlantaDocente.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantaDocente.ViewModels
{
    public class PlantaDocenteViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        CoordinacionesRepository reposCoordinación = new();
        DocentesRepository reposDocentes = new();
        public List<Coordinaciones> ListaCoordinacion { get; set; } = new();
        Coordinaciones coordinador = null!;
        public List<Docentes> ListaDocentes { get; set; } = new();
        public Coordinaciones CoordinadorAcademico
        {
            get { return coordinador; }
            set { coordinador = value; GetDocentesByCoordinador(); }
        }
        public PlantaDocenteViewModel()
        {
            ListaCoordinacion = reposCoordinación.GetAll().ToList();
        }
        void GetDocentesByCoordinador()
        {
            if(coordinador is not null)
            {
                ListaDocentes = reposDocentes.GetDocentesByCoordinacion(CoordinadorAcademico).ToList();
                PropertyChanged?.Invoke(this,new(nameof(ListaDocentes)));
            }
        }
    }
}
