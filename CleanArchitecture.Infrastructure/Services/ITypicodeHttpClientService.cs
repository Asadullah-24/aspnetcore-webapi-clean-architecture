using CleanArchitecture.Core.Models;

namespace CleanArchitecture.Infrastructure.Services
{
    public interface ITypicodeHttpClientService
    {
        Task<List<TypicodeData>> GetTypeCodeUser();
        Task<PostsData> GetPostById(int Id);
    }
}