using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Infrastructure.Data;
using CleanArchitecture.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureDI(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer("Server=ASADULLAH;Database=CleanArchitectureDb;Trusted_Connection=True;TrustServerCertificate=True;");
            });

            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            return services;
        }

    }
}
