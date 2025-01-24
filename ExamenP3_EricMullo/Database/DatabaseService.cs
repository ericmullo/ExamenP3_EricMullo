using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using ExamenP3_EricMullo;
using ExamenP3_EricMullo.Models;

namespace ExamenP3_EricMullo.Database.Database
{
    public class DatabaseService
    {
        private SQLiteAsyncConnection _db;

        // Constructor sin inicialización asincrónica
        public DatabaseService(string dbPath)
        {
            _db = new SQLiteAsyncConnection(dbPath);
        }

        // Método para inicializar la base de datos asincrónicamente
        public async Task InitializeDatabaseAsync()
        {
            try
            {
                await _db.CreateTableAsync<Aereopuerto>();
            }
            catch (Exception ex)
            {
                // Manejo de errores, por ejemplo, log de la excepción
                Console.WriteLine($"Error al crear la tabla: {ex.Message}");
            }
        }

        // Método para guardar un aeropuerto
        public Task<int> GuardarAereopuerto(Aereopuerto aereopuerto) =>
            _db.InsertAsync(aereopuerto);

        // Método para obtener la lista de aeropuertos
        public Task<List<Aereopuerto>> ObtenerAereopuerto() =>
            _db.Table<Aereopuerto>().ToListAsync();
    }
}
