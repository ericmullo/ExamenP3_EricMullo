using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using ExamenP3_EricMullo.Models;
using ExamenP3_EricMullo.Services;


namespace ExamenP3_EricMullo.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly ApiService _apiService;
        private string _nombrePais;
        private string _resultadoBusqueda;

        public string NombrePais
        {
            get => _nombrePais;
            set
            {
                if (_nombrePais != value)
                {
                    _nombrePais = value;
                    OnPropertyChanged();
                }
            }
        }

        public string ResultadoBusqueda
        {
            get => _resultadoBusqueda;
            set
            {
                if (_resultadoBusqueda != value)
                {
                    _resultadoBusqueda = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand BuscarCommand { get; }
        public ICommand LimpiarCommand { get; }

        public MainViewModel(ApiService apiService)
        {
            _apiService = apiService;
            BuscarCommand = new Command(async () => await BuscarAeropuerto());
            LimpiarCommand = new Command(Limpiar);
        }

        private async Task BuscarAeropuerto()
        {
            if (string.IsNullOrWhiteSpace(NombrePais))
            {
                ResultadoBusqueda = "Por favor, ingrese un país.";
                return;
            }

            var aeropuerto = await _apiService.BuscarAeropuerto(NombrePais);

            if (aeropuerto != null)
            {
                ResultadoBusqueda = $"Nombre: {aeropuerto.Nombre}, País: {aeropuerto.Pais}, Latitud: {aeropuerto.Latitud}, Longitud: {aeropuerto.Longitud}, Correo: {aeropuerto.Email}";
            }
            else
            {
                ResultadoBusqueda = "No se encontró ningún aeropuerto.";
            }
        }

        private void Limpiar()
        {
            NombrePais = string.Empty;
            ResultadoBusqueda = string.Empty;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
