using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Core.Options;
using CleanArchitecture.Infrastructure.Data;
using CleanArchitecture.Infrastructure.Repositories;
using CleanArchitecture.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace CleanArchitecture.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureDI(this IServiceCollection services)
        {
            //services.AddDbContext<AppDbContext>(options =>
            //{
            //    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            //});

            //services.AddHttpClient<TypicodeHttpClientService>(option => 
            //{
            //    option.BaseAddress = new Uri("");
            //});

            services.AddDbContext<AppDbContext>((provider,options) =>
            {
                options.UseSqlServer(provider.GetRequiredService<IOptionsSnapshot<ConnectionStringOptions>>().Value.DefaultConnection);
            });

            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IExternalVendorRepository, ExternalVendorRepository>();

            services.AddHttpClient<ITypicodeHttpClientService, TypicodeHttpClientService>((provider,options) => 
            {
                // we use IOptions bcz Lifetime: singleton, use: HttpClient, global config
               options.BaseAddress = new Uri(provider.GetRequiredService<IOptions<TypicodeOptions>>().Value.BaseUrl);
            });

            services.AddHttpClient<IJsonDummyHttpClientService, JsonDummyHttpClientService>((provider,options) => 
            {
               options.BaseAddress = new Uri(provider.GetRequiredService<IOptions<JsonDummyDataOptions>>().Value.BaseUrl);
            });

            return services;
        }

    }
}
