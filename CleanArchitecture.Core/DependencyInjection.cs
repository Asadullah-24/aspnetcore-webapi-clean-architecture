using CleanArchitecture.Core.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Core
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCoreDI(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ConnectionStringOptions>(configuration.GetSection(ConnectionStringOptions.SectionName));
            services.Configure<TypicodeOptions>(configuration.GetSection(TypicodeOptions.SectionName));
            services.Configure<JsonDummyDataOptions>(configuration.GetSection(JsonDummyDataOptions.SectionName));
            return services;
        }

    }
}
