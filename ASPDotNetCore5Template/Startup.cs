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

namespace ASPDotNetCore5Template
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        private IConfigurationSection AzureConfig { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            AzureConfig = Configuration.GetSection("AzureAd");
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();

            services.AddDbContext<DataLayerContext>(options => {
                options.UseSqlServer(Configuration.GetConnectionString("DataLayer"));
            });

            services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
                .AddMicrosoftIdentityWebApp(AzureConfig);

            services.AddControllersWithViews(options =>
            {
                AuthorizationPolicy policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();

                options.Filters.Add(new AuthorizeFilter(policy));
            });

            services.AddRazorPages().AddMicrosoftIdentityUI();

            services.AddAuthorization(options =>
            {
                options.AddPolicy(AzureConfig.GetValue<string>("AllowedGroupName"), PolicyBuilder =>
                {
                    PolicyBuilder.RequireClaim("groups", AzureConfig.GetValue<string>("AllowedGroupId"));
                });
            });
            
            services.Configure<OpenIdConnectOptions>(OpenIdConnectDefaults.AuthenticationScheme, options =>
            {
                options.Events.OnTicketReceived += OnTicketReceivedCallback;

                options.Events.OnSignedOutCallbackRedirect += context =>
                {
                    context.Response.Redirect(AzureConfig.GetValue<string>("SignOutRedirectUri"));
                    context.HandleResponse();

                    return Task.CompletedTask;
                };
            });
        }

        public static Task OnTicketReceivedCallback(TicketReceivedContext context)
        {
            List<Claim> claims = context.Principal.Claims.ToList();

            string userId = claims.FirstOrDefault(context => {
                return context.Type == ClaimTypes.NameIdentifier;
            }).Value;

            string email = context.Principal.Identity.Name;

            IUserService service = context.HttpContext.RequestServices.GetService<IUserService>();
            User userModel = new User { Id = userId, Email = email };
            service.Add(userModel);

            return Task.CompletedTask;
        }

        public void Configure(
            IApplicationBuilder app,
            IWebHostEnvironment env
        )
        {
            if (env.IsDevelopment() == true)
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(Configuration.GetValue<string>("ExceptionUri"));
                app.UseHsts();
            }

            app.UseStatusCodePagesWithReExecute("/Exception/Code/{0}");

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "home",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                );

                endpoints.MapControllerRoute(
                    name: "user",
                    pattern: "{controller=User}/{action=SignedOut}/{id?}"
                );

                endpoints.MapRazorPages();
            });
        }
    }
}
