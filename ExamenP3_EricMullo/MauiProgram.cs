using System.IO;
using Microsoft.Maui;
using Microsoft.Maui.Hosting;
using Microsoft.Extensions.DependencyInjection;
using ExamenP3_EricMullo.Views;
using ExamenP3_EricMullo.ViewModels;
using ExamenP3_EricMullo.Services;
using ExamenP3_EricMullo.Database;
using ExamenP3_EricMullo;
using ExamenTercerProgreso_Eric.ViewModels;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();

        // Configuración general del proyecto
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        // Configuración de dependencias
        string dbPath = Path.Combine(FileSystem.AppDataDirectory, "aeropuertos.db");
        builder.Services.AddSingleton(new DatabaseService(dbPath)); // Base de datos
        builder.Services.AddSingleton<ApiService>(); // Servicio de API
        builder.Services.AddSingleton<MainViewModel>(); // ViewModel para MainPage
        builder.Services.AddTransient<SavedPage>(); // ViewModel para SavedPage
        builder.Services.AddSingleton<SavedViewModel>();

        // Registro de páginas de navegación
        builder.Services.AddTransient<MainPage>(); // Página principal (Buscador)
        builder.Services.AddTransient<SavedPage>(); // Página secundaria (Guardados)

        return builder.Build();
    }
}
