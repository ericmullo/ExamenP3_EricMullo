using System.Net.Http.Json;
using ExamenP3_EricMullo.Models;


namespace ExamenP3_EricMullo.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient = new HttpClient();

        public async Task<Aeropuerto?> BuscarAeropuerto(string nombre)
        {
            string url = $"https://freetestapi.com/api/v1/airports?search={nombre}&limit=1";
            var response = await _httpClient.GetFromJsonAsync<List<Aeropuerto>>(url);
            return response?.FirstOrDefault();
        }
    }
}
