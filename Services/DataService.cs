using System.Net.Http;
using System.Threading.Tasks;
//using Newtonsoft.Json; <--- JSON serializer
using System.Text.Json;
using NoteApp.Controllers;
using System.Text.Json.Serialization;
using NoteApp.Models;

namespace NoteApp.Services
{
    public class DataService
    {
        private readonly HttpClient _httpClient;

        public DataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<MealResponse> GetDataAsync()
        {
            //test out the remote api
            var response = await _httpClient.GetAsync("https://www.themealdb.com/api/json/v1/1/search.php?s=Arrabiata");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            var mealResponse = JsonSerializer.Deserialize<MealResponse>(json, options);
            return mealResponse;
        }
    }
}

