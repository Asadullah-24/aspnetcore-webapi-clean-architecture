using CleanArchitecture.Core.Interfaces;
using MediatR;

namespace CleanArchitecture.Application.Commands
{
    public record DeleteEmployeeCommand(int employeeId) : IRequest<bool>;
    public class DeleteEmployeeCommandHandler(IEmployeeRepository employeeRepository)
        : IRequestHandler<DeleteEmployeeCommand, bool>
    {
        public async Task<bool> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            return await employeeRepository.DeleteEmployeeByAsync(request.employeeId);
        }
    }
}
