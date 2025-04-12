using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SRS.Infraestructure.Persistence.Context;

namespace SRS.IOC.Infraestructure.Persistence
{
    public static class PersistenceServices
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SRSContext>(options =>
            options.UseInMemoryDatabase("SRSDataBase"));

            return services;
        }
    }
}
