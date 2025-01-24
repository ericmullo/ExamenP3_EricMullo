using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using ExamenTercerProgreso_Eric.Models;
using ExamenTercerProgreso_Eric.Services;
using ExamenTercerProgreso_Eric.Database;

namespace ExamenTercerProgreso_Eric.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly ApiService _apiService;
        private readonly DatabaseService _databaseService;
        private string _nombrePais;
        private string _resultadoBusqueda;

        // Propiedad NombrePais con OnPropertyChanged
        public string NombrePais
        {
            get => _nombrePais;
            set
            {
                if (_nombrePais != value) // Verificación para evitar asignaciones innecesarias
                {
                    _nombrePais = value;
                    OnPropertyChanged();
                }
            }
        }

        // Propiedad ResultadoBusqueda con OnPropertyChanged
        public string ResultadoBusqueda
        {
            get => _resultadoBusqueda;
            set
            {
                if (_resultadoBusqueda != value) // Verificación para evitar asignaciones innecesarias
                {
                    _resultadoBusqueda = value;
                    OnPropertyChanged();
                }
            }
        }

        // Declaración de los comandos
        public ICommand BuscarCommand { get; }
        public ICommand LimpiarCommand { get; }

        // Constructor con inyección de dependencias
        public MainViewModel(ApiService apiService, DatabaseService databaseService)
        {
            _apiService = apiService;
            _databaseService = databaseService;
            BuscarCommand = new Command(async () => await BuscarAeropuerto());
            LimpiarCommand = new Command(Limpiar);
        }

        // Método asincrónico para buscar un aeropuerto
        private async Task BuscarAeropuerto()
        {
            if (string.IsNullOrWhiteSpace(NombrePais))
            {
                ResultadoBusqueda = "Por favor, ingrese un país.";
                return;
            }

            // Llamada al servicio para buscar el aeropuerto
            var aeropuerto = await _apiService.BuscarAeropuerto(NombrePais);

            if (aeropuerto != null)
            {
                // Si se encuentra el aeropuerto, mostrar los resultados
                ResultadoBusqueda = $"Nombre: {aeropuerto.Nombre}, País: {aeropuerto.Pais}, Latitud: {aeropuerto.Latitud}, Longitud: {aeropuerto.Longitud}, Correo: {aeropuerto.Email}";

                // Asignar un valor a la propiedad `Scordova` si está definida en Aereopuerto
                if (!string.IsNullOrEmpty(aeropuerto.Scordova))
                {
                    aeropuerto.Scordova = "Emullo";
                }

                // Guardar el aeropuerto en la base de datos
                await _databaseService.GuardarAeropuerto(aeropuerto);
            }
            else
            {
                ResultadoBusqueda = "No se encontró ningún aeropuerto.";
            }
        }

        // Método para limpiar los campos
        private void Limpiar()
        {
            NombrePais = string.Empty;
            ResultadoBusqueda = string.Empty;
        }

        // Implementación de INotifyPropertyChanged para notificar cambios en las propiedades
        public event PropertyChangedEventHandler PropertyChanged;

        // Método para notificar cambios de propiedad
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
