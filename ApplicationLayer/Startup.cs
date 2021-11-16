using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ServiceLayer;
using ApplicationLayer.Providers;
using ApplicationLayer.Config;

namespace ApplicationLayer
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(Configuration);
            services.AddScoped<IUserService, UserService>();

            DbProvider.Apply(services, Configuration);
            AuthProvider.Apply(services, Configuration);
            MvcProvider.Apply(services, Configuration);
        }

        public void Configure(
            IApplicationBuilder app,
            IWebHostEnvironment env
        )
        {
            ExceptionConfig.Apply(app, env, Configuration);

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            RoutingConfig.Apply(app, env, Configuration);
        }
    }
}
