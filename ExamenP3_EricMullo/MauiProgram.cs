using ExamenTercerProgreso_Eric.Services;
using ExamenTercerProgreso_Eric.Database;
using ExamenTercerProgreso_Eric.ViewModels;
public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        // Configuración de dependencias
        string dbPath = Path.Combine(FileSystem.AppDataDirectory, "aeropuertos.db");
        builder.Services.AddSingleton(new DatabaseService(dbPath));
        builder.Services.AddSingleton<ApiService>();
        builder.Services.AddSingleton<MainViewModel>();
        builder.Services.AddSingleton<SavedViewModel>();
        return builder.Build();
    }
}