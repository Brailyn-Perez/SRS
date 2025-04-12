using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

namespace SRS.IOC.Application
{
    public static class ApplicationServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            return services;
        }
    }
}
