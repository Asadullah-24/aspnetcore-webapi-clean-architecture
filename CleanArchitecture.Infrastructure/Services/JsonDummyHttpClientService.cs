using CleanArchitecture.Core.Models;
using System.Net.Http.Json;
using System.Text.Json;

namespace CleanArchitecture.Infrastructure.Services
{
    public class JsonDummyHttpClientService : IJsonDummyHttpClientService
    {
        private readonly HttpClient _httpClient;
        public JsonDummyHttpClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<JsonDummyData>> GetJsonDummyData()
        {
            //var response = await _httpClient.GetStringAsync("64KB.json");
            //return JsonSerializer.Deserialize<List<JsonDummyData>>(response);
            return await _httpClient.GetFromJsonAsync<List<JsonDummyData>>("64KB.json");
        }
    }
}
