using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Core.Models;
using MediatR;

namespace CleanArchitecture.Application.Queries
{
    public record GetAllJsonDataQuery() : IRequest<List<JsonDummyData>>;
    public class GetAllJsonDataQueryHandler(IExternalVendorRepository externalVendorRepository)
    : IRequestHandler<GetAllJsonDataQuery, List<JsonDummyData>>
    {
        public async Task<List<JsonDummyData>> Handle(GetAllJsonDataQuery request, CancellationToken cancellationToken)
        {
            return await externalVendorRepository.GetJsonDummyData(); // should return List<TypicodeData>
        }
    }
}
