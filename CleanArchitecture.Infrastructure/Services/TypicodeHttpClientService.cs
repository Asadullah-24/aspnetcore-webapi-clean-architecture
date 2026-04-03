using CleanArchitecture.Core.Models;
using System.Net.Http.Json;
using System.Text.Json;

namespace CleanArchitecture.Infrastructure.Services
{
    public class TypicodeHttpClientService : ITypicodeHttpClientService
    {
        private readonly HttpClient _httpClient;
        public TypicodeHttpClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<TypicodeData>> GetTypeCodeUser()
        {
            //return await httpClient.GetFromJsonAsync<TypicodeData>("https://jsonplaceholder.typicode.com/users");
            //var response = await httpClient.GetStringAsync("https://jsonplaceholder.typicode.com/users");
            var response = await _httpClient.GetStringAsync("users");
            return JsonSerializer.Deserialize<List<TypicodeData>>(response);
        }
        public async Task<PostsData> GetPostById(int Id)
        {
            return await _httpClient.GetFromJsonAsync<PostsData>($"posts/{Id}");

        }
    }
}
