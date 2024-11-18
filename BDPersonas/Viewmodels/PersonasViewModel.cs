using BDPersonas.Models;
using BDPersonas.Repositories;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BDPersonas.Viewmodels
{
    public enum Sexos { Hombres = 1, Mujeres = 2 }
    public class PersonasViewModel:INotifyPropertyChanged
    {
        public string Modo { get; set; } = "Ver";
        public ICommand AgregarCommand { get; set; }
        public ICommand EliminarCommand { get; set; }
        public ICommand GuardarAgregarCommand { get; set; }
        public ObservableCollection<PersonaModel> Personas { get; set; } = new();
        public int Hombres => Personas.Where(x=>x.Genero == Sexos.Hombres).Count();
        public int Mujeres => Personas.Where(x => x.Genero == Sexos.Mujeres).Count();
        public List<Sexos> Generos { get; set; } = new();
        string? error;
        public string? Error { get => error; set => error = value; }
        public PersonaModel Persona { get; set; } = null!;
        PersonaRepository repos = new();

        public event PropertyChangedEventHandler? PropertyChanged;
        public PersonasViewModel()
        {
            Actualizar();
            AgregarCommand = new RelayCommand(VerAgregar);
            EliminarCommand = new RelayCommand<PersonaModel>(Eliminar);
            GuardarAgregarCommand = new RelayCommand(GuardarAgregar);
            Generos.Add(Sexos.Hombres);
            Generos.Add(Sexos.Mujeres);
        }

        void GuardarAgregar()
        {
            if (!repos.Validar(Persona, out error))
            {
                repos.Agregar(Persona);
                Modo = "Ver";
            }
            Actualizar();
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
        }

        void Eliminar(PersonaModel p)
        {
            if(p != null)
            {
                repos.Eliminar(p);
                Modo = "Ver";
                Actualizar();
            }
        }

        void VerAgregar()
        {
            Modo = "Agregar";
            Persona = new();
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
        }

        void Actualizar()
        {
            Personas.Clear();
            Personas = (ObservableCollection<PersonaModel>)repos.GetAllPersonas();
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
        }
    }
}
