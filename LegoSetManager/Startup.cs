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

namespace LegoSetManager
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

            services.AddAuthorization(options => {
                options.AddPolicy(AzureConfig.GetValue<string>("AllowedGroupName"), PolicyBuilder => {
                    PolicyBuilder.RequireClaim("groups", AzureConfig.GetValue<string>("AllowedGroupId"));
                });
            });
        }

        public void Configure(
            IApplicationBuilder app, 
            IWebHostEnvironment env
        ) {
            if (env.IsDevelopment() == true)
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                );

                endpoints.MapRazorPages();
            });
        }
    }
}