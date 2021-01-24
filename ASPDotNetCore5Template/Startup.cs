using DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using System.Collections.Generic;
using System.Linq;
using ASPDotNetCore5Template.Helpers;
using ServiceLayer;
using DataLayer.Entities;
using ASPDotNetCore5Template.Providers;
using ASPDotNetCore5Template.Config;

namespace ASPDotNetCore5Template
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
