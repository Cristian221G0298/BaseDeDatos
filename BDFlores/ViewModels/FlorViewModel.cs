using BDFlores.Models;
using BDFlores.Repositories;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BDFlores.ViewModels
{
    public enum Vista { Datos, Flor }
    public class FlorViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public Vista vista { get; set; } = Vista.Datos;
        FlorRepository reposflor = new FlorRepository();
        public DatosFlor Flor { get; set; }
        public List<DatosFlor> Datos { get; set; } = new List<DatosFlor>();
        public ICommand CambiarVistaCommand { get; set; }
        public ICommand CancelarCommandVistaCommand { get; set; }
        public FlorViewModel()
        {
            Datos = reposflor.GetAll().ToList();
            CambiarVistaCommand = new RelayCommand<Vista>(CambiarVista);
            CancelarCommandVistaCommand = new RelayCommand(CancelarVista);
        }

        void CancelarVista()
        {
            vista = Vista.Datos;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
        }
        void CambiarVista(Vista vista1)
        {
            vista = vista1;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
        }
    }
}
