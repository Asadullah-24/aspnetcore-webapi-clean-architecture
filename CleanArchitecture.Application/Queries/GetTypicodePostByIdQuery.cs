using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Core.Models;
using MediatR;

namespace CleanArchitecture.Application.Queries
{
    public record GetTypicodePostByIdQuery(int postId) : IRequest<PostsData>;
    public class GetTypicodePostByIdQueryHandler(IExternalVendorRepository externalVendorRepository)
        : IRequestHandler<GetTypicodePostByIdQuery, PostsData>
    {
        public async Task<PostsData> Handle(GetTypicodePostByIdQuery request, CancellationToken cancellationToken)
        {
            return await externalVendorRepository.GetPostById(request.postId); // should return PostsData
        }
    }
}
