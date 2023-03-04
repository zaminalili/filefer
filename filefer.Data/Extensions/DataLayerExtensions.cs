using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace filefer.Data.Extensions
{
    public static class DataLayerExtensions
    {
        public static IServiceCollection LoadDataLayerExtensions(this IServiceCollection services, IConfiguration configuration)
        {

            return services;
        }
    }
}
