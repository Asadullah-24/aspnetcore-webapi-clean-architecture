using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Core.Models;
using CleanArchitecture.Infrastructure.Services;
using System.Net.Http;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class ExternalVendorRepository : IExternalVendorRepository
    {
        private readonly ITypicodeHttpClientService _TypicodeService;
        private readonly IJsonDummyHttpClientService _JsonService;
        public ExternalVendorRepository(ITypicodeHttpClientService typecodeService, IJsonDummyHttpClientService jsonService)
        {
            _TypicodeService = typecodeService;
            _JsonService = jsonService;
        }

        public async Task<List<TypicodeData>> GetTypeCodeUser()
        {
            return await _TypicodeService.GetTypeCodeUser();
        }

        public async Task<PostsData> GetPostById(int id)
        {
            return await _TypicodeService.GetPostById(id);
        }

        public async Task<List<JsonDummyData>> GetJsonDummyData()
        {
            return await _JsonService.GetJsonDummyData();
        }
    }
}
