using DataLayer.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Web;
using ServiceLayer;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ASPDotNetCore5Template.Providers
{
    public static class AuthProvider
    {
        public static void Apply(
            IServiceCollection services, 
            IConfiguration configuration
        ) {
            services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
                .AddMicrosoftIdentityWebApp(configuration.GetSection("AzureAd"));

            services.AddAuthorization(options =>
            {
                options.AddPolicy(configuration.GetSection("AzureAd").GetValue<string>("AllowedGroupName"), PolicyBuilder =>
                {
                    PolicyBuilder.RequireClaim("groups", configuration.GetSection("AzureAd").GetValue<string>("AllowedGroupId"));
                });
            });

            services.Configure<OpenIdConnectOptions>(OpenIdConnectDefaults.AuthenticationScheme, options =>
            {
                options.Events.OnTicketReceived += OnTicketReceivedCallback;

                options.Events.OnSignedOutCallbackRedirect += context =>
                {
                    context.Response.Redirect(configuration.GetSection("AzureAd").GetValue<string>("SignOutRedirectUri"));
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
    }
}
