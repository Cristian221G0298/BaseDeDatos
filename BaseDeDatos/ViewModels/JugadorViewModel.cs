using BaseDeDatos.Models;
using BaseDeDatos.Repositorios;
using Org.BouncyCastle.X509.Store;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseDeDatos.ViewModels
{
    public class JugadorViewModel : INotifyPropertyChanged
    {
        int edad;
        string país;
        public int Edad
        {
            get { return edad; }
            set { edad = value; Filtrar(); }
        }
        public string País
        {
            get { return país; }
            set { país = value; Filtrar(); }
        }
        JugadorRepository JugadorM { get; set; } = new();
        public IEnumerable<string> Países => JugadorM.Jugadores.OrderBy(x=>x.País).Select(x=>x.País).Distinct();
        public IEnumerable<int> Edades => JugadorM.Jugadores.OrderBy(x=>x.Edad).Select(x=>x.Edad).Distinct();
        public IEnumerable<JugadorModel>? JugadoresFiltrados { get; set; }


        public event PropertyChangedEventHandler? PropertyChanged;

        void Filtrar()
        {
            IEnumerable<JugadorModel> filtro = JugadorM.Jugadores;
            if(País is not null)
                filtro = filtro.Where(x => x.País == País);
            if(Edad != 0)
                filtro = filtro.Where(x => x.Edad == Edad);
            JugadoresFiltrados = filtro;
            PropertyChanged?.Invoke(this, new(nameof(JugadoresFiltrados)));
        }

        public JugadorViewModel()
        {
            JugadorM.GetAll();
            JugadoresFiltrados = JugadorM.Jugadores;
        }
    }
}
