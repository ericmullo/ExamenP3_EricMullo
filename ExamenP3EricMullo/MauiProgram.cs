using ExamenP3_EricMullo.Repositories;

using Microsoft.Extensions.Logging;

namespace ExamenP3_EricMullo
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif

            // Assembler reference for the AirportRepository
            string dbPath = System.IO.Path.Combine(FileSystem.AppDataDirectory, "ariel_anchapaxi.db3");

            builder.Services.AddSingleton<AirportRepository>(s => ActivatorUtilities.CreateInstance<AirportRepository>(s, dbPath));

            // Assembler reference for the APIRepository
            builder.Services.AddSingleton<APIRepository>();

            return builder.Build();
        }
    }
}
