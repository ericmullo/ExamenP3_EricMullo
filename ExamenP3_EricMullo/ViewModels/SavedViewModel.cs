using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using ExamenP3_EricMullo.Database;
using ExamenP3_EricMullo.Models;
namespace ExamenTercerProgreso_Eric.ViewModels
{
    public class SavedViewModel : INotifyPropertyChanged
    {
        private readonly DatabaseService _databaseService;
        private ObservableCollection<Aeropuerto> _aeropuertos;
        public ObservableCollection<Aeropuerto> Aeropuertos
        {
            get => _aeropuertos;
            set
            {
                _aeropuertos = value;
                OnPropertyChanged();
            }
        }
        public SavedViewModel(DatabaseService databaseService)
        {
            _databaseService = databaseService;
            CargarAeropuertos();
        }
        private async void CargarAeropuertos()
        {
            var aeropuertosGuardados = await _databaseService.ObtenerAeropuertos();
            Aeropuertos = new ObservableCollection<Aeropuerto>(aeropuertosGuardados);
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}