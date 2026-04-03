using CleanArchitecture.Core.Models;

namespace CleanArchitecture.Core.Interfaces
{
    public interface IExternalVendorRepository
    {
        Task<List<TypicodeData>> GetTypeCodeUser();
        Task<PostsData> GetPostById(int id);
        Task<List<JsonDummyData>> GetJsonDummyData();
    }
}
