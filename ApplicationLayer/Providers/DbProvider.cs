using DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ApplicationLayer.Providers
{
    public static class DbProvider
    {
        public static void Apply(
            IServiceCollection services, 
            IConfiguration configuration
        ) {
            services.AddDbContext<DataLayerContext>(options => {
                options.UseSqlServer(configuration.GetConnectionString("DataLayer"));
            });
        }
    }
}
