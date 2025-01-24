using SQLite;
using ExamenP3_EricMullo.Models;


namespace ExamenP3_EricMullo.Database
{
    public class DatabaseService
    {
        private readonly SQLiteAsyncConnection _db;

        public DatabaseService(string dbPath)
        {
            _db = new SQLiteAsyncConnection(dbPath);
        }

        public async Task InitializeDatabaseAsync()
        {
            try
            {
                await _db.CreateTableAsync<Aeropuerto>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear la tabla: {ex.Message}");
            }
        }

        public Task<int> GuardarAeropuerto(Aeropuerto aeropuerto) =>
            _db.InsertAsync(aeropuerto);

        public Task<List<Aeropuerto>> ObtenerAeropuertos() =>
            _db.Table<Aeropuerto>().ToListAsync();
    }
}
