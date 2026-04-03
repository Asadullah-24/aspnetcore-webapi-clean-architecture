
using CleanArchitecture.Core.Models;
using CleanArchitecture.Core.Options;

namespace CleanArchitecture.Infrastructure.Services
{
    public interface IJsonDummyHttpClientService
    {
        Task<List<JsonDummyData>> GetJsonDummyData();
    }
}