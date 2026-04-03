using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Core.Models;
using MediatR;

namespace CleanArchitecture.Application.Queries
{
    public record GetTypicodeDataQuery() : IRequest<List<TypicodeData>>;
    public class GetTypicodeDataQueryHandler(IExternalVendorRepository externalVendorRepository)
    : IRequestHandler<GetTypicodeDataQuery, List<TypicodeData>>
    {
        public async Task<List<TypicodeData>> Handle(GetTypicodeDataQuery request, CancellationToken cancellationToken)
        {
            return await externalVendorRepository.GetTypeCodeUser(); // should return List<TypicodeData>
        }
    }
}
