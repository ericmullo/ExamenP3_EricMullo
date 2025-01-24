using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using ExamenP3_EricMullo;
using ExamenP3_EricMullo.Models;
using System.Security.Cryptography.X509Certificates;

namespace ExamenP3_EricMullo.Database.Database
{
    public class DatabaseService
    {
        private readonly SQLiteAsyncConnection _db;
        public DatabaseService(string dbPath)
        {
            _db = new SQLiteAsyncConnection(dbPath);
            _db.CreateTableAsync<Aereopuerto>().Wait();

        }
        public Task<int> GuardarAereopuerto(Aereopuerto aereopuerto) =>
            _db.InsertAsync(aereopuerto);
        public Task<List<Aereopuerto>> ObtenerAereopuerto() =>
            _db.Table<Aereopuerto>().ToListAsync();
    }
}
