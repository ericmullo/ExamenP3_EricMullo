

using System.Net.Http.Json;
using ExamenP3_EricMullo;
using ExamenP3_EricMullo.Models;

namespace ExamenP3_EricMullo.Services
{
    public class ApiService
    {
        private readonly HttpClient_httpClient = new ();
        public async Task<Aereopuerto?> BuscarAereopuerto(String nombre);
        {
        string url = "https://freetestapi.com/api/v1/airports?search={nombre}";
        var response = await _httoClient.GetFromJsonAsync<List<Aereopuerto>>(url);
        return response?.FirstOrDefault();
        }
    }
}
