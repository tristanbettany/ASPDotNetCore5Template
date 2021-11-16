using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Web.UI;

namespace ApplicationLayer.Providers
{
    public static class MvcProvider
    {
        public static void Apply(
            IServiceCollection services, 
            IConfiguration configuration
        ) {
            services.AddControllersWithViews(options =>
            {
                AuthorizationPolicy policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();

                options.Filters.Add(new AuthorizeFilter(policy));
            });

            services.AddRazorPages().AddMicrosoftIdentityUI();
        }
    }
}
